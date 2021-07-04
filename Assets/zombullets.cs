using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombullets : MonoBehaviour
{
    public float speed = 9f;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // transform.position += transform.forward * speed * Time.deltaTime;
    }
}
