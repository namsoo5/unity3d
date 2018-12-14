﻿using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public float distance = 6.0f;
	public float horizontalAngle = 0.0f;
	public float rotAngle = 180.0f;		//화면가로폭만큼커서를이동시켰을때 몇도회전하는가
	public float verticalAngle = 10.0f;
	public Transform lookTarget;
	public Vector3 offset = Vector3.zero;

	InputManager inputManager;
	// Use this for initialization
	void Start () {
		inputManager = FindObjectOfType<InputManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		//드래그입력으로카메라회전각을갱신
		if (inputManager.Moved ()) {
			float anglePerPixel = rotAngle / (float)Screen.width;
			Vector2 delta = inputManager.GetDeltaPosition ();
			horizontalAngle += delta.x * anglePerPixel;
			horizontalAngle = Mathf.Repeat (horizontalAngle, 360.0f);
			verticalAngle -= delta.y * anglePerPixel;
			verticalAngle = Mathf.Clamp (verticalAngle, -60.0f, 60.0f);
		}

		//카메라의 위치와 회전각을갱신
		if (lookTarget != null) {
			Vector3 lookPosition = lookTarget.position + offset;
			//주시대상에서 상대위치를 구한다
			Vector3 relativePos = Quaternion.Euler (verticalAngle, horizontalAngle, 0) * new Vector3 (0, 0, -distance);
		
			//주시대상의 위치에 오프셋을더한 위치로이동시킨다
			transform.position = lookPosition + relativePos;

			//주시대상을주시하게된다.
			transform.LookAt(lookPosition);

			//장애물을피한다.
			RaycastHit hitInfo;
			if (Physics.Linecast (lookPosition, transform.position, out hitInfo, 1 << LayerMask.NameToLayer ("Ground")))
				transform.position = hitInfo.point;
		}
	}
}
