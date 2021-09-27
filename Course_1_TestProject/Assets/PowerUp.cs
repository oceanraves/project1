using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public GameObject pickUpEffect;
    private AudioHandler _audioHandler;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Instantiate(pickUpEffect, transform.position, transform.rotation);

            _audioHandler = GameObject.Find("AudioHandler").GetComponent<AudioHandler>();
            _audioHandler.Play("BulletPickup");

            Destroy(gameObject);
        }        
    }

}
