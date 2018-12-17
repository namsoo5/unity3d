using UnityEngine;
using System.Collections;

public class AttackArea : MonoBehaviour {

	CharacterStatus status;


	// Use this for initialization
	void Start () {
		status = transform.root.GetComponent<CharacterStatus> ();
	}

	public class AttackInfo{
		//공격력
		public int attackPower;
		//공격자
		public Transform attacker;
	}

	//공격자정보를가져온다.
	AttackInfo GetAttackInfo()
	{
		AttackInfo attackInfo = new AttackInfo ();
		//공격력 계산
		attackInfo.attackPower = status.Power;
		attackInfo.attacker = transform.root;

		return attackInfo;
	}
	//맞았다
	void OnTriggerEnter(Collider other)
	{
		//공격당한상대의 damage메시지를 보낸다.
		other.SendMessage ("Damage", GetAttackInfo ());
		//공격한대상저장
		status.lastAttackTarget = other.transform.root.gameObject;
	}





	//공격판정 유효로한다
	void OnAttack(){
		GetComponent<Collider>().enabled = true;
	}

	//공격판정무효로함
	void OnAttackTermination(){
		GetComponent<Collider>().enabled = false;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
