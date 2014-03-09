using UnityEngine;
using System.Collections;

public class trigger : MonoBehaviour {

	public AudioClip crashSound;
	private AudioSource crashSource;
	public float velocityLost = 0.5f;

	// Use this for initialization
	void Start () {

		crashSource = (AudioSource)gameObject.AddComponent("AudioSource");
		crashSource.clip = crashSound;
		crashSource.volume = 0.5f;
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter ()
	{
		Debug.Log ("ca marche");
		if(collider.transform.tag == "RedWall" || collider.transform.tag == "GreenWall" || collider.transform.tag == "BlueWall")
		{
			if(collider.transform.tag.Contains("Wall") && !collider.transform.tag.Contains (rigidbody.transform.tag)) 
			{
				crashSource.Play();
				Destroy(collider.transform.gameObject);
				rigidbody.velocity = rigidbody.velocity * velocityLost;
			}
		}
	}


}
