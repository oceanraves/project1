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

    private void Start()
    {
        inc = Mathf.PI / 15f;
        _gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        //spawnRate = _gameMaster.spawnRate;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SpawnObject();
        }

        if (spawn && Time.time > _counter + spawnRate)
        {
            SpawnObject();
        }

        if (spawnTurret)
        {
           // TurretSpawnPoint();
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
    /*
    void StateSwitcher(string state)
    {
        this.state = Random.Range(0, 4);
        if (state == "Random")
        {
            this.state = 0;
        }

        if (state == "Sinewave")
        {
            this.state = 1;
        }

        if (state == "SinewaveDouble")
        {
             this.state = 2;
        }

        if (state == "SinewaveStuttered")
        {
            LevelSystem lvlSystem = GameObject.Find("LevelSystem").GetComponent<LevelSystem>();
            if (lvlSystem.level % 2 == 0)
            {
                this.state = 2;
            }
            else
                this.state = 1;
        }

        if (state == "SawTooth")
        {
            this.state = 3;
        }
    }
    */
    private void SpawnObject()
    {
        GetSpawnPoint();
        //PickObject();

        _counter = Time.time;
        //_initSpawn = false;

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
            _clone2.GetComponent<EnemyMovement>().SetMoveSpeed(5f);
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
        int typeOfObject = Random.Range(0, 8);

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
    public void TurretSpawnPoint(int newX)
    {
        if (newX == 0)
        {
            xValue = -15.69f;
        }
        if (newX == 1)
        {
            xValue = -6.11f;
        }
        if (newX == 2)
        {
            xValue = 6.17f;
        }
        if (newX == 3)
        {
            xValue = 16.02f;
        }
        _turretSpawnPoint = new Vector3(xValue, 64.5f, 16.81f);
        SpawnTurret();
    }

    private void SpawnTurret()
    {
        _turretClone = Instantiate(Resources.Load("ShooterBox", typeof(GameObject))) as GameObject;
        _turretClone.transform.position = _turretSpawnPoint;
        spawnTurret = false;
    }

}
