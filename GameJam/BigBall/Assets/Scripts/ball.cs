using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour {
	public float bouncingForce = 1000f;
	public float velocityLost = 0.5f;
	public Material Red;
	public Material Green;
	public Material Blue;
	public GameObject RessourceSpawner;
	public ParticleSystem dustTrail;
	public GameObject Armadillo;

    //public Texture test;

    //Audio stuff
    public AudioClip rollinSound;
    private AudioSource rollinSource;
    float Xvelo = 0.0f;
    float Zvelo = 0.0f;
    float masterVelo = 0.0f;

    //public AudioClip hitSound;
    //private AudioSource hitSource;
    public AudioClip crashSound;
    private AudioSource crashSource;

    //bool cooldownUp = false;
    //float cooldown = 20.0f;
	

	// Use this for initialization
	void Start () 
    {
        rollinSource = (AudioSource)gameObject.AddComponent("AudioSource");
        rollinSource.clip = rollinSound;

        //hitSource = (AudioSource)gameObject.AddComponent("AudioSource");
        //hitSource.clip = hitSound;

        crashSource = (AudioSource)gameObject.AddComponent("AudioSource");
        crashSource.clip = crashSound;
        crashSource.volume = 0.5f;
	}
	
	// Update is called once per frame
	void Update () 
    {
		GenerateDustTrail();
	}

	void FixedUpdate()
	{
		/*RaycastHit hit;
		if(Physics.Raycast(rigidbody.position,rigidbody.velocity.normalized,out hit,3.5f))
		{
			if(hit.transform.tag.Contains("Wall") && !hit.transform.tag.Contains (rigidbody.transform.tag)) 
			{
				Destroy(hit.transform.gameObject);
				rigidbody.velocity = rigidbody.velocity * velocityLost;
			}
		}*/

        playRollinSound();

        //if (cooldownUp)
        //{
        //    cooldown -= 1.0f;
        //    if (cooldown <= 0) 
        //    {
        //        cooldownUp = false; 
        //    }
        //}

	}

	public float radToDegree(float rad)
	{
		return rad * 180 / Mathf.PI;
	}

	public Vector3 rotateVector(float angleInRad, Vector3 theVector)
	{
		Vector3 newVector = theVector;
		newVector.x = theVector.x * Mathf.Cos(angleInRad) - theVector.y * Mathf.Sin(angleInRad);
		newVector.y = theVector.x * Mathf.Sin(angleInRad) + theVector.y * Mathf.Cos(angleInRad);
		return newVector;
	}

	public float angleBetweenTwoVector(Vector3 vectorA, Vector3 vectorB)
	{
		float angle = -Mathf.Atan2(vectorA.x*vectorB.y - vectorA.y*vectorB.x, vectorA.x*vectorB.x + vectorA.y*vectorB.y);
		return radToDegree(angle);		
	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.transform.tag == "RedWall" || collider.transform.tag == "GreenWall" || collider.transform.tag == "BlueWall")
		{
			if(collider.transform.tag.Contains("Wall") && collider.transform.tag.Contains (rigidbody.transform.tag)) 
			{
                crashSource.Play();
				Destroy(collider.transform.gameObject);
				rigidbody.velocity = rigidbody.velocity * velocityLost;
			}

		}

		if(collider.transform.tag == "Red" || collider.transform.tag == "Green" || collider.transform.tag == "Blue")
		{
			rigidbody.transform.tag = collider.transform.tag;
			if(rigidbody.transform.tag == "Red")
				Armadillo.renderer.material = Red;
            if (rigidbody.transform.tag == "Green") /*renderer.material.mainTexture = test;*/
				Armadillo.renderer.material = Green;
			if(rigidbody.transform.tag == "Blue")
				Armadillo.renderer.material = Blue;

			Destroy(collider.transform.gameObject);

			RessourceSpawner.GetComponent<ressourcesSpawner>().CompteurRessource--;
            RessourceSpawner.GetComponent<ressourcesSpawner>().PlayGetSound();
		}
	}

	void OnCollisionEnter(Collision collision) 
    {

		if(collision.transform.tag != rigidbody.transform.tag && collision.transform.tag.Contains ("Wall"))
		{
            //playHitSound();

			Vector3 vect = (collision.transform.position - rigidbody.transform.position);
			vect = vect.normalized;
			Vector3 myCollisionNormal = collision.contacts[0].normal;

			Vector3 finalVect = rotateVector (angleBetweenTwoVector(vect,myCollisionNormal),myCollisionNormal);

			rigidbody.AddForce(finalVect * bouncingForce);
		}

	}

	void GenerateDustTrail()
	{
		dustTrail.transform.position = rigidbody.transform.position;

		float speed = rigidbody.velocity.magnitude;

		if(speed<5f)
			speed = 0;

		dustTrail.particleSystem.emissionRate = speed * 1;


	}

    void playRollinSound()
    {
        //Get velocity and convert to positive value
        Xvelo = Mathf.Abs(gameObject.GetComponent<ball>().rigidbody.angularVelocity.x);
        Zvelo = Mathf.Abs(gameObject.GetComponent<ball>().rigidbody.angularVelocity.z);

        if (Xvelo > Zvelo)
        {
            masterVelo = Xvelo;
        }
        else
        {
            masterVelo = Zvelo;
        }

        rollinSource.volume = (masterVelo / 10) / 2;

        if (!rollinSource.isPlaying)
        {
            rollinSource.Play();
        }
    }

    //public void playHitSound()
    //{
    //    float localMasterVelo;

    //    //Get velocity and convert to positive value
    //    Xvelo = Mathf.Abs(gameObject.GetComponent<ball>().rigidbody.angularVelocity.x);
    //    Zvelo = Mathf.Abs(gameObject.GetComponent<ball>().rigidbody.angularVelocity.z);

    //    if (Xvelo > Zvelo)
    //    {
    //        localMasterVelo = Xvelo;
    //    }
    //    else
    //    {
    //        localMasterVelo = Zvelo;
    //    }

    //    //if (localMasterVelo >= 2.0f)
    //    //{
    //        if (!hitSource.isPlaying && cooldownUp == false)
    //        {
    //            hitSource.Play();
    //            cooldown = 20.0f;
    //            cooldownUp = true;
    //        }
    //    //}
    //}
}
		                     