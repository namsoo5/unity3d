using UnityEngine;
using System.Collections;

public class doorCtrl : MonoBehaviour {

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag ==  "Player") {
			if (other.GetComponent<PlayerCtrl> ().key == true) {
				Destroy (this.gameObject);
			}
		} 

	}
}
