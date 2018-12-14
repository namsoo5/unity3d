using UnityEngine;
using System.Collections;

public class EnemyGeneratorCtrl : MonoBehaviour {

	//생겨날 적 프리팹
	public GameObject enemyPrefab;
	//적을 저장한다.
	GameObject[] existEnemys;
	//액티브 최대수
	public int maxEnemy = 10;

	int cround =1;  //현재라운드
	public int makeround=1; //라운드별로 만드는 유닛달르게하기위한 변수
	GameObject GameDirector;
	// Use this for initialization
	void Start () {
		//배열확보
		existEnemys = new GameObject[maxEnemy];
		//주기적으로 실행하고싶을때는코루틴을사용하면 쉽게구현할수있다.
		StartCoroutine(Exec());

		GameDirector = GameObject.Find ("GameDirector");

	}

	//적을생성한다
	IEnumerator Exec()
	{
		while (true) {
			if(makeround <= cround)
				Generate ();
			yield return new WaitForSeconds (3.0f);
			if (cround == 3)
				break;
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

		if (GameDirector.GetComponent<GameDirector> ().round != cround) {  //다음라운드시 모든몹제거
			for (int enemyCount = 0; enemyCount < maxEnemy; ++enemyCount) {
				if (existEnemys [enemyCount] != null) {
					Destroy (existEnemys [enemyCount]);
				}
			}
			cround++;
		}
	}
}
