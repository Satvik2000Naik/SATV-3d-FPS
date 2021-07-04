using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] float Tim = 1f;
    [SerializeField] float forw= 1f;
    //Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
       // rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Tim += Time.deltaTime;
        if(Tim >= 4f)
        {
            transform.Translate(Vector3.back);
        }
        //Invoke("Boarding()" ,2f);
        
    }

    private void Boarding()
    {
        transform.Translate(Vector3.back *forw *Time.deltaTime);
    }



    /*  private void OnCollisionEnter(Collision collision)
      {
          if (collision.gameObject.tag == "Player")
          {
              transform.Translate(Vector3.back);
          }
      }*/
}


