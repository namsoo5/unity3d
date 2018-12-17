using UnityEngine;
using System.Collections;

public class itemCtrl_hp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 400f, 0));
	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "Player") {
			GameObject.Find ("03").GetComponent<ParticleSystem> ().Play();
			other.GetComponent<PlayerCtrl> ().healitem += 1;
			GameObject.Find ("GameDirector").GetComponent<GameDirector> ().healitemeffect = true;   //서서히피채우기
			Destroy (this.gameObject);
		} 

	}
}
