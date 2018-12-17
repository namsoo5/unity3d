using UnityEngine;
using System.Collections;

public class itemCtrl_power : MonoBehaviour {


	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 400f, 0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "Player") {
			GameObject.Find ("03_red").GetComponent<ParticleSystem> ().Play();
			GameObject.Find ("GameDirector").GetComponent<GameDirector> ().poweritemeffect = true;

			other.GetComponent<CharacterStatus>().Power += 50;
			other.GetComponent<PlayerCtrl> ().poweritem +=1;

			Destroy (this.gameObject);
		} 

	}

}
