using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public GameObject pickUpEffect;
    private AudioHandler _audioHandler;

    private void Awake()
    {
        Rigidbody _rb = gameObject.GetComponent<Rigidbody>();
        Vector3 force = new Vector3(0, -0.5f, 0f);
        _rb.AddForce(force, ForceMode.Impulse);
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Instantiate(pickUpEffect, transform.position, transform.rotation);

            _audioHandler = GameObject.Find("AudioHandler").GetComponent<AudioHandler>();
            _audioHandler.Play("BulletPickup");

            Destroy(gameObject);
        }

        if (collider.gameObject.tag == "Boundary")
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
