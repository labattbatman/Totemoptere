using UnityEngine;
using System.Collections;

public class HitSoundTest : MonoBehaviour 
{
    public AudioClip hitSound;
    private AudioSource hitSource;

    public AudioClip crashSound;
    private AudioSource crashSource;

    //public GameObject hitSound;

	// Use this for initialization
	void Start () 
    {
        hitSource = (AudioSource)gameObject.AddComponent("AudioSource");
        hitSource.clip = hitSound;

        crashSource = (AudioSource)gameObject.AddComponent("AudioSource");
        crashSource.clip = crashSound;
        crashSource.volume = 0.5f;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        
	}

    //void OnCollisionEnter(Collision collision) 
    //{
    //    if(collision.transform.name == "Armadillo")
    //    {
    //        hitSound.GetComponent<ball>().playHitSound();
    //    }
    //}

    public void playHitSound()
    {
        hitSource.Play();
    }

    public void playCrashSound()
    {
        crashSource.Play();
    }
}
