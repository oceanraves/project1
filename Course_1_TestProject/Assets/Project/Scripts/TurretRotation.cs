using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotation : MonoBehaviour
{
    private Transform _player;

    void Start()
    {
        _player = GameObject.Find("TEST_Player_Spaceship Variant").transform;
    }

    void Update()
    {
        transform.LookAt(_player.transform);
    }
}
