using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private string _enemy;
    private GameObject _clone;
    private Vector3 _spawnPoint;
    private float _newY;
    private int _lastRate;

    //[SerializeField]
    private float _spawnRate;

    private float _counter;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SpawnRandomEnemy();
        }

        if (Time.time > _counter + _spawnRate)
        {
            GetSpawnFrequency();
            SpawnRandomEnemy();
        }

        //Debug.Log("Spawnrate: " + _spawnRate);
    }

    private void GetSpawnFrequency()
    {
        if (Time.time < 20)
        {
            _spawnRate = 3;
        }

        if (Time.time >= 20 && Time.time < 30)
        {
            _spawnRate = 2.7f;
        }

        if (Time.time >= 30 && Time.time < 40)
        {
            _spawnRate = 2.5f;
        }

        if (Time.time >= 40 && Time.time < 50)
        {
            _spawnRate = 2.2f;
        }

        if (Time.time >= 50 && Time.time < 60)
        {
            _spawnRate = 2f;
        }

        if (Time.time >= 60 && Time.time < 70)
        {
            _spawnRate = 1.8f;
        }
    }
    private void SpawnRandomEnemy()
    {
        GetSpawnPoint();
        PickEnemy();
        _clone = Instantiate(Resources.Load(_enemy, typeof(GameObject))) as GameObject;
        _clone.transform.position = _spawnPoint;

        _clone.AddComponent<EnemyMovement>();
        _clone.GetComponent<EnemyMovement>().SetMoveSpeed(5f);

        _counter = Time.time;
    }
    private void GetSpawnPoint()
    {
        _newY = Random.Range(42.5f, 63f);
        _spawnPoint = new Vector3(26, _newY, 17);
    }
    private void PickEnemy()
    {
        int typeOfEnemy = Random.Range(0, 4);

        if (typeOfEnemy == 0)
        {
            _enemy = "Enemy_00_x2";
        }
        if (typeOfEnemy == 1)
        {
            _enemy = "Enemy_00_x4";
        }
        if (typeOfEnemy == 2)
        {
            _enemy = "Enemy_01";
        }
        if (typeOfEnemy == 3)
        {
            _enemy = "Enemy_02";
        }
        if (_enemy == null)
        {
            Debug.Log("Enemy Mesh Not Found.");
        }
    }
    public void SpawnExplosion(Vector3 position, string typeOf)
    {
        if (typeOf == "Ship")
        {
            GameObject explosion = Instantiate(Resources.Load("Explosion_0", typeof(GameObject))) as GameObject;
            explosion.transform.position = position;
            Destroy(explosion, 5f);
        }

        if (typeOf == "Bullet")
        {
            GameObject explosion = Instantiate(Resources.Load("BulletExplosion", typeof(GameObject))) as GameObject;
            explosion.transform.position = position;
            Destroy(explosion, 5f);
        }
    }
}
