using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour {
	public GameObject applePrefab;
	public GameObject bombPrefab;
	float span = 1.0f;
	float delta = 0;
	int ratio =2; //1,2는 폭탄

	float speed = -0.03f;

	public void SetParameter(float span, float speed, int ratio){
		this.span = span;
		this.speed = speed;
		this.ratio = ratio;
	}  //외부에서 변경할수있도록 함수생성


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		this.delta += Time.deltaTime;
		if (this.span < this.delta) {
			this.delta = 0;
			GameObject item;
			int dice = Random.Range (1, 11);//1~10까지의 랜덤숫자를 골라서 2까지나오면 폭탄떨어트리기위함
			if (dice <= this.ratio) {   //2이하일경우 폭탄생성
				item = Instantiate (bombPrefab) as GameObject;
			} else {
				item = Instantiate (applePrefab) as GameObject;
			}
			float x = Random.Range (-1, 2);
			float z = Random.Range (-1, 2);
			item.transform.position = new Vector3 (x, 4, z);
			item.GetComponent<ItemController> ().dropSpeed = this.speed;  //speed값 변경 
		}
	}
}
