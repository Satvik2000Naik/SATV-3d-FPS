using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    AudioSource audioo;
    [SerializeField] AudioClip walk;
    [SerializeField] AudioClip run;

    // Start is called before the first frame update
    void Start()
    {
        audioo = GetComponent<AudioSource>();       
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKey(KeyCode.W))
        {
            if (!audioo.isPlaying)
                audioo.PlayOneShot(walk);

        }*/
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) )
        {
            if (!audioo.isPlaying)
                audioo.PlayOneShot(run);
        }
        else if(Input.GetKey(KeyCode.W))
        {
            if(!audioo.isPlaying)
                audioo.PlayOneShot(walk);
        }
        
        

        
        else
        {
            audioo.Stop();
        }
                
    }
}
