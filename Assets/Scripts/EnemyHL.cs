using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHL : MonoBehaviour
{
    [SerializeField] ParticleSystem blood;
    [SerializeField] GameObject gate1;
    [SerializeField] GameObject gate2;
    // Start is called before the first frame update
    [SerializeField] float hitpoints = 120f;
    public void TakingDamage(float damage)
    {
        blood.Play();
        hitpoints -= damage;
        if(hitpoints<=0)
        {
            Destroy(gameObject);
            gate1.SetActive(false);
            gate2.SetActive(false);
        }
    } 
}
