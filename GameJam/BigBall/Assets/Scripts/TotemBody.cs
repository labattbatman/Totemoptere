using UnityEngine;
using System.Collections;

public class TotemBody : MonoBehaviour 
{

	private float gravity = 10.0f;
	private float yVelocity = 0.0f;
	
	public Vector3 dir = Vector3.zero;
	
	public bool isGrounded = false;
	public bool isPlaced = false;
	
	private float floor_height = -3.5f;
	public float body_height = 2f;
	public float height;

	public float bouncingForce = 1000f;

    public GameObject crashSound;
	
	void FixedUpdate () 
    {
		float h = transform.parent.GetComponent<Totem>().HEIGHT;

		//hauteur du prochain body a placer
		height = floor_height + body_height + h * (body_height * 3) +2;
		
	
		if(transform.position.y <= height)
        {
			isGrounded = true;
			yVelocity = 0.0f;
		}
	
		if(isGrounded && !isPlaced)
        {
			isPlaced = true;
			transform.parent.GetComponent<Totem>().HEIGHT += 1;
			
			GameObject floor = GameObject.FindGameObjectWithTag("Ground");
			dir = floor.transform.up;
			dir *= height;
			transform.position = dir; 
			
			
/*  		pos = floor.transform.position;
			pos.y += height;
			transform.position = pos;  */
			
			//transform.Translate(0, height, 0);
			
		    /*
			dir = Vector3.up;
			dir *= height;
			transform.position = dir;  */
		}
		
		if(!isGrounded)
        {
			yVelocity -= gravity * Time.deltaTime;
			transform.Translate(0, yVelocity * Time.deltaTime, 0);
		}
	}


	void OnCollisionEnter(Collision collision) 
	{
		if(collision.transform.name == "Armadillo" && collision.transform.tag != "White" && !this.transform.parent.GetComponent<Totem>().isBodyDead)
		{
            crashSound.GetComponent<HitSoundTest>().playCrashSound();

			this.transform.parent.GetComponent<Totem>().killBodyTotem();

			Vector3 vect = (collision.transform.position - transform.position);
			vect = vect.normalized;
			collision.rigidbody.AddForce(vect * bouncingForce);

			this.transform.parent.GetComponent<Totem>().isBodyDead = true;

			print ("HIIIIIIT");
		}
	}
}