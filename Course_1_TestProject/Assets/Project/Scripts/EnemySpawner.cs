using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private string _enemy;
    private GameObject _clone;
    private Vector3 _spawnPoint;
    private float _newY;
    public float spawnRate;
    private float _counter;
    private Vector3 _lastSpawnPoint;
    private bool _initSpawn = true;
    public bool spawn = true;
    private GameMaster _gameMaster;

    private void Start()
    {
        _gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        spawnRate = _gameMaster.spawnRate;
    }


    void Update()
    {
        //TEMP FUNCTION FOR TESTING
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SpawnRandomEnemy();
        }

        if (spawn && Time.time > _counter + spawnRate)
        {
            //GetSpawnFrequency();
            SpawnRandomEnemy();
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
        _initSpawn = false;
    }
    private void GetSpawnPoint()
    {
        if (_initSpawn)
        {
            _newY = Random.Range(42.5f, 63f);
        }
        else
        {
            float lastPlus = _lastSpawnPoint.y + 5f;
            float lastMinus = _lastSpawnPoint.y - 5f;

            float nextOneMin = Random.Range(42f, lastMinus);
            float nextOneMax = Random.Range(lastPlus, 64f);
            //
            int upOrDown = Random.Range(0, 2);
            //
            if (upOrDown == 0)
            {
                _newY = nextOneMin;
            }
            else
            {
                _newY = nextOneMax;
            }
        }
        _spawnPoint = new Vector3(26, _newY, 17);
        _lastSpawnPoint = _spawnPoint;
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
