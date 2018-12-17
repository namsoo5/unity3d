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

	public bool poweritemeffect = false; //effect효과체크변수
	public bool healitemeffect = false; //effect효과체크변수
	float powereffectTimer = 0;
	float healeffectTimer = 0;

	GameObject WarningText;


	int ctime=0;
	bool next = false; //정비시간체크
	float breaktimer = 5;
	// Use this for initialization
	void Start () {
		Infotext = GameObject.Find ("InfoText");  //hp,power텍스트
		Player = GameObject.Find ("Player");

		HpMoneyText = GameObject.Find ("HpMoney");
		PowerMoneyText = GameObject.Find("PowerMoney");
		BobmMoneyText = GameObject.Find ("BombMoney");
		RoundCountText = GameObject.Find ("RoundCount");

		WarningText = GameObject.Find ("Warning");
		WarningText.GetComponent<Text> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		int hp = Player.GetComponent<CharacterStatus> ().HP;
		int maxhp = Player.GetComponent<CharacterStatus> ().MaxHP;
		int power = Player.GetComponent<CharacterStatus> ().Power;
		Infotext.GetComponent<Text> ().text = "Hp: " + hp + " / "+maxhp+"\n" + "Power: " + power;

		if (round < 4 && !last && !next) {  //정비시간이나 마지막라운드 카운트x 컬러변경값때문에 시간은흐름
			time -= Time.deltaTime;
		}
		if(round<3 && !next)
			RoundCountText.GetComponent<Text> ().text = "ROUND"+round+ "\n00:" + time.ToString("F0");  //라운드타이머
		else if(round==3)//마지막라운드
			RoundCountText.GetComponent<Text> ().text = "Final";  //라운드타이머

			
		if (time <= 0 && round < 3) {
			//다음라운드넘어가기
			time = 20;
			round += 1;
			next = true;  //정비시간
			if(hp>0&&round<2)//죽지않을경우만
				Player.GetComponent<CharacterStatus> ().HP = Player.GetComponent<CharacterStatus> ().MaxHP; //새라운드풀피로시작
			Player.GetComponent<PlayerCtrl> ().money += 500;
		} //else if (time <= 0 && round == 3) {
			//last = true;  텍스트사라질때카운트중지
		//}
		if (next && round<3) {
			breaktimer -= Time.deltaTime;
			RoundCountText.GetComponent<Text> ().text = "Ready"+ "\n00:" + breaktimer.ToString("F0");  //라운드타이머
		}
		if (breaktimer < 0){
			breaktimer = 0;
			next = false;
		}


		int powercount = Player.GetComponent<PlayerCtrl> ().poweritem;
		int healcount = Player.GetComponent<PlayerCtrl> ().healitem;  // 아이템먹은횟수체크

		if (healitemeffect) { //item effect
				healeffectTimer += Time.deltaTime;
			if(ctime!=(int)healeffectTimer && healcount>0) {  //초마다회복
				Player.GetComponent<CharacterStatus> ().HP += 10;
				ctime = (int)healeffectTimer;
			}
		}

		if (poweritemeffect) {
			powereffectTimer += Time.deltaTime;
		}
		if (powereffectTimer > 10 ) {//10초동안 파워 이펙트
			powereffectTimer = 0;
			Player.GetComponent<CharacterStatus> ().Power -= 50;
			Player.GetComponent<PlayerCtrl> ().poweritem -=1 ;
		}
		if (healeffectTimer > 10 ) {
			healeffectTimer = 0;
			Player.GetComponent<PlayerCtrl> ().healitem -=1 ;
		}

		if (powercount == 0) {
			GameObject.Find ("03_red").GetComponent<ParticleSystem> ().Stop ();
			poweritemeffect = false;
			powereffectTimer = 0;
		}
		if (healcount == 0) {
			GameObject.Find ("03").GetComponent<ParticleSystem> ().Stop ();
			healitemeffect = false;
			healeffectTimer = 0;
		}

		//벽부수기 경고창
		if (round == 3 && time < 10) {  //10초표시
			WarningText.GetComponent<Text> ().enabled = false;
			last = true; //타이머정지
		}
		else if (round == 3) {
			WarningText.GetComponent<Text> ().enabled = true;
			next = false;
			if ((int)time % 2 == 0)
				WarningText.GetComponent<Text> ().color = Color.black;
			else
				WarningText.GetComponent<Text> ().color = Color.red;
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
