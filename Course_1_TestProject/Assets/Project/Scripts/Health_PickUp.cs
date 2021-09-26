using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_PickUp : MonoBehaviour
{
    HealthHandler _playerHealth;

    public int healthBonus = 2;

    private void Awake()
    {
        _playerHealth = FindObjectOfType<HealthHandler>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (_playerHealth._playerHealth < _playerHealth._maxHealth && collider.CompareTag("Player"))
        {
           
            _playerHealth._playerHealth = _playerHealth._playerHealth + healthBonus; 
        }
    }
}
