using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMisslie : MonoBehaviour
{



    Transform target;
    public Rigidbody rb; 
    
    public float speed= 10f;
    public float rotateSpeed = 500f;

    private Transform bulletLocalTransform;

    public int damage = 1;
    public bool fromPlayer;
    private AudioHandler _audioHandler;
    private ExplosionSpawner _explosionSpawner;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        bulletLocalTransform = GetComponent<Transform>();
        _audioHandler = GameObject.Find("AudioHandler").GetComponent<AudioHandler>();
        _explosionSpawner = GameObject.Find("ExplosionSpawner").GetComponent<ExplosionSpawner>();
    }

    void FixedUpdate()
    {
        rb.velocity = bulletLocalTransform.forward * speed;
        var bulletTargetRotation = Quaternion.LookRotation(target.position - bulletLocalTransform.position);
        rb.MoveRotation(Quaternion.RotateTowards(bulletLocalTransform.rotation, bulletTargetRotation, rotateSpeed));
    }

    private void OnTriggerEnter(Collider boundary)
    {
        if (boundary.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }

        if (boundary.gameObject.tag == "Projectile")
        {
            _audioHandler.Play("LazerExplode");
            _explosionSpawner.SpawnExplosion(gameObject.transform.position, "Bullet");

            Destroy(gameObject);
        }
    }
}
