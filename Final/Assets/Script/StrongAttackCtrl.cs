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
		timer += Time.deltaTime;  //닿고나서 3초후삭제
		if (timer >= 1 ) {  //3초뒤삭제
			Destroy (this.gameObject);
		}
		if(timer>=0.15f){
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
