using UnityEngine;
using System.Collections;

public class StrongAttackCtrl : MonoBehaviour {

	float timer;
	GameObject Player;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().AddForce (transform.forward * 1000.0f); //발사
		Player = GameObject.Find("Player");
		GetComponent<Collider>().enabled = false;
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime; 
		if (timer >= 0.7f ) {  //0.7초뒤삭제
			Destroy (this.gameObject);
		}
		if(timer>=0.1f){
			GetComponent<Collider>().enabled = true; //데미지중첩방지
		}
	}

	void OnCollisionEnter(Collision other){

	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "enemy") {
			other.GetComponent<CharacterStatus> ().HP -= Player.GetComponent<CharacterStatus> ().Power ;

		} 
	}
		
}
