using UnityEngine;
using System.Collections;

public class BombCtrl : MonoBehaviour {

	float timer;
	bool touch = false;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().AddForce (transform.forward * 500.0f); //폭탄발사
	}
	
	// Update is called once per frame
	void Update () {
		if(touch){
			timer += Time.deltaTime;  //닿고나서 3초후삭제

		}
		if (timer >= 1 ) {  //2초뒤삭제
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "barricade") { //땅에닿아도사라짐
			this.GetComponent<ParticleSystem> ().Play ();  //폭발파티클
			touch = true;
		}
	}

	void OnTriggerEnter(Collider other){
		
		if (other.gameObject.tag == "enemy") {
			this.GetComponent<ParticleSystem> ().Play ();  //폭발파티클
			other.GetComponent<CharacterStatus> ().HP -= 80;
			touch = true;
		} 

	}


}
