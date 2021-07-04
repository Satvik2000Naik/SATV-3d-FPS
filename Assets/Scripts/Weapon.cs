using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    public float range = 70f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] ParticleSystem bulletTracer;
    [SerializeField] GameObject hiteffect;
    AudioSource audi;
    [SerializeField] AudioClip mainAudio;
    [SerializeField] AudioClip reloadAudio;
    //[SerializeField] float impactForce = 30f;
    [SerializeField] int maxAmmo = 10;
    private int currentAmmo;
    public float ReloadTime = 2f;
    private bool isReloading = false;
    public float reloadTime = 1f;
    public Animator animator;
    [SerializeField] float fireRate = 15f;
    private float nextTimeToFire = 0f;
    //public REcoil RecoilObject;
    


    private void Start()
    {
        audi = GetComponent<AudioSource>();
        currentAmmo = maxAmmo;
       // originalRotation = transform.localEulerAngles;

    }
    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    void Update()
    {
        if (isReloading)
            return;
        if(currentAmmo <= 0)
        {
            StartCoroutine( Reload());
            return;
        }
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            if (!audi.isPlaying)
            {
                audi.PlayOneShot(mainAudio);
            }
            Shoot();
            //
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            audi.Stop();
            
            
            
            
            //StopRecoil();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        
        
            
        
        animator.SetBool("Reloading", true);
        if (audi.isPlaying == true)
        {
            audi.Stop();
            audi.PlayOneShot(reloadAudio);
        }

        //Debug.Log("Reloading");
        yield return new WaitForSeconds(reloadTime);
        animator.SetBool("Reloading", false);
        currentAmmo = maxAmmo;
        isReloading = false;
    }

     void Shoot()
    {
        playMuzzleFlash();
        //playBullettracer();       // RecoilObject.recoil += 0.1f;
         //AddRecoil();
        //StopRecoil();


        currentAmmo--;
        
        ProcessRaycast();


    




    }

   /* private void playBullettracer()
    {
        //throw new NotImplementedException();
        bulletTracer.Play();
    }*/

    private void playMuzzleFlash()
    {
        muzzleFlash.Play();
    }

     void ProcessRaycast()
    {
        RaycastHit hit;


        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            //CreateImpactHit(hit);
            //Debug.Log("I hit this thing: " + hit.transform.name);
            EnemyHL target = hit.transform.GetComponent<EnemyHL>();
            //ZombieHL zombieTarget = hit.transform.GetComponent<ZombieHL>();
            if (target != null)
                target.TakingDamage(damage);
           /* if (zombieTarget != null)
                zombieTarget.TakingDamage(damage);
*/
        }
        else
        {
            return;
        }
    }

    /*private void CreateImpactHit(RaycastHit hit)
    {
        // throw new NotImplementedException();
        GameObject impact = Instantiate(hiteffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1);



    }*/
    /*private void AddRecoil()
    {
        transform.localEulerAngles += upRecoil;
    }
    private void StopRecoil()
    {
        transform.localEulerAngles = originalRotation;
    }*/

}