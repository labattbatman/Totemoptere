using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	public GameObject RessourceSpawner;

	float respawnCoolDown = 1.7f;
	public bool isDead = false;
	float timeRespawn = 0f;

    public AudioClip getSound;
    private AudioSource getSource;
    public AudioClip splatSound;
    private AudioSource splatSource;

	public GameObject BebitteMesh;
	private Animator BebitteAnimator;

	// Use this for initialization
	void Start () 
    {
        getSource = (AudioSource)gameObject.AddComponent("AudioSource");
        getSource.clip = getSound;
        getSource.volume = 0.5f;

        splatSource = (AudioSource)gameObject.AddComponent("AudioSource");
        splatSource.clip = splatSound;
        splatSource.pitch = 1.5f;
        
		BebitteAnimator = BebitteMesh.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		if(isDead)
		{
			timeRespawn += Time.deltaTime;
			if(timeRespawn>respawnCoolDown)
			{
				isDead = false;
				timeRespawn = 0;
				print ("pumort");
			}
			print ("mort");
		}
	
	}

	void OnTriggerEnter(Collider collision) 
	{
		if(collision.transform.name == "Armadillo")
		{
			// Une anim cool ici
            splatSource.Play();
			isDead = true;
			print ("tesmort");
			BebitteAnimator.SetTrigger("knock");

		}

		else if(collision.transform.tag == "Red" || collision.transform.tag == "Green" || collision.transform.tag == "Blue")
		{
            getSource.Play();

			if(collision.transform.tag == "Red")
				this.transform.parent.GetComponent<CreateWall>().Rressource ++;
			if(collision.transform.tag == "Green")
				this.transform.parent.GetComponent<CreateWall>().Gressource ++;
			if(collision.transform.tag == "Blue")
				this.transform.parent.GetComponent<CreateWall>().Bressource ++;
			
			Destroy(collision.transform.gameObject);
			
			RessourceSpawner.GetComponent<ressourcesSpawner>().CompteurRessource--;
		}				
	}
}
