using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    Object enemy;
    GameObject clone;
    Vector3 spawnPoint;
    float newX;
    float newZ;

    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        StartSpawn();
    }

    void Update()
    {
        
    }
    private void StartSpawn()
    {
        GetSpawnPoint();
        enemy = Resources.Load("Enemy");
        //clone = Instantiate(enemy, spawnPoint, Quaternion.identity);
    }

    private void GetSpawnPoint()
    {
        newX = Random.Range(0.1f, 2f);
        newZ = Random.Range(0.1f, 2f);
        spawnPoint = new Vector3(newX, 0f, newZ);
    }
}
