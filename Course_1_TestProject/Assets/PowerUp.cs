using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public GameObject pickUpEffect;

    public float multiplier = 2f;
    public float duration = 4f;
    void Start()
    {
        StartCoroutine(Pickup());
    }

    IEnumerator Pickup()
    {
        //Instantiate(pickUpEffect, transform.position, transform.rotation);

        //PlayerShooting force = player.GetComponent<PlayerShooting>();
        //force.bulletForce *= multiplier;
        Debug.Log("Start");
        yield return new WaitForSeconds(4f);
        Debug.Log("Stop");
        //force.bulletForce /= multiplier;  
        
        //Destroy(gameObject);
    }
}
