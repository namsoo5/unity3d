using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour {

	const float RayCastMaxDistance = 100.0f;
	InputManager inputManager;

	CharacterStatus status;
	CharaAnimation charaAnimation;
	Transform attackTarget;
	public float attackRange = 1.5f;
	public GameObject strongattack;
	public Transform attackPos;
	public GameObject strongattack1;
	public Transform attackPos1;
	public GameObject strongattack2;
	public Transform attackPos2;

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

	// 소지하고있는 돈
	public int money = 0;
	GameObject moneytext;

	//폭탄던지기
	public int bombcount=2; //초기화2개
	public GameObject bullet;
	public Transform firePos;

	//공격아이템획득시
	public int poweritem = 0;
	float timer=0;

	public void GetMoney(int money){
		this.money += money;
	}


	// Use this for initialization
	void Start () {
		inputManager = FindObjectOfType<InputManager> ();
		status = GetComponent<CharacterStatus> ();
		charaAnimation = GetComponent<CharaAnimation> ();

		moneytext = GameObject.Find("MoneyText");//돈상태ui
	}

	//일정이상업글시 관통공격
	void StartAttackHit(){
		 if (status.Power >= 100) {
			Fireattack ();
			Fireattack1 ();
		}else if (status.Power >= 50) {
			Fireattack ();
		}
	}

	void Fire()
	{
		CreateBullte();
	}

	void CreateBullte()
	{
		Instantiate (bullet, firePos.position, firePos.rotation);  //폭탄생성
	}

	void Fireattack()
	{
		Createattack();
	}

	void Createattack()  //공50이상시이펙트
	{
		Instantiate (strongattack, attackPos.position, attackPos.rotation);  //관통공격생성
	}
	void Fireattack1()
	{
		Createattack1();
	}

	void Createattack1()  //공100이상시이펙트
	{
		Instantiate (strongattack1, attackPos1.position, attackPos1.rotation);  //관통공격생성
		Instantiate (strongattack2, attackPos2.position, attackPos2.rotation);  //관통공격생성
	}

	// Update is called once per frame
	void Update () {
		//돈상태업데이트
		moneytext.GetComponent<Text>().text = this.money.ToString("F0")+ " $";

		if (Input.GetKeyDown(KeyCode.Q)) {  //폭탄던지기   (KeyCode.Space)
			/*GameObject bomb = Instantiate (BombPrefab) as GameObject;
			float x = transform.position.x;
			float y = transform.position.y + 1.5f;
			float z = transform.position.z;

			bomb.transform.position = new Vector3 (x, y, z);
			bomb.GetComponent<BombCtrl>().Shoot(new Vector3(0,50,0));*/

			if (bombcount > 0) {
				Fire ();
				bombcount--;
			}
		}
			



		//폭탄갯수갱신
		GameObject.Find("BombCount").GetComponent<Text>().text=bombcount.ToString("F0");

		//공격아이템지속시간
		if (poweritem>0 ) {
			timer += Time.deltaTime;

		}
		if (timer >= 5) {
			poweritem--;
			timer = 0;
			GetComponent<CharacterStatus> ().Power -= 100;

		}






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
		if (inputManager.Clicked ()) {
			if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject ()) {  //ui클릭시 이동 x
				Vector2 clickPos = inputManager.GetCursorPosition ();
				//RayCast로 대상물을조사한다.
				Ray ray = Camera.main.ScreenPointToRay (clickPos);
				RaycastHit hitInfo;


				if (Physics.Raycast (ray, out hitInfo, RayCastMaxDistance, (1 << LayerMask.NameToLayer ("Ground")) | (1 << LayerMask.NameToLayer ("EnemyHit")))) {
					//지면이클릭되엇다
					if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer ("Ground"))
						SendMessage ("SetDestination", hitInfo.point);
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
