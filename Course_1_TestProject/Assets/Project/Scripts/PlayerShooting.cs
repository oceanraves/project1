using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint2;
    public GameObject bulletPrefab;
    public float bulletForce;

    public void Shoot()
    {
        GameObject bullet =Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject bullet1= Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        bullet.GetComponent<Bullet>().fromPlayer = true;
        bullet1.GetComponent<Bullet>().fromPlayer = true;

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        Rigidbody rb1 = bullet1.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode.Impulse);
        rb1.AddForce(firePoint.right * bulletForce, ForceMode.Impulse);
    }
}
