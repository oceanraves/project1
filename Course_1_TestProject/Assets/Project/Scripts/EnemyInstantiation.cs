using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiation : MonoBehaviour
{
    private Vector3 _spawnPoint;
    private float _xSpawn;
    private float _ySpawn;
    private float _zSpawn;

    private GameObject _clone;
    private Object _enemy0;
    private Object _enemy1;
    private Object _enemy2;


    void Start()
    {
        _enemy2 = Resources.Load("Enemy_02");
    }

    void Update()
    {        
    }

    private void SetSpawnPoint()
    {
        _zSpawn = Random.Range(8f, -5.4f);
        _spawnPoint = new Vector3(20f, 36f, _zSpawn);
    }

    private void SpawnEnemy()
    {
        SetSpawnPoint();
        //_clone = Instantiate(_enemy0, _spawnPoint, Quaternion.identity);
    }

}
