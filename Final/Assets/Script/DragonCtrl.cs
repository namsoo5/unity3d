﻿using UnityEngine;
using System.Collections;

public class DragonCtrl : MonoBehaviour {

	public GameObject attack;
	public GameObject enemy;
	public Transform attackPos;

	public Transform attackPos1;

	public Transform attackPos2;

	public Transform attackPos3;

	public Transform fireEnemyPos;

	public Transform fireEnemyPos1;

	public GameObject box;

	public int die=0;   //상자1개생성

	public Transform itempos;

	float timer=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Createattack() 
	{
		Instantiate (attack, attackPos.position, attackPos.rotation);
		Instantiate (attack, attackPos1.position, attackPos1.rotation);
		Instantiate (attack, attackPos2.position, attackPos2.rotation);
		Instantiate (attack, attackPos3.position, attackPos3.rotation);

	}
	void Fireattack()
	{
		Createattack();
	}

	void CreateEnemy() 
	{
		Instantiate (enemy, fireEnemyPos.position, fireEnemyPos.rotation);
		Instantiate (enemy, fireEnemyPos1.position, fireEnemyPos1.rotation);
	}
	void FireEnemy()
	{
		CreateEnemy();
	}




	void Update () {
		timer += Time.deltaTime;

		if (timer>5&&timer<6) {
			Fireattack ();
			//timer = 0;
		}
		if (timer > 10 && GameObject.Find("GameDirector").GetComponent<GameDirector>().round==3) {
			int n = Random.Range (0, 2);
			if(n==0)
				FireEnemy ();
			timer = 0;
		}

		if (GetComponent<CharacterStatus>().HP<=0 && die==0) {
			die = 1;
		}
		if(die>0){
			clearItem ();
			die=-1;
		}
	}

	void clearItem(){
		GameObject dropItem =box;
		Instantiate (dropItem, itempos.position, Quaternion.identity);
	}
}
