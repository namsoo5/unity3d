using UnityEngine;
using System.Collections;

public class BamsongiController : MonoBehaviour {
	GameObject gamedirect;
	public void Shoot(Vector3 dir){
		GetComponent<Rigidbody> ().AddForce (dir);
	}
	// Use this for initialization
	void Start () {
		this.gamedirect = GameObject.Find ("GameDirector");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "target") {
			GetComponent<Rigidbody> ().isKinematic = true;
			this.gamedirect.GetComponent<GameDirector> ().score += 10;
			GetComponent<ParticleSystem> ().Play ();
		}
	
	}
}
