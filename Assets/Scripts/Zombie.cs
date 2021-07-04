using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Transform target;
    // public GameObject Player;
    float distanceToTarget = Mathf.Infinity;
    public float chaseRange = 8f;
    public float speed = 5f;
    public float attackrange = 4f;
    AudioSource audii;
    [SerializeField] AudioClip zombiehit;



    [SerializeField] float turnspeed = 5f;
    [SerializeField] float health;
    private float maxHealth = 100f;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        FaceTarget();
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);



    }


    private void FaceTarget()
    {
        //throw new NotImplementedException();
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnspeed);

    }

    //[SerializeField] AudioClip zombiehit;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            //audii.PlayOneShot(zombiehit);
            audii.PlayOneShot(zombiehit);
        }
    }
}
