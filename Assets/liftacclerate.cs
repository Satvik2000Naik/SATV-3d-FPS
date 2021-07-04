using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftacclerate : MonoBehaviour
{
    [SerializeField] GameObject gate;
    [SerializeField] float upwards;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gate.transform.Translate(Vector3.up * upwards * Time.deltaTime);
        }
    }
}
