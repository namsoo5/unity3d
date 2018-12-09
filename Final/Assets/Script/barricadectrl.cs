using UnityEngine;
using System.Collections;

public class barricadectrl : MonoBehaviour {
	GameObject Player;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "attack") {
			GetComponent<CharacterStatus> ().HP -= Player.GetComponent<CharacterStatus> ().Power;
		} 
	}
	void Damage (AttackArea.AttackInfo attackInfo)
	{

	}
}
