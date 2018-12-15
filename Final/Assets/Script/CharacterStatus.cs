using UnityEngine;
using System.Collections;

public class CharacterStatus : MonoBehaviour {
	//*********공격창에서 사용한다.
	//체력.
	public int HP = 100;
	public int MaxHP = 100;

	//공격력
	public int Power = 10;

	//마지막에 공격한 대상
	public GameObject lastAttackTarget = null;

	//********GUI및네트워크창에서 사용한다.
	//플레이어 이름
	public string characterName = "Player";

	//*******애니메이션 창에서 사용한다.
	//상태
	public bool attacking = false;
	public bool died = false;

	bool statedie=true;//죽은상태1번실행

	//스킬에맞은 hp0일떄 die
	GameObject PlayCtrl;

	// Use this for initialization
	void Start () {
		PlayCtrl = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if (HP > MaxHP) {
			HP = MaxHP;
		}
		if (HP <= 0)
			HP = 0;

		if (HP == 0 && statedie) {
			PlayCtrl.GetComponent<PlayerCtrl> ().SkillDamage ();
			statedie = false;
		}
		
	}
}
