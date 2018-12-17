using UnityEngine;
using System.Collections;

public class boxCtrl : MonoBehaviour {
	Animator animator;
	bool open = false;
	float timer;
	public GameObject key;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		GetComponent<Rigidbody> ().AddForce (transform.up * 300f);
		GetComponent<Rigidbody> ().AddForce (transform.forward*-100f);
		GetComponent<Collider> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (open) {
			timer += Time.deltaTime;

		}
		if (timer > 2) {
			dropkey ();
			Destroy (this.gameObject);
		}


	}
	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "Player") {
			animator.SetTrigger ("open");
			GetComponent<AudioSource> ().Play();
			open = true;

		} 
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "barricade")
			GetComponent<Collider> ().enabled = true;
	}
	void dropkey(){
		GameObject dropItem =key;
		Instantiate (dropItem, transform.position, Quaternion.identity);
	}

}
