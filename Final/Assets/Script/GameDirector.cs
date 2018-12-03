using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour {

	GameObject Infotext;
	GameObject Player;
	int PowerUpMoney = 300;   //업글할수록 증가하기위해변수로선언
	int HpUpMoney = 200;
	GameObject HpMoneyText;  //증가한 텍스트를 변경시켜야함
	GameObject PowerMoneyText;
	// Use this for initialization
	void Start () {
		Infotext = GameObject.Find ("InfoText");  //hp,power텍스트
		Player = GameObject.Find ("Player");

		HpMoneyText = GameObject.Find ("HpMoney");
		PowerMoneyText = GameObject.Find("PowerMoney");
	}
	
	// Update is called once per frame
	void Update () {
		int hp = Player.GetComponent<CharacterStatus> ().HP;
		int power = Player.GetComponent<CharacterStatus> ().Power;
		Infotext.GetComponent<Text> ().text = "Hp: " + hp + "\n" + "Power: " + power;
	}

	public void hpup(){  //피업글버튼클릭시
		if (Player.GetComponent<PlayerCtrl> ().money >= HpUpMoney) {
			Player.GetComponent<PlayerCtrl> ().money -= HpUpMoney;
			Player.GetComponent<CharacterStatus> ().MaxHP += 20;
			Player.GetComponent<CharacterStatus> ().HP += 20;
			HpUpMoney += 100;
			HpMoneyText.GetComponent<Text> ().text = HpUpMoney.ToString("F0");

		}
	}

	public void powerup(){
		if (Player.GetComponent<PlayerCtrl> ().money >= PowerUpMoney) {
			Player.GetComponent<PlayerCtrl> ().money -= PowerUpMoney;
			Player.GetComponent<CharacterStatus> ().Power += 10;
			PowerUpMoney += 200;
			PowerMoneyText.GetComponent<Text> ().text = PowerUpMoney.ToString ("F0");
		}
	}
}
