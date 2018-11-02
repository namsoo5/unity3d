using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameDirector : MonoBehaviour {

	GameObject stext;
	GameObject twind;
	GameObject bam;
	public int score=0;
	float timer=0;
	// Use this for initialization
	void Start () {
		this.stext = GameObject.Find ("Text");
		this.twind = GameObject.Find ("Wind");
		this.bam = GameObject.Find ("BamsongiGenerator");
	}
	
	// Update is called once per frame
	void Update () {
		this.stext.GetComponent<Text> ().text = "Score" + score.ToString("D3");

		timer += Time.deltaTime;
		if(timer>2){
			float x = Random.Range (0, 5);
			float y = Random.Range (0, 5);
			float z = Random.Range (0, 5);

			bam.GetComponent<Rigidbody> ().AddForce (new Vector3(x, y, z));

	}
}
