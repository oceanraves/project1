using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_PickUp : MonoBehaviour
{
    private HealthHandler _healthHandler;
    private AudioHandler _audioHandler;

    private void Awake()
    {
        _healthHandler = FindObjectOfType<HealthHandler>();
        Rigidbody _rb = gameObject.GetComponent<Rigidbody>();
        Vector3 force = new Vector3(0, -0.5f, 0f);
        _rb.AddForce(force, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            _audioHandler = GameObject.Find("AudioHandler").GetComponent<AudioHandler>();
            _audioHandler.Play("HealthPickup");
            if (_healthHandler._playerHealth < _healthHandler._maxHealth && collider.CompareTag("Player"))
            {
                _healthHandler.PlayerHealthUp();
                //_healthHandler._playerHealth = _healthHandler._playerHealth + healthBonus;     
            }
        }

        if (collider.gameObject.tag == "Boundary")
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
