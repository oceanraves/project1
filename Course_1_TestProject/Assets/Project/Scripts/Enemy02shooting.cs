using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02shooting : MonoBehaviour
{
    [SerializeField]
    GameObject enemyBullet;

    public Transform firePoint;
    public float bulletForce;
    public float fireRate = 1f;
    float nextFire;

    public bool isDead = false;


    void Start()
    {
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            CheckFire();
        }
    }

    void CheckFire()
    {
        if (Time.time > nextFire && firePoint != null)
        {
            GameObject eBullet = Instantiate(enemyBullet, firePoint.position, firePoint.rotation);
            Rigidbody rb = eBullet.GetComponent<Rigidbody>();
            eBullet.GetComponent<Bullet>().fromPlayer = false; //tags enemy bullet
            rb.AddForce(firePoint.right * bulletForce, ForceMode.Impulse);
            nextFire = Time.time + fireRate;
        }
    }
}
