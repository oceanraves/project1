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

    public Transform player;
    public float moveSpeed = 6f;
    public float distanceFromTarget = 3f;


    void Start()
    {
        nextFire = Time.time;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckFire();

        Vector3 distance = player.position - transform.position;
        Vector3 direction = distance.normalized;
        Vector3 velocity = direction * moveSpeed;

        float distanceToTarget = distance.magnitude;

        if (distanceToTarget > distanceFromTarget)
        {

            transform.Translate(velocity * Time.deltaTime);


        }
    }

    void CheckFire()
    {
        if (Time.time > nextFire && firePoint != null)
        {
            GameObject eBullet = Instantiate(enemyBullet, firePoint.position, firePoint.rotation);
            Rigidbody rb = eBullet.GetComponent<Rigidbody>();
            rb.AddForce(firePoint.right * bulletForce, ForceMode.Impulse);
            nextFire = Time.time + fireRate;
        }
    }
}
