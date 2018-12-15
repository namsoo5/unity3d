using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour {

	GameObject Infotext;
	GameObject Player;
	int PowerUpMoney = 300;   //업글할수록 증가하기위해변수로선언
	int HpUpMoney = 200;
	int BombMoney = 500;
	GameObject HpMoneyText;  //증가한 텍스트를 변경시켜야함
	GameObject PowerMoneyText;
	GameObject RoundCountText;
	GameObject BobmMoneyText;
	float time=20;  //라운드타이머
	public int round=1;
	public bool last = false; //마지막라운드체크


	// Use this for initialization
	void Start () {
		Infotext = GameObject.Find ("InfoText");  //hp,power텍스트
		Player = GameObject.Find ("Player");

		HpMoneyText = GameObject.Find ("HpMoney");
		PowerMoneyText = GameObject.Find("PowerMoney");
		BobmMoneyText = GameObject.Find ("BombMoney");
		RoundCountText = GameObject.Find ("RoundCount");

	}
	
	// Update is called once per frame
	void Update () {
		int hp = Player.GetComponent<CharacterStatus> ().HP;
		int maxhp = Player.GetComponent<CharacterStatus> ().MaxHP;
		int power = Player.GetComponent<CharacterStatus> ().Power;
		Infotext.GetComponent<Text> ().text = "Hp: " + hp + " / "+maxhp+"\n" + "Power: " + power;

		if (round < 4 && !last) {
			time -= Time.deltaTime;
		}
		if(round<3)
			RoundCountText.GetComponent<Text> ().text = "ROUND"+round+ "\n00:" + time.ToString("F0");  //라운드타이머
		else//마지막라운드
			RoundCountText.GetComponent<Text> ().text = "Final\n00:" + time.ToString("F0");  //라운드타이머

			
		if (time <= 0 && round < 3) {
			//다음라운드넘어가기
			time = 20;
			round += 1;
			Player.GetComponent<CharacterStatus> ().HP = Player.GetComponent<CharacterStatus> ().MaxHP; //새라운드풀피로시작
			Player.GetComponent<PlayerCtrl> ().money += 500;
		} else if (time <= 0 && round == 3) {
			last = true;
		}



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

	public void powerup(){  //공업버튼
		if (Player.GetComponent<PlayerCtrl> ().money >= PowerUpMoney) {
			Player.GetComponent<PlayerCtrl> ().money -= PowerUpMoney;
			Player.GetComponent<CharacterStatus> ().Power += 20;
			PowerUpMoney += 200;
			PowerMoneyText.GetComponent<Text> ().text = PowerUpMoney.ToString ("F0");
		}
	}

	public void buybomb(){
		if (Player.GetComponent<PlayerCtrl> ().money >= BombMoney) {
			Player.GetComponent<PlayerCtrl> ().money -= BombMoney;
			Player.GetComponent<PlayerCtrl> ().bombcount += 1;
			BobmMoneyText.GetComponent<Text> ().text = BombMoney.ToString ("F0");
		}

	}
		


}
