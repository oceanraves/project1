using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    private string _object;

    private float _newY;
    //public bool spawn = true;
    public float spawnRate = 1f;
    private float _counter;
    private GameObject _clone;
    private Vector3 _spawnPoint;

    void Start()
    {

    }

    void Update()
    {
        if (Time.time > _counter + spawnRate)
        {
            SpawnPowerUp();
        }
    }

    private void SpawnPowerUp()
    {
        GetSpawnPoint();
        ChooseObject();
        _clone = Instantiate(Resources.Load(_object, typeof(GameObject))) as GameObject;
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

    private void ChooseObject()
    {
        int typeOfObject = Random.Range(0, 2);

        if (typeOfObject == 0)
        {
            _object = "Powerup_Bullets";
        }
        if (typeOfObject == 1)
        {
            _object = "Powerup_Health";
        }
    }
}
