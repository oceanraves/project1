using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    public bool fromPlayer;
    private AudioHandler _audioHandler;

    private void Start()
    {
        _audioHandler = GameObject.Find("AudioHandler").GetComponent<AudioHandler>();
    }
    private void OnTriggerEnter(Collider boundary)
    {
        if (boundary.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }

        if (boundary.gameObject.tag == "Projectile")
        {
            GameObject bullet = gameObject;
            EnemySpawner enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
            enemySpawner.SpawnExplosion(bullet.transform.position, "Bullet");
            _audioHandler.Play("LazerExplode");

            Destroy(gameObject);
        }
    }    
}
