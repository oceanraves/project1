using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private string _object;
    private int _lastObject;
    private GameObject _clone;
    private Vector3 _spawnPoint;
    private float _newY;
    public float spawnRate;
    private float _counter;
    private Vector3 _lastSpawnPoint;
    private bool _initSpawn = true;
    public bool spawn = true;
    private GameMaster _gameMaster;
    public float tempSpawnrate;

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
            SpawnRandomEnemy();
        }
    }

    public void ChangeSpawnRate()
    {
        spawnRate -= 0.3f;

        if (spawnRate <= 0.7f)
        {
            //Debug.Log("Way Too Much");
            spawnRate = 0.7f;
        }
        //spawnRate = tempSpawnrate;
        _gameMaster.spawnRate = spawnRate;    
    }


    private void SpawnRandomEnemy()
    {
        GetSpawnPoint();
        PickObject();
        _clone = Instantiate(Resources.Load(_object, typeof(GameObject))) as GameObject;
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
    private void PickObject()
    {
        int typeOfObject = Random.Range(0, 10);

        //if (_lastObject >= 8)
        //{
        //    PickObject();
        //}

        if (typeOfObject == 0 || typeOfObject == 1)
        {
            _object = "Enemy_00_x2";
        }
        if (typeOfObject == 2 || typeOfObject == 3)
        {
            _object = "Enemy_00_x4";
        }
        if (typeOfObject == 4 || typeOfObject == 5)
        {
            _object = "Enemy_01";
        }
        if (typeOfObject == 6 || typeOfObject == 7)
        {
            _object = "Enemy_02";
        }

        if (typeOfObject == 8)
        {
            _object = "Powerups_Bullet";
        }
        if (typeOfObject == 9)
        {
            _object = "Powerups_New_2";
        }

        if (_object == null)
        {
            Debug.Log("Enemy Mesh Not Found.");
        }

        //_lastObject = typeOfObject;
    }
}
