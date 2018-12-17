using UnityEngine;
using System.Collections;

public class AttackAreaActivator : MonoBehaviour {
	//공격판정컬라이더배열
	Collider[] attackAreaColliders;
	// Use this for initialization
	void Start () {
	//자식오브젝트에서attackarea스크립트가추가된오브젝트를찾는다
		AttackArea[] attackAreas = GetComponentsInChildren<AttackArea>();
		attackAreaColliders = new Collider[attackAreas.Length];

		for (int attackAreaCnt = 0; attackAreaCnt < attackAreas.Length; attackAreaCnt++) {
			//Attackarea스크립트가추가된오브젝트의컬라이더를배열에저장
			attackAreaColliders [attackAreaCnt] = attackAreas [attackAreaCnt].GetComponent<Collider>();
			//초기값은false
			attackAreaColliders [attackAreaCnt].enabled = false;
		}
	}

	//애메이션이벤트의 startattackhit로 컬라이더를 유효로한다.
	void StartAttackHit(){
		foreach(Collider attackAreaCollider in attackAreaColliders)
			attackAreaCollider.enabled = true;
	}

	//애니메이션이벤트의endattackhit로 컬라이더를무효로한다.
	void EndAttackHit(){
		foreach (Collider attackAreaCollider in attackAreaColliders)
			attackAreaCollider.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
