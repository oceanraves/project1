using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint2;
    public GameObject bulletPrefab;
    private AudioHandler _audioHandler;
    private PlayerMovement _pMovement;

    public float bulletForce;

    void Start()
    {
        _audioHandler = GameObject.Find("AudioHandler").GetComponent<AudioHandler>();
        _pMovement = gameObject.GetComponent<PlayerMovement>();

    }

    void Update()  
    {
        if (_pMovement.playerEnabled == true && Input.GetButtonDown("Fire1") && !PauseMenu.gameIsPaused)
        {
            Shoot();
            _audioHandler.Play("Lazer_1");
        }
    }

    void Shoot()
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
