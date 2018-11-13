using UnityEngine;
using System.Collections;

public class BasketController : MonoBehaviour {

	//audio add
	public AudioClip appleSE;
	public AudioClip bombSE;
	AudioSource aud;  //audiosource는 1개만 등록가능하기때문에 음원을제어해야함

	GameObject director;
	// Use this for initialization
	void Start () {
	
		this.aud = GetComponent<AudioSource> ();
		this.director = GameObject.Find ("GameDirector");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);  // 스크린 좌표를 이용해서 월드 좌표를 구하기위함
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {  //hit에는 picking한 월드좌표 있음
				float x = Mathf.RoundToInt (hit.point.x);  //반올림 
				float z = Mathf.RoundToInt (hit.point.z);
				transform.position = new Vector3 (x, .0f, z);  
			}
				//클릭한곳이 어딘지 check 하는 code 그곳으로 이동
		}
	}
		
		void OnTriggerEnter(Collider other){  
		if (other.gameObject.tag == "Apple") {
			this.aud.PlayOneShot (this.appleSE);
			this.director.GetComponent<GameDirector> ().GetApple ();
		} else if (other.gameObject.tag == "Bomb") {
			this.aud.PlayOneShot (this.bombSE);
			this.director.GetComponent<GameDirector> ().GetBomb ();
		}

			Destroy (other.gameObject);
	}
}
