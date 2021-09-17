using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private string _enemy;
    private GameObject _clone;
    private Vector3 _spawnPoint;
    private float _newY;
    private float _spawnRate;

    [SerializeField]
    float overallSpawnFrequency;
    [SerializeField]
    float enemy00SpawnFrequency;
    [SerializeField]
    float enemy01SpawnFrequency;
    [SerializeField]
    float enemy02SpawnFrequency;

    void Start()
    {
        StartSpawn();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartSpawn();
        }
    }

    private void StartSpawn()
    {
        _spawnRate = Random.Range(0f, 1000f);
        Debug.Log("Spawnrate: " + _spawnRate);

        for (int i = 0; i <= _spawnRate; i++)
        {
            Debug.Log("Do Over");
        }
        Debug.Log("Ready 2 Spawn");
            SpawnRandomEnemy();
    }
    private void SpawnRandomEnemy()
    {
        GetSpawnPoint();
        PickEnemy();
        _clone = Instantiate(Resources.Load(_enemy, typeof(GameObject))) as GameObject;
        _clone.transform.position = _spawnPoint;

        _clone.AddComponent<EnemyMovement>();
        _clone.GetComponent<EnemyMovement>().SetMoveSpeed(20f);

        //StartSpawn();
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
}
