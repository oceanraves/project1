using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy00x2Shooting : MonoBehaviour
{
    [SerializeField]
    GameObject enemyBullet;

    public Transform firePoint1;
    public Transform firePoint2;
    public float bulletForce;
    public float fireRate = 1f;
    float nextFire;

    public bool isDead = false;

    void Start()
    {
        nextFire = Time.time;
    }

    void Update()
    {
        if (!isDead && gameObject.transform.position.x >= -15f && gameObject.transform.position.x <= 20f)
        {
            CheckFire();
        }
    }

    void CheckFire()
    {
        if(Time.time > nextFire && firePoint1 != null && firePoint2 != null)
        {
            GameObject eBullet = Instantiate(enemyBullet, firePoint1.position, firePoint1.rotation);
            GameObject eBullet1 =Instantiate(enemyBullet, firePoint2.position, firePoint2.rotation);
            eBullet.GetComponent<Bullet>().fromPlayer = false; //tags enemy bullet
            eBullet1.GetComponent<Bullet>().fromPlayer = false; //tags enemy bullet

            Rigidbody rb = eBullet.GetComponent<Rigidbody>();
            Rigidbody rb1 = eBullet1.GetComponent<Rigidbody>();
            rb.AddForce(firePoint1.right * bulletForce, ForceMode.Impulse);
            rb1.AddForce(firePoint2.right * bulletForce, ForceMode.Impulse);
            nextFire = Time.time + fireRate;
        }
    }
}
