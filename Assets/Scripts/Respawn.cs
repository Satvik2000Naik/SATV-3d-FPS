using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] GameObject Ene2;
    [SerializeField] GameObject Ene3;
    [SerializeField] GameObject Ene4;
    [SerializeField] GameObject Ene5;
    [SerializeField] GameObject Ene6;
    [SerializeField] GameObject Ene7;
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
            Ene2.SetActive(true);
            Ene3.SetActive(true);
            Ene4.SetActive(true);
            Ene5.SetActive(true);
            Ene6.SetActive(true);
            Ene7.SetActive(true);
        }
        else
        {
            //Ene.SetActive(false);
        }
        
    }
}
