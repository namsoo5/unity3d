﻿using UnityEngine;
using System.Collections;

public class BombCtrl : MonoBehaviour {

	float timer;
	bool touch = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(touch){
			timer += Time.deltaTime;  //닿고나서 3초후삭제

		}
		if (timer >= 3 ) {  //3초뒤삭제
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter(Collision other){
		
	}

	void OnTriggerEnter(Collider other){
		
		if (other.gameObject.tag == "enemy") {
			this.GetComponent<ParticleSystem> ().Play ();  //폭발파티클
			other.GetComponent<CharacterStatus> ().HP -= 20;
			touch = true;
		}
	}


	public void Shoot(Vector3 dir)
	{
		GetComponent<Rigidbody> ().AddForce (dir); //폭탄날라감
	}

}
