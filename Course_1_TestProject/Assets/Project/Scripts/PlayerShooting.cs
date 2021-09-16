using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint2;
    public GameObject bulletPrefab;
    private AudioHandler _audioHandler;

    public float bulletForce;

    void Start()
    {
        _audioHandler = GameObject.Find("AudioHandler").GetComponent<AudioHandler>();
    }
    // Update is called once per frame
    void Update()  
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            _audioHandler.Play("Lazer_1");
        }
    }

    void Shoot()
    {
        GameObject bullet =Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject bullet1= Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        Rigidbody rb1 = bullet1.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode.Impulse);
        rb1.AddForce(firePoint.right * bulletForce, ForceMode.Impulse);
    }
}
