using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_PickUp : MonoBehaviour
{
    private HealthHandler _healthHandler;

    private void Awake()
    {
        _healthHandler = FindObjectOfType<HealthHandler>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (_healthHandler._playerHealth < _healthHandler._maxHealth && collider.CompareTag("Player"))
        {
            _healthHandler.PlayerHealthUp();
            //_healthHandler._playerHealth = _healthHandler._playerHealth + healthBonus;     
        }
    }
}
