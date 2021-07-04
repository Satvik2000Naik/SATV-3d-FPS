using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSound : MonoBehaviour
{
    AudioSource audii;
    //[SerializeField] AudioClip zombiehit;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Zombie")
        {
            //audii.PlayOneShot(zombiehit);
            audii.Play();
        }
    }
}
