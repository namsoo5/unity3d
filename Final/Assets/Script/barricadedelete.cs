using UnityEngine;
using System.Collections;

public class barricadedelete : MonoBehaviour {
	GameObject barricade;
	GameObject Player;
	// Use this for initialization
	void Start () {
		barricade = GameObject.Find ("hitarea");
		Player = GameObject.Find ("Player");

	}
	
	// Update is called once per frame
	void Update () {
		if (barricade.GetComponent<CharacterStatus> ().HP<= 0) {
			Player.GetComponent<PlayerCtrl> ().money += 500;
			Destroy (this.gameObject);
		}
			
	}
}
