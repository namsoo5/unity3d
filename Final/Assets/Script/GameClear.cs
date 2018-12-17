using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour {


	public void gameClear(){
		SceneManager.LoadScene ("ClearScene");
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag ==  "Player") {
			gameClear ();
		} 

	}
}
