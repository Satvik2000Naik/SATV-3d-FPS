using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadWEAP : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform Bulletspawn;
    public float bulletSpeed = 50f;
    public float lifeTime = 3f;
    public float TIme = 2f;
    public Transform Player;
   // [SerializeField] float stoppingDistance = 3f;
    //[SerializeField] float speed;
    //Rigidbody rigidBody;
    [SerializeField] float timeBtwShots;
    [SerializeField] float starttimeBtwShots;


    // Start is called before the first frame update
    void Start()
    {
        //rigidBody = GetComponent<Rigidbody>();
        //Player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = starttimeBtwShots;


    }

    // Update is called once per frame
    void Update()
    {
        /*if (Vector3.Distance(transform.position, Player.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        }*/
        if (timeBtwShots <= 0)
        {
            Fire();
            timeBtwShots = starttimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }



    }


    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab);

        Physics.IgnoreCollision(bullet.GetComponent<Collider>(),
            Bulletspawn.parent.GetComponent<Collider>());

        bullet.transform.position = Bulletspawn.position;

        Vector3 rotation = bullet.transform.rotation.eulerAngles;

        bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);

        bullet.GetComponent<Rigidbody>().AddForce(Bulletspawn.forward * bulletSpeed, ForceMode.Impulse);

        StartCoroutine(DestroyBulletsAfterTime(bullet, lifeTime));

        print("Hit" + name);
    }

    private IEnumerator DestroyBulletsAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
