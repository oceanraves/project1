using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01Shooting : MonoBehaviour
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
        if (Time.time > nextFire && firePoint1 != null && firePoint2!= null)
        {
            GameObject eBullet1 = Instantiate(enemyBullet, firePoint1.position, firePoint1.rotation);
            GameObject eBullet2 = Instantiate(enemyBullet, firePoint2.position, firePoint2.rotation);
            Rigidbody rb1 = eBullet1.GetComponent<Rigidbody>();
            Rigidbody rb2 = eBullet2.GetComponent<Rigidbody>();
            rb1.AddForce(firePoint1.right * bulletForce, ForceMode.Impulse);
            rb2.AddForce(firePoint2.right * bulletForce, ForceMode.Impulse);
            nextFire = Time.time + fireRate;
        }
    }
}
