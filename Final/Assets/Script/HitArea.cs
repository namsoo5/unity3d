using UnityEngine;
using System.Collections;

public class HitArea : MonoBehaviour {


	void Damage (AttackArea.AttackInfo attackInfo)
	{
		transform.root.SendMessage ("Damage", attackInfo);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//맞으면파티클
	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "attack") {
			this.GetComponent<ParticleSystem> ().Play ();
		} 
	}

}
