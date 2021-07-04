using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHl : MonoBehaviour
{
    [SerializeField] float hitpoin = 120f;
    [SerializeField] ParticleSystem zombieblood;
    [SerializeField] GameObject gate1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakingDamage(float damage)
    {
        zombieblood.Play();
        hitpoin -= damage;
        if (hitpoin <= 0)
        {
            Destroy(gameObject);
           gate1.SetActive(false);
            //gate2.SetActive(false);*/
        }
    }
}
