using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 2;
    public bool fromPlayer;
    private AudioHandler _audioHandler;
    private ExplosionSpawner _explosionSpawner;

    private void Start()
    {
        _audioHandler = GameObject.Find("AudioHandler").GetComponent<AudioHandler>();
        _explosionSpawner = GameObject.Find("ExplosionSpawner").GetComponent<ExplosionSpawner>();

    }
    private void OnTriggerEnter(Collider boundary)
    {
        if (boundary.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }

        if (boundary.gameObject.tag == "Projectile")
        {
            //_audioHandler.Play("LazerExplode");
            GameObject bullet = gameObject;
            ExplosionSpawner explosionSpawner = GameObject.Find("ExplosionSpawner").GetComponent<ExplosionSpawner>();
            explosionSpawner.SpawnExplosion(bullet.transform.position, "Bullet");

            Destroy(gameObject);
        }
    }    
}
