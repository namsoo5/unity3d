﻿using UnityEngine;
using System.Collections;

public class itemCtrl_hp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 300f, 0));
	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "Player") {
			other.GetComponent<CharacterStatus>().HP += 40;

			Destroy (this.gameObject);
		} 

	}
}
