using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hpsliderCtrl : MonoBehaviour {
	GameObject GameDirector;
	int cround=1;
	// Use this for initialization
	void Start () {
		GameDirector = GameObject.Find ("GameDirector");
	}
	
	// Update is called once per frame
	void Update () {
		//라운드상승마다 적들 강화에따른 체력게이지최대량 증가
		if(GameDirector.GetComponent<GameDirector>().round != cround){
			GetComponent<Slider> ().maxValue += 40*(GameDirector.GetComponent<GameDirector>().round-1);
			cround = GameDirector.GetComponent<GameDirector> ().round;
		}

		GetComponent<Slider> ().value = GetComponentInParent<CharacterStatus> ().HP;
	}
}
