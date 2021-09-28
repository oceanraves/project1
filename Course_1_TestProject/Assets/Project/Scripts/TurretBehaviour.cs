using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    int health = 12;
    private AudioHandler _audioHandler;
    private EnemySpawner _enemySpawner;
    private int _whichTurret;

    void Start()
    {
        _audioHandler = GameObject.Find("AudioHandler").GetComponent<AudioHandler>();
        _enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
    }

    private void OnTriggerEnter(Collider bullet)
    {

        if (bullet.gameObject.tag == "Projectile" && bullet.GetComponent<Bullet>().fromPlayer == true)
        {
            if (bullet.GetComponent<Bullet>() != null)
            {
                health -= bullet.GetComponent<Bullet>().damage;
            }
        }
        if (health <= 0)
        {
            _audioHandler.Play("EnemyExplode");

            ExplosionSpawner explosionSpawner = GameObject.Find("ExplosionSpawner").GetComponent<ExplosionSpawner>();

            Vector3 turretPosition = gameObject.transform.position;
            //turretPosition.y -= 5.62f;
            //turretPosition.z -= 4f;

            explosionSpawner.SpawnExplosion(turretPosition, "Ship");
            FindObjectOfType<ScoreDisplay>().AddScore();
            //_animator = gameObject.GetComponent<Animator>();

            CheckWhichTurret();
            _enemySpawner.TurretSpawnPoint(_whichTurret);
            Destroy(gameObject);
        }
    }

    private void CheckWhichTurret()
    {
        if(gameObject.transform.position.x == -15.69f)
        {
            _whichTurret = 0;
        }
        if (gameObject.transform.position.x == -6.11f)
        {
            _whichTurret = 1;
        }
        if (gameObject.transform.position.x == 6.17f)
        {
            _whichTurret = 2;
        }
        if (gameObject.transform.position.x == 16.02f)
        {
            _whichTurret = 3;
        }
    }
}
