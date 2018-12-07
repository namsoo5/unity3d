using UnityEngine;
using System.Collections;

public class EnemyGeneratorCtrl : MonoBehaviour {

	//생겨날 적 프리팹
	public GameObject enemyPrefab;
	//적을 저장한다.
	GameObject[] existEnemys;
	//액티브 최대수
	public int maxEnemy = 10;

	// Use this for initialization
	void Start () {
		//배열확보
		existEnemys = new GameObject[maxEnemy];
		//주기적으로 실행하고싶을때는코루틴을사용하면 쉽게구현할수있다.
		StartCoroutine(Exec());

	}

	//적을생성한다
	IEnumerator Exec()
	{
		while (true) {
			Generate ();
			yield return new WaitForSeconds (3.0f);
		}
	}

	void Generate()
	{
		for (int enemyCount =0; enemyCount < existEnemys.Length; ++enemyCount)
		{
			
			if(existEnemys[enemyCount] ==null)
			{
				//적생성
				existEnemys[enemyCount] = Instantiate(enemyPrefab, transform.position, transform.rotation) as GameObject;
				return;
			}
		}
	}

				



	// Update is called once per frame
	void Update () {
	
	}
}
