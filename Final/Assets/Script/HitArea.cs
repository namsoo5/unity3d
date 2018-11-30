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
}
