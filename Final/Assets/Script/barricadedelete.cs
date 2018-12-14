using UnityEngine;
using System.Collections;

public class barricadedelete : MonoBehaviour {
	GameObject Player;
	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");

	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponentInChildren<CharacterStatus>().HP<=0) {
			Player.GetComponent<PlayerCtrl> ().money += 500;
			Destroy (this.gameObject);
		}
			
	}
}
