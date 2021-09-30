using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Turret_Shooting : MonoBehaviour
{
    [SerializeField]
    GameObject enemyBullet;

    public Transform firePoint0;
    public Transform firePoint1;
    private float bulletForce = 4;
    private float fireRate = 3f;
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
        if(Time.time > nextFire && firePoint0 != null && firePoint1 != null)
        {
            GameObject eBullet = Instantiate(enemyBullet, firePoint0.position, firePoint0.rotation);
            //GameObject eBullet1 =Instantiate(enemyBullet, firePoint1.position, firePoint1.rotation);
            eBullet.GetComponent<Bullet>().fromPlayer = false; //tags enemy bullet
            //eBullet1.GetComponent<Bullet>().fromPlayer = false; //tags enemy bullet

            eBullet.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            //eBullet1.transform.eulerAngles = new Vector3(0f, 180f, 0f);


            Rigidbody rb = eBullet.GetComponent<Rigidbody>();
            //Rigidbody rb1 = eBullet1.GetComponent<Rigidbody>();
            rb.AddForce(firePoint0.forward * bulletForce, ForceMode.Impulse);
            //rb1.AddForce(firePoint1.forward * bulletForce, ForceMode.Impulse);
            nextFire = Time.time + fireRate;
        }
    }
}
