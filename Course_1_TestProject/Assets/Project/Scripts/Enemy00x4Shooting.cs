using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy00x4Shooting : MonoBehaviour
{
    [SerializeField]
    GameObject enemyBullet;

    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;
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
        if (Time.time > nextFire && firePoint1 != null && firePoint2 != null && firePoint3 != null && firePoint4 != null)
        {
            GameObject eBullet = Instantiate(enemyBullet, firePoint1.position, firePoint1.rotation);
            GameObject eBullet1 = Instantiate(enemyBullet, firePoint2.position, firePoint2.rotation);
            GameObject eBullet2 = Instantiate(enemyBullet, firePoint3.position, firePoint3.rotation);
            GameObject eBullet3 = Instantiate(enemyBullet, firePoint4.position, firePoint4.rotation);
            Rigidbody rb = eBullet.GetComponent<Rigidbody>();
            Rigidbody rb1 = eBullet1.GetComponent<Rigidbody>();
            Rigidbody rb2 = eBullet2.GetComponent<Rigidbody>();
            Rigidbody rb3 = eBullet3.GetComponent<Rigidbody>();
            rb.AddForce(firePoint1.right * bulletForce, ForceMode.Impulse);
            rb1.AddForce(firePoint2.right * bulletForce, ForceMode.Impulse);
            rb2.AddForce(firePoint3.right * bulletForce, ForceMode.Impulse);
            rb3.AddForce(firePoint4.right * bulletForce, ForceMode.Impulse);
            nextFire = Time.time + fireRate;
        }
    }
}
