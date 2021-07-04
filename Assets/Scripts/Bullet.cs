using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private float i = 0f;
    private Transform player;
    public GameObject PLAYER;
   
    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        print("hit" + other.name);
        Destroy(gameObject);
    }
    /* void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player") 
        {
            Destroy(collision.gameObject);
          
        }
    }*/

   
}
