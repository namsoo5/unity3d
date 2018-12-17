using UnityEngine;
using System.Collections;

public class doorCtrl : MonoBehaviour {

	bool open =false;
	float timer=0;
	void Update () {
		if (open)
			timer += Time.deltaTime;
		if(timer>1)
			Destroy (this.gameObject);
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag ==  "Player") {
			if (other.GetComponent<PlayerCtrl> ().key == true) {
				open = true;
				GetComponent<AudioSource> ().Play ();
			}
		} 

	}
}
