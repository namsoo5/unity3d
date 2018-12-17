using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class movetitle : MonoBehaviour {
	int timer=0;
	int n =1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		timer += 1;
		transform.Translate (0, 0, 0.04f * n);

		if (timer > 10) {
			n *= -1;
			timer = 0;
		}
			
			
	
	}

	public void startclick(){
		SceneManager.LoadScene ("GameScene_12_04");
	}

		


}
