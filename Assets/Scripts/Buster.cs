using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;

public class Buster : MonoBehaviour
{/*
    public GameObject bulletPrefab;
    public Transform Bulletspawn;
    public float bulletSpeed = 50f;
    public float lifeTime = 3f;*/
    [SerializeField] Camera FPCamera;
    public float range = 70f;
    [SerializeField] float damage = 30f;
     AudioSource audii;
    [SerializeField] AudioClip zombiebustersound;
    [SerializeField] float fireRate = 15f;
    private float nextTimeToFire = 0f;
    [SerializeField] ParticleSystem zombiemuzzle;
    // Start is called before the first frame update
    void Start()
    {
        audii = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
           // nextTimeToFire = Time.time + 1f / fireRate;

            Fire();
          //  zombiemuzzle.Play();
            if (!audii.isPlaying)
            {
                audii.PlayOneShot(zombiebustersound);
            }
        }
        else
        {
           // zombiemuzzle.Stop();
            audii.Stop();
        }
    }

    void Fire()
    {
        
        // throw new NotImplementedException();
        /*  GameObject bullet = Instantiate(bulletPrefab);
          bullet.transform.position = Bulletspawn.position;
          //bullet.transform.forward = Bulletspawn.transform.forward;

          Vector3 rotation = bullet.transform.rotation.eulerAngles;

          bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);

          bullet.GetComponent<Rigidbody>().AddForce(Bulletspawn.forward * bulletSpeed, ForceMode.*//*Impulse);*/


        RaycastHit hit;


        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            //CreateImpactHit(hit);
            //Debug.Log("I hit this thing: " + hit.transform.name);
          ZombieHl target = hit.transform.GetComponent<ZombieHl>();
            //ZombieHL zombieTarget = hit.transform.GetComponent<ZombieHL>();
            if (target != null)
                target.TakingDamage(damage);
            /*if (zombieTarget != null)
               zombieTarget.TakingDamage(damage);*/

        }
        else
        {
            return;
        }
    }


    /* private IEnumerator DestroyBulletsAfterTime(GameObject bullet, float delay)
     {
         yield return new WaitForSeconds(delay);
         Destroy(bullet);
     }*/
}
