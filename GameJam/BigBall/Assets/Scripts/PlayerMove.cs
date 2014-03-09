using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public bool isActive = true;

	public Vector3 gravity = new Vector3(0f, -10f, 0f);
	public float gravityMegatron = 10f;
	public float acc = 10f;
	public float speed = 5f;
	
	private Vector3 direction = Vector3.forward;


	public GameObject BebitteMesh;
	private Animator BebitteAnimator;

	public GameObject playerCollisionObject;
	private PlayerCollision playerCollisionScript;

	// Use this for initialization
	void Start () {
		BebitteAnimator = BebitteMesh.GetComponent<Animator>();
		playerCollisionScript = playerCollisionObject.GetComponent<PlayerCollision>();
	}
	
	// Update is called once per frame
	void Update () {

		if (isActive == false) return;

		Vector3 input = Vector3.zero;
		if (playerCollisionScript.isDead == false)
		{
			input.x = Input.GetAxis("Horizontal");
			input.z = Input.GetAxis("Vertical");
		}

		Vector3 slopeForce = Vector3.zero;
		RaycastHit hit;
		if (Physics.Raycast(this.transform.position, -Vector3.up, out hit))
		{
			slopeForce = hit.normal;
			slopeForce.y = 0f;
		}

		Vector3 movement = Vector3.zero;
		movement += (input/*+slopeForce*/) * speed * Time.fixedDeltaTime;

		if (!isGrounded())
		{
			movement += gravity * gravityMegatron * Time.fixedDeltaTime;
		}

		this.GetComponent<CharacterController>().Move(movement);


		//rotation
		Vector3 currentVel = this.GetComponent<CharacterController>().velocity;
		if (currentVel.magnitude >= 0.05f)
		{
			direction = Vector3.Slerp(direction, currentVel, 0.1f);
			direction.y = 0f;
			direction.Normalize();

			//update anim
			BebitteAnimator.SetBool("isRunning", true);
		}
		else
		{
			//update anim
			BebitteAnimator.SetBool("isRunning", false);
		}

		this.transform.LookAt(this.transform.position + direction);


	}

	bool isGrounded()
	{
		return Physics.Raycast(this.transform.position, Vector3.down, 1.25f);
	}
}
