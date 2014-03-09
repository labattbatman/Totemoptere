using UnityEngine;
using System.Collections;

public class IntroRotateCamera : MonoBehaviour {

	public GameObject cam;
/* 	public GameObject totem1;
	public GameObject totem2;
	public GameObject totem3;
	public GameObject totem4;
	public GameObject totem5; */
	public GameObject player;
	public GameObject plat;
	public GameObject ball;
	
	private Transform lookAtTarget;
	private Vector3 v_ori_look;
	private Quaternion q_ori_look;

	
	private float saved_time = 0.0f;
	private Vector3 dir = Vector3.up;
	private float x_speed = 30.0f;
	private float y_speed = 10.0f;
	private float rotate_time = 2.0f;
	
	private float trans_time = 0.0f;
	private float max_trans_time = 1.3f;
	
	private bool isPlaying = false;
	private bool doTranslate = false;
	
	void Start () {
	
	    // on enregistre la position de depart de la camera
		v_ori_look = cam.transform.position;
		q_ori_look = cam.transform.rotation;
		
	
		// deplacement de la camera
		cam.transform.position = new Vector3 (0.0f, 3.0f, -10.0f);
		cam.transform.rotation = Quaternion.Euler(350, 0, 0);
		
		
		
		// desactivation de script
		cam.GetComponent<Gui>().enabled = false;
/* 		totem1.GetComponent<TotemBody>().enabled = false;
		totem2.GetComponent<TotemBody>().enabled = false;
		totem3.GetComponent<TotemBody>().enabled = false;
		totem4.GetComponent<TotemBody>().enabled = false;
		totem5.GetComponent<TotemBody>().enabled = false; */
		plat.GetComponent<PlatformControler>().enabled = false;
		ball.rigidbody.useGravity = false;
		player.GetComponent<PlayerMove>().enabled = false;

		
	}
	

	void Update () {
	
		if(saved_time >= rotate_time){
			isPlaying = true;
			//cam.transform.position = v_ori_look;
			//cam.transform.rotation = q_ori_look;
			
			transform.position = Vector3.MoveTowards(cam.transform.position, v_ori_look, 0.3f);
			transform.rotation = Quaternion.RotateTowards(cam.transform.rotation, q_ori_look, 50 * Time.deltaTime);
			trans_time += Time.deltaTime;
			
			//doTranslate = true;
			
			if (trans_time >= max_trans_time){
			// activation de script
			cam.GetComponent<Gui>().enabled = true;
/* 			totem1.GetComponent<TotemBody>().enabled = true;
			totem2.GetComponent<TotemBody>().enabled = true;
			totem3.GetComponent<TotemBody>().enabled = true;
			totem4.GetComponent<TotemBody>().enabled = true;
			totem5.GetComponent<TotemBody>().enabled = true; */
			plat.GetComponent<PlatformControler>().enabled = true;
			ball.rigidbody.useGravity = true;
			player.GetComponent<PlayerMove>().enabled = true;
		}
			

		}
	
		
	
	
		if(!isPlaying){
			if(saved_time <= rotate_time){
				saved_time += Time.deltaTime;
				transform.RotateAround(Vector3.zero, Vector3.up, x_speed * Time.deltaTime );
				transform.Translate(dir * y_speed * Time.deltaTime);
			}
			
		}

	}
}
