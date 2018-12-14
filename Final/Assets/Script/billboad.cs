using UnityEngine;
using System.Collections;

public class billboad : MonoBehaviour {


	// Update is called once per frame
	void Update () {

		transform.LookAt (Camera.main.transform);
	}
}
