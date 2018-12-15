using UnityEngine;
using System.Collections;

public class fireCtrl : MonoBehaviour {


	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().AddForce (transform.forward * 600.0f); //발사
	}
	
	// Update is called once per frame
	void Update () {

	}


	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "barricade") { //땅에닿아도사라짐
			Destroy(this.gameObject);
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			if(other.GetComponent<CharacterStatus>().HP>0)
				other.GetComponent<CharacterStatus> ().HP -= 5;
			Destroy (this.gameObject);
		} 

	}
}
