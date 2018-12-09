using UnityEngine;
using System.Collections;

public class SearchArea : MonoBehaviour {
	EnemyCtrl enemyCtrl;
	float wait =0;
	bool go =false;
	void Start()
	{
		// EnemyCtrl을 미리 준비한다.
		enemyCtrl = transform.root.GetComponent<EnemyCtrl>();
	}

	void Update(){
		
		wait += Time.deltaTime;
		if (wait >= 1)
			go = true;  //초기시작시 오류제거
	}


	void OnTriggerStay( Collider other )
	{
        // Player태그를 타깃으로 한다.
		if( other.gameObject.tag == "Player" && go)
			enemyCtrl.SetAttackTarget( other.transform );
	}
}
