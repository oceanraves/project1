using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private EnemySpawner _enemySpawner;
    [SerializeField]
    private int _timeBetweenWaves = 5;
    private float _lastTime;
    private bool _switch = true;

    void Start()
    {
        _enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        _lastTime = _timeBetweenWaves;
    }

    void Update()
    {

        if (Time.time >= _timeBetweenWaves)
        {
            if (Time.time >= (_lastTime + _timeBetweenWaves))
            {
                if (_switch)
                {
                    _lastTime = Time.time;
                    _enemySpawner.state = 2;
                    _switch = false;
                    Debug.Log("2");

                    return;
                }

                else
                {
                    _enemySpawner.state = 1;
                    _lastTime = Time.time;
                    _switch = true;
                    Debug.Log("1");
                }
            }
        }
    }
}
