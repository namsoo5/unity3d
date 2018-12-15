using UnityEngine;
using System.Collections;

public class explain : MonoBehaviour {
	bool start=true; //화면전환
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void explainclick(){
		if (start) {
			transform.position = new Vector3 (30, 0.02f, -5.5f);
			start = false;
		} else {
			transform.position = new Vector3 (0, 0.02f, -5.5f);
			start = true;
		}
	}

}
