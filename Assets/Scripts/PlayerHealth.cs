using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour
{
    public Transform Enem;
    // Start is called before the first frame update
    [SerializeField] float health;
    private float maxHealth = 100f;
    //[SerializeField] GameObject bullet;
    //[SerializeField] GameObject pllayer;
    //private int i=0;
    //public Image currentHealthBar;
    //public Text ratiotext;
    public Image healthbar;
    RigidbodyFirstPersonController fpsController;
    [SerializeField] Camera fpsCamera;
    [SerializeField] Canvas train1Canvas;
    [SerializeField] Canvas train2Canvas;
    [SerializeField] Canvas train3Canvas;
    [SerializeField] Canvas train4Canvas;
    [SerializeField] Canvas train5Canvas;
    [SerializeField] Canvas train6Canvas;
    AudioSource audi;
   [SerializeField]  AudioClip healthaudi;
    [SerializeField]   AudioClip hitaudi;
    //[SerializeField] AudioClip wind;
    [SerializeField] float liftSpeed = 2f;
    [SerializeField] float boardspeed = 20f;
    // [SerializeField] AudioClip finishsong;
    float distanceTozombie = Mathf.Infinity;
     public Transform zombie;
    [SerializeField] AudioClip zombiehit;


    private void Start()
    {
        health = maxHealth;
        fpsController = GetComponent<RigidbodyFirstPersonController>();
      audi = GetComponent<AudioSource>();
        train1Canvas.enabled = false;
        train2Canvas.enabled = false;
        train3Canvas.enabled = false;
        train4Canvas.enabled = false;
        train5Canvas.enabled = false;
        train6Canvas.enabled = false;

        zombie = GameObject.FindGameObjectWithTag("Player").transform;
    }
 
    public void UpdateHealth()
    {
        healthbar.fillAmount = health / maxHealth;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
        distanceTozombie = Vector3.Distance(zombie.position, transform.position);
        if(distanceTozombie <=2f)
        {
          
            Attack();
        }
    }

    private void Attack()
    {
        //throw new NotImplementedException();
        Invoke("health -= 40f" ,1f);
        UpdateHealth();
        if (health <= 0)
        {
            Destroy(gameObject);
            GetComponent<DeathHandler>().HandleDeath();
        }
        else
            return;

    }

    void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Bullets")
        {
            //i++;
           
           // audi.PlayOneShot(hitaudi);
            health -= 40f;
            UpdateHealth();
            if (health <= 0)
            {
                Destroy(gameObject);
                GetComponent<DeathHandler>().HandleDeath();
            }
            else
                return;
               
            //Destroy(gameObject);
            
        }

      



        if (collision.gameObject.tag == "health")
        {
           // audi.PlayOneShot(healthaudi);
            if(health<=60)
                health += 40;
            else
            {
                health = maxHealth;
            }
            Destroy(collision.gameObject);
            UpdateHealth();
        }
        if(collision.gameObject.tag == "Finish")
        {
           audi.Play();
           // while(!audi.isPlaying)*/
                GetComponent<NextHandler>().HandleNext();
            //if(!audi.isPlaying)
            //{
              
            //}
        }
        if(collision.gameObject.tag == "Fire")
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
       /* if (collision.gameObject.tag == "Board")
        {
            collision.gameObject.transform.Translate(Vector3.back * boardspeed * Time.deltaTime);
        }*/
        if (collision.gameObject.tag == "Lift")
        {
            collision.gameObject.transform.Translate(Vector3.down * Time.deltaTime * liftSpeed);
        }

        if(collision.gameObject.tag == "healthsound")
        {
            audi.PlayOneShot(healthaudi);
        }
        if(collision.gameObject.tag == "Zombie")
        {
            audi.PlayOneShot(zombiehit);
            health -= 40f;
            UpdateHealth();
            if (health <= 0)
            {
                Destroy(gameObject);
                GetComponent<DeathHandler>().HandleDeath();
            }
            else
                return;

        }

       /*if(collision.gameObject.tag == "Air")
        {
            audi.PlayOneShot(wind);
        }*/

        else if(collision.gameObject.tag == "train1")
        {
            train1Canvas.enabled = true;
           

        }
        else if(collision.gameObject.tag == "train2")
        {
            train2Canvas.enabled = true;
        }

        else if (collision.gameObject.tag == "train3")
        {
            train3Canvas.enabled = true;
        }
        else if(collision.gameObject.tag == "train4")
        {
            train4Canvas.enabled = true;
        }
        else if (collision.gameObject.tag == "train5")
        {
            train5Canvas.enabled = true;
        }
        else if (collision.gameObject.tag == "train6")
        {
            train6Canvas.enabled = true;
        }


        else
        {
            train1Canvas.enabled = false;
            train2Canvas.enabled = false;
            train3Canvas.enabled = false;
            train4Canvas.enabled = false;
            train5Canvas.enabled = false;
            train6Canvas.enabled = false;
        }
    }
    


   

    /* public void TakeDamag()
     {
         Destroy(gameObject);
     }*/
    /*  private void OnCollisionEnter(Collision collision)
      {
          if(collision.gameObject.tag == "Finish")
          {
              Destroy(Player);
          }
      }
  */
    /* private void OnCollisionEnter(Collision collision)
     {
         if(collision.gameObject.tag == "Bullets")
         {
             health -= 10f;
             if(health <= 0f)
             {
                 Die();
             }
         }
     }*/



    private void Die()
    {
        //throw new NotImplementedException();
        Destroy(gameObject);
    }
}
