using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {
	//중력
	const float GravityPower = 9.8f;
	//목적지에 도착했다고 보는 정지 거리
	const float StoppingDistance = 0.6f;

	//현재 이동 속도
	Vector3 velocity = Vector3.zero;
	//캐릭터 컨트롤러의 캐시
	CharacterController characterController;
	//도착했는가(도착:true / 도착x : false)
	public bool arrived = false;

	//방향을 강제로 지시하는가
	bool forceRotate =false;

	//강제로 향하게 하고싶은 방향
	Vector3 forceRotateDirection;

	//목적지
	public Vector3 destination;

	//이동 속도
	public float walkSpeed = 6.0f;

	//회전속도
	public float rotationSpeed = 360.0f;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController> ();
		destination = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {

		//이동속도 갱신
		if (characterController.isGrounded) {
			//수평면에서 move고려 하므로 xz만 다룬다
			Vector3 destinationXZ = destination;
			//목적지와 현높이를 똑같이 함
			destinationXZ.y = transform.position.y;

			// **** 여기서 부터 xz만으로 생각 ***/
			Vector3 direction = (destinationXZ - transform.position).normalized;
			float distance = Vector3.Distance (transform.position, destinationXZ);

			//현재 속도 보관
			Vector3 currentVelocity = velocity;

			//목적지에 가까이 왔으면 도착;
			if (arrived || distance < StoppingDistance)
				arrived = true;

			//이동속도구하기
			if (arrived)
				velocity = Vector3.zero;
			else
				velocity = direction * walkSpeed;

			//부드럽게 보간 처리 lerp(a,b,t) -> a~b값을보간 아래에서 t는 0~1사이수임 
			velocity = Vector3.Lerp (currentVelocity, velocity, Mathf.Min (Time.deltaTime * 5.0f, 1.0f));
			velocity.y = 0;

			//quaternion -> rotation행렬을 의미, 자연스러운 회전행렬 구현가능, 회전을 보간... 
			if (!forceRotate) {
				//바꾸고 싶은 방향으로변경한다.
				if (velocity.magnitude > 0.1f && !arrived) {
					//이동하지 않았다면 방향은 변경하지 않는다.
					Quaternion characterTargetRotation = Quaternion.LookRotation (direction);
					transform.rotation = Quaternion.RotateTowards (transform.rotation,
						characterTargetRotation, rotationSpeed * Time.deltaTime);
					// rotation을 Look으로 quaternion구하고 그 값을 Quaternion에 RoataeToward로넣어서 구현
				}
			} else {
				//강제로 방향을 지정
				Quaternion characterTargetRotation = Quaternion.LookRotation (forceRotateDirection);
				transform.rotation = Quaternion.RotateTowards (transform.rotation,
					characterTargetRotation, rotationSpeed * Time.deltaTime);
			}
		}


		//중력
		velocity += Vector3.down * GravityPower * Time.deltaTime;

		//땅에 닿아 있다면 지면을꽉누른다
		//유니티 CharacterController 특성떄문에
		Vector3 snapGround = Vector3.zero;
		if (characterController.isGrounded)
			snapGround = Vector3.down;

		//CharacterController를 사용 해서 움직인다.
		characterController.Move (velocity * Time.deltaTime + snapGround);
		if (characterController.velocity.magnitude < 0.1f)
			arrived = true;

		//강제로방향변경해제
		if (forceRotate && Vector3.Dot (transform.forward, forceRotateDirection) > 0.99f)
			forceRotate = false;
	}

	// 목적지설정
	public void SetDestination(Vector3 destination)
	{
		arrived = false;
		this.destination = destination;
	}

	//지정한방향으로향함
	public void SetDirection(Vector3 direction)
	{
		forceRotateDirection = direction;
		forceRotateDirection.y = 0;
		forceRotateDirection.Normalize ();
		forceRotate = true;
	}

	//이동그만
	public void StopMove(){
		//현 지점 목적지로함
		destination = transform.position;
	}

	//목적지에 도착했는지 조사
	public bool Arrived()
	{
		return arrived;
	}
}
