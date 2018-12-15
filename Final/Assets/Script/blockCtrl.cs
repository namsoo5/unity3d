using UnityEngine;
using System.Collections;

public class blockCtrl : MonoBehaviour {
	GameObject GameDirector;
	// Use this for initialization
	void Start () {
		GameDirector = GameObject.Find ("GameDirector");
	}
	
	// Update is called once per frame
	void Update () {
		if(GameDirector.GetComponent<GameDirector>().round==3)
			transform.Translate (-0.1f, 0, 0);
	}

	void OnTriggerStay(Collider other){

		if (other.gameObject.tag == "Player") {
			if(other.GetComponent<CharacterStatus>().HP>0)
				other.GetComponent<CharacterStatus>().HP -= 500;

		} 

	}
}
