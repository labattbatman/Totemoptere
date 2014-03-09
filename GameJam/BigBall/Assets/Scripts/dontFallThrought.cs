using UnityEngine;
using System.Collections;

public class dontFallThrought : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay (Collider other)
	{
		if (other.tag == "Player")
		{
			other.transform.parent = gameObject.transform;
			//Vector3 pos = other.transform.localPosition;
			//if (pos.y < -2f)
			//	pos.y = 0.75f;
			//other.transform.localPosition = pos;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.tag == "Player")
			other.transform.parent = null;
	}
}
