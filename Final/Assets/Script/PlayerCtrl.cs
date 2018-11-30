﻿using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour {

	const float RayCastMaxDistance = 100.0f;
	InputManager inputManager;

	CharacterStatus status;
	CharaAnimation charaAnimation;
	Transform attackTarget;
	public float attackRange = 1.5f;

	//스테이트 종류
	enum State{
		Walking,
		Attacking,
		Died,
	};
	//현재스테이트
	State state = State.Walking;
	//다음스테이트
	State nextState = State.Walking;

	// Use this for initialization
	void Start () {
		inputManager = FindObjectOfType<InputManager> ();
		status = GetComponent<CharacterStatus> ();
		charaAnimation = GetComponent<CharaAnimation> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		switch (state) {
		case State.Walking:
			Walking ();
			break;
		case State.Attacking:
			Attacking ();
			break;
		}
		if (state != nextState) {
			state = nextState;
			switch (state) {
			case State.Walking:
				WalkStart ();
				break;
			case State.Attacking:
				AttackStart ();
				break;
			case State.Died:
				Died ();
				break;
			}
		}

	}

	void ChangeState(State nextState){
		this.nextState = nextState;

	}
	void WalkStart(){
		StateStartCommon ();
	}

	void Walking()
	{
		if (inputManager.Clicked()) {
			Vector2 clickPos = inputManager.GetCursorPosition ();
			//RayCast로 대상물을조사한다.
			Ray ray = Camera.main.ScreenPointToRay (clickPos);
			RaycastHit hitInfo;


			if (Physics.Raycast (ray, out hitInfo, RayCastMaxDistance, (1 << LayerMask.NameToLayer ("Ground")) | (1<<LayerMask.NameToLayer("EnemyHit")))) {
				//지면이클릭되엇다
				if(hitInfo.collider.gameObject.layer==LayerMask.NameToLayer("Ground"))
					SendMessage("SetDestination", hitInfo.point);
				//적이클릭되었다
				if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer ("EnemyHit")) {
					//수평거리를 체크해서 공격할지 결정한다.
					Vector3 hitPoint = hitInfo.point;
					hitPoint.y = transform.position.y;
					float distance = Vector3.Distance (hitPoint, transform.position);
					if (distance < attackRange) {
						//공격
						attackTarget = hitInfo.collider.transform;
						ChangeState (State.Attacking);
					} else
						SendMessage ("SetDestination", hitInfo.point);
				}
			}
		}
	}
	//공격스테이트가시작되기전에호출된다.
	void AttackStart(){
		StateStartCommon ();
		status.attacking = true;

		//적방향으로돌아보게한다
		Vector3 targetDirection = (attackTarget.position - transform.position).normalized;
		SendMessage ("SetDirection", targetDirection);

		//이동을멈춘다.
		SendMessage("StopMove");
	}
	//공격중처리
	void Attacking(){
		if (charaAnimation.IsAttacked ())
			ChangeState (State.Walking);

	}

	void Died(){
		status.died = true;
	}

	void Damage(AttackArea.AttackInfo attackInfo){
		status.HP -= attackInfo.attackPower;
		if(status.HP <=0)
		{
			status.HP = 0;
			//체력이0이로사망 스테이트로전환
			ChangeState(State.Died);
		}
	}

	//스테이트가시작되기전에 status를 초기화
	void StateStartCommon(){
		status.attacking = false;
		status.died = false;
	}
}
