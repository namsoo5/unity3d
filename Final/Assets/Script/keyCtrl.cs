using UnityEngine;
using System.Collections;

public class keyCtrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().AddForce (transform.up * 300f);
		GetComponent<Rigidbody> ().AddForce (transform.forward*-100f);
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag ==  "Player") {
			other.GetComponent<PlayerCtrl> ().key = true;
			Destroy (this.gameObject);
		} 

	}
}
