using UnityEngine;
using System.Collections;

public class BamsongiGenerator : MonoBehaviour {

	public GameObject bamsongiPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown (0)) {
			GameObject bamsongi = Instantiate (bamsongiPrefab) as GameObject;
			//bamsongi.GetComponent<BamsongiController> ().Shoot (new Vector3 (0, 200, 2000));

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			Vector3 worldDir = ray.direction;
			bamsongi.GetComponent<BamsongiController> ().Shoot (worldDir.normalized * 2000);
		}
	}
}
