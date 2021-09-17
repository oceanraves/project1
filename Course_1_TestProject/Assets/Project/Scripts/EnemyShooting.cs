using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    GameObject enemyBullet;

    public Transform firePoint1;
    public Transform firePoint2;
    public float bulletForce;
    public float fireRate = 1f;
    float nextFire;
   
    void Start()
    {
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CheckFire();
    }

    void CheckFire()
    {
        if(Time.time > nextFire)
        {
            GameObject eBullet = Instantiate(enemyBullet, firePoint1.position, firePoint1.rotation);
            GameObject eBullet1 =Instantiate(enemyBullet, firePoint2.position, firePoint2.rotation);
            Rigidbody rb = eBullet.GetComponent<Rigidbody>();
            Rigidbody rb1 = eBullet1.GetComponent<Rigidbody>();
            rb.AddForce(firePoint1.right * bulletForce, ForceMode.Impulse);
            rb1.AddForce(firePoint2.right * bulletForce, ForceMode.Impulse);
            nextFire = Time.time + fireRate;
        }
    }
}
