using UnityEngine;
using System.Collections.Generic;

public class ressourcesSpawner : MonoBehaviour {

	public int CompteurRessource = 0;
	float Timer = 3f;
	public GameObject RedRessource;
	public GameObject GreenRessource;
	public GameObject BlueRessource; 
	public GameObject SpawnPoint;
	private GameObject Ressource;
	public List<GameObject> SpawnPoints;

    public AudioClip getSound;
    private AudioSource getSource;

	// Use this for initialization
	void Start () 
	{
		//SpawnPoints = new List<GameObject>();

		for(int i = 0; i<8; i=i+2)
		{
			int randSpawn = Random.Range(0,SpawnPoints.Count);
			int rand = Random.Range(0,3);
			Vector3 spawnPos = SpawnPoints[i].transform.position + new Vector3(0,1.2f,0);
			if(rand == 0)
				Ressource = (GameObject)Instantiate(RedRessource,spawnPos, transform.rotation);
			else if (rand == 1)
				Ressource = (GameObject)Instantiate(BlueRessource,spawnPos, transform.rotation);
			else
				Ressource = (GameObject)Instantiate(GreenRessource,spawnPos, transform.rotation);

			CompteurRessource++;
			Ressource.transform.parent = GameObject.FindGameObjectWithTag("Ground").transform;

            getSource = (AudioSource)gameObject.AddComponent("AudioSource");
            getSource.clip = getSound;
            getSource.volume = 0.5f;
		}

	}
	// Update is called once per frame
	void FixedUpdate () {



		if(CompteurRessource<4)
		{
			Timer -= Time.deltaTime;
		}

		if(Timer < 0)
			createRessource();
		
	}
	
	void createRessource()
	{
		print ("respawn");
		int randSpawn = Random.Range(0,SpawnPoints.Count);
		RaycastHit hit;


		if(!Physics.Raycast(SpawnPoints[randSpawn].transform.position,Vector3.up,out hit,2.0f))
		{
			int rand = Random.Range(0,3);

			Vector3 spawnPos = SpawnPoints[randSpawn].transform.position + new Vector3(0,1.2f,0);

			if(rand == 0)
				Ressource = (GameObject)Instantiate(RedRessource,spawnPos, transform.rotation);
			else if (rand == 1)
				Ressource = (GameObject)Instantiate(BlueRessource,spawnPos, transform.rotation);
			else
				Ressource = (GameObject)Instantiate(GreenRessource,spawnPos, transform.rotation);
			
			CompteurRessource++;
			Ressource.transform.parent = GameObject.FindGameObjectWithTag("Ground").transform;
			Timer = 3f;
		}
		else 
		{
			print ("quesse qui se passe");
		}
	}

   public void PlayGetSound()
    {
        getSource.Play();
    }
	
}
