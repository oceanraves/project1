using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private string _object;
    private int _lastObject;
    private GameObject _clone;
    private GameObject _clone2;
    private GameObject _turretClone;
    private Vector3 _spawnPoint;
    private Vector3 _turretSpawnPoint;
    private float _newY;
    public float spawnRate;
    private float _counter;
    private Vector3 _lastSpawnPoint;
    //private bool _initSpawn = true;
    public bool spawn = true;
    public bool spawnTurret = false;
    private GameMaster _gameMaster;
    private float xValue;
    float inc;
    float angle = 0;
    public int state;

    private bool _sineWave;
    public bool wallMode;
    private string _wall;
    private float _timer = 3f;
    float timeStamp;
    bool conidionsSet = false;
    private bool _spawnSine = false;

    private string _pUp;


    private void Start()
    {
        inc = Mathf.PI / 15f;
        _gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        //spawnRate = _gameMaster.spawnRate;
    }
    void Update()
    {
        if (_timer <= 600f && _timer > 400f)
        {
            wallMode = true;
            _spawnSine = false;
            _timer -= 0.1f;
        }
        if (_timer <= 400f && _timer > 200f)
        {
            wallMode = false;
            _spawnSine = false;
            _timer -= 0.1f;
        }
        if (_timer < 200f && _timer > 0f)
        {
            wallMode = false;
            _spawnSine = true;
            _timer -= 0.1f;
        }
        if (_timer <= 0f)
            _timer = 600f;


        //spawnRate = 0.8f;
        if (spawn)
        {
            if (wallMode)
            {
                if (!conidionsSet)
                {
                    //WaveCounter("Wall");
                    spawnRate = 1.5f;
                    timeStamp = Time.time;
                    conidionsSet = true;
                }
                if (Time.time > timeStamp + spawnRate)
                {
                    SpawnWall();
                    conidionsSet = false;
                }
            }
            if (!wallMode)
            {
                if (!conidionsSet)
                {
                    //WaveCounter("Random");
                    spawnRate = 1.5f;
                    timeStamp = Time.time;
                    state = 1;
                    conidionsSet = true;

                }
                if (Time.time > timeStamp + spawnRate)
                {
                    SpawnRandom();
                    conidionsSet = false;
                }
            }

            if (!wallMode && _spawnSine == true)
            {
                if (!conidionsSet)
                {
                    //WaveCounter("Sine");
                    spawnRate = 0.8f;
                    timeStamp = Time.time;
                    state = 2;
                    conidionsSet = true;

                }
                if (Time.time > timeStamp + spawnRate)
                {
                    SpawnRandom();
                    conidionsSet = false;
                }
            }
        }
    }

    public void ChangeSpawnRate()
    {
        /*
        if (spawnRate >= 3f)
        {
            spawnRate -= 0.1f;
        }
        else if (spawnRate <= 0.9f)
        {
            spawnRate += 0.1f;
        }
        */
        //spawnRate = 0.8f;
        
        
        
        /*
        if (levelIs % 2 == 0)
        {
            StateSwitcher("SineWaveDouble");
        }
        else
            StateSwitcher("SawTooth");
        */

        _gameMaster.spawnRate = spawnRate;    
    }

    private void SpawnWall()
    {
        int typeOfWall;
        typeOfWall = Random.Range(0, 5);


        if (typeOfWall == 0)
        {
            _wall = "Enemy_Wall_01";
        }
        if (typeOfWall == 1)
        {
            _wall = "Enemy_Wall_02";
        }
        if (typeOfWall == 2)
        {
            _wall = "Enemy_Wall_03";
        }
        if (typeOfWall == 3)
        {
            _wall = "Enemy_Wall_04";
        }
        if (typeOfWall == 4)
        {
            _wall = "Enemy_Wall_05";
        }

        GameObject newWall = Instantiate(Resources.Load(_wall, typeof(GameObject))) as GameObject;
        newWall.transform.position = new Vector3(27f, 45f, 17f);

    }
    private void SpawnRandom()
    {
        GetSpawnPoint();

        _counter = Time.time;

        if (state == 1 || state == 2)
        {
            PickObject();
            SineWave();
        } else if (state == 0)
        {
            PickObject();
            GetSpawnPoint();
        } else if (state == 3)
        {
            SawTooth();
        }

        _clone = Instantiate(Resources.Load(_object, typeof(GameObject))) as GameObject;
        _clone.transform.position = _spawnPoint;
        _clone.AddComponent<EnemyMovement>();
        _clone.GetComponent<EnemyMovement>().SetMoveSpeed(8f);

        if (state == 2)
        {
            PickObject();
            CoSineWave();
            _clone2 = Instantiate(Resources.Load(_object, typeof(GameObject))) as GameObject;
            _clone2.transform.position = _spawnPoint;
            _clone2.AddComponent<EnemyMovement>();
            _clone2.GetComponent<EnemyMovement>().SetMoveSpeed(8f);
        }
    }
    private void GetSpawnPoint()
    {
        _newY = Random.Range(42.5f, 60f);
        
        while ((Mathf.Max(_newY, _lastSpawnPoint.y) - Mathf.Min(_newY, _lastSpawnPoint.y)) < 8f)
        {
            _newY = Random.Range(42.5f, 60f);
        }          
        _spawnPoint = new Vector3(28, _newY, 17);
        _lastSpawnPoint = _spawnPoint;
    }
    private void SineWave()
    {
        angle += inc;
        float ypos = (Mathf.Sin(angle) + 1) / 2 * 13.5f + 48.5f;
        _spawnPoint = new Vector3(28, ypos, 17);
    }
    private void CoSineWave()
    {
        angle += inc;
        float ypos = (Mathf.Cos(angle) + 1) / -4f * 13.5f + 48.5f;
        _spawnPoint = new Vector3(28, ypos, 17);
    }
    private void SawTooth()
    {

    }

    private void PickObject()
    {
        int typeOfObject = Random.Range(0, 7);

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
        if (typeOfObject == 6)
        {
            _object = "Enemy_02";
        }
        if (typeOfObject == 7)
        {
            int powerUp = Random.Range(0, 2);
            if (powerUp == 0)
            {
                _object = "Powerups_Bullet";
            }else
                _object = "Powerups_New_2";
        }
        if (_object == null)
        {
            Debug.Log("Enemy Mesh Not Found.");
        }
    }

    public void SpawnTurret(float newX)
    {

        xValue = newX;

        _turretSpawnPoint = new Vector3(xValue, -1.3f, -11.3f);
        _turretClone = Instantiate(Resources.Load("ShooterBox_0", typeof(GameObject))) as GameObject;
        _turretClone.transform.position = _turretSpawnPoint;

        GameObject _pUpClone;

        int next = Random.Range(0, 2);
        if (next == 0)
        {
            _pUp = "Powerups_Bullet";

        }
        if (next == 1)
        {
            _pUp = "Powerups_New_2";
        }

        _pUpClone = Instantiate(Resources.Load(_pUp, typeof(GameObject))) as GameObject;
        //_pUpClone.transform.SetParent(_turretClone.transform, false);
        _pUpClone.transform.parent = _turretClone.transform;
        _pUpClone.transform.position = _turretClone.transform.GetChild(0).transform.position;


        _pUpClone.transform.position += new Vector3(0f, 2f, 0f);
    }
}
