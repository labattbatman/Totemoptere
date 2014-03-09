using UnityEngine;
using System.Collections;

public class PlatformControler : MonoBehaviour 
{
    public float maxRotation = 10.0f;
    public float rotSpeed = 0.2f;

    Vector3 rot = Vector3.zero;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        //Droite
        if (Input.GetAxis("HorizontalP2") > 0.4f && this.transform.rotation.z > -maxRotation)
        {
            rot.z -= rotSpeed;
            if (rot.z < -maxRotation) rot.z = -maxRotation;
            transform.rotation = Quaternion.Euler(rot);
        }

        ////Gauche
        if (Input.GetAxis("HorizontalP2") < -0.4f && this.transform.rotation.z < maxRotation)
        {
            rot.z += rotSpeed;
            if (rot.z > maxRotation) rot.z = maxRotation;
            transform.rotation = Quaternion.Euler(rot);
        }


        //Haut
        if (Input.GetAxis("VerticalP2") > 0.4f && this.transform.rotation.x < maxRotation)
        {
            rot.x += rotSpeed;
            if (rot.x > maxRotation) rot.x = maxRotation;
            transform.rotation = Quaternion.Euler(rot);
        }

        ////Bas
        if (Input.GetAxis("VerticalP2") < -0.4f && this.transform.rotation.x > -maxRotation)
        {
            rot.x -= rotSpeed;
            if (rot.x < -maxRotation) rot.x = -maxRotation;
            transform.rotation = Quaternion.Euler(rot);

        }
	}
}
