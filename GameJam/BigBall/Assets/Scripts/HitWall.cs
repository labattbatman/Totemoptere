using UnityEngine;
using System.Collections;

public class HitWall : MonoBehaviour 
{
    public AudioClip impact;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Armadillo")
        {
            audio.PlayOneShot(impact, 1.0f);
        }
    }
}
