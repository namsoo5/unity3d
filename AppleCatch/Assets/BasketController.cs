using UnityEngine;
using System.Collections;

public class BasketController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);  // 스크린 좌표를 이용해서 월드 좌표를 구하기위함
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {  //hit에는 picking한 월드좌표 있음
				float x = Mathf.RoundToInt (hit.point.x);  //반올림 
				float z = Mathf.RoundToInt (hit.point.z);
				transform.position = new Vector3 (x, .0f, z);  
			}
				//클릭한곳이 어딘지 check 하는 code 그곳으로 이동
		}
	}
		
		void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Apple")
			Debug.Log ("apple");
		else if(other.gameObject.tag =="Bomb");
			Debug.Log("bomb");

			Destroy (other.gameObject);
	}
}
