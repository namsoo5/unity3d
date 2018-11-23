using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	Vector2 sliderStartPosition;
	Vector2 prevPosition;
	Vector2 delta = Vector2.zero;
	bool moved = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//슬라이드 시작 지점.
		if (Input.GetButtonDown ("Fire1"))  //Fire1은 unity에정의되어있는태그-입력을다양하게할수있음
			sliderStartPosition = GetCursorPosition ();  //현재 포지션위치가져옴

		//화면 너비의 10% 이상 커서를 이동시키면 슬라이드시작으로판단한다.
		if (Input.GetButton ("Fire1")) {   //누르고있으면
			if (Vector2.Distance (sliderStartPosition, GetCursorPosition ()) >= (Screen.width * 0.1f))
				moved = true;
		}

		//슬라이드가 끝났는가
		if(!Input.GetButtonUp("Fire1") && !Input.GetButton("Fire1"))
			moved = false; //슬라이드는끝났다. (드래그끝)

			//이동량을구한다.
		if (moved)
			delta = GetCursorPosition () - prevPosition;
		else
			delta = Vector2.zero;
			
		//커서위치를갱신한다.
		prevPosition = GetCursorPosition();

	}

	//클릭되었는가
	public bool Clicked()
	{
		if (!moved && Input.GetButtonUp ("Fire1"))
			return true;
		else
			return false;
	}
	//슬라이드할때커서이동량
	public Vector2 GetDeltaPosition()
	{
		return delta;
	}

	//슬라이드중인가
	public bool Moved()
	{
		return moved;
	}

	public Vector2 GetCursorPosition()
	{
		return Input.mousePosition;
	}
}
