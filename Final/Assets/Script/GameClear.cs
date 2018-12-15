using UnityEngine;
using System.Collections;

public class GameClear : MonoBehaviour {


	public void gameClear(){
		Debug.Log ("끝");
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag ==  "Player") {
			gameClear ();
		} 

	}
}
