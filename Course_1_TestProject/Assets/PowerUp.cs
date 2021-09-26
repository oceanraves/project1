using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public GameObject pickUpEffect;
    

  
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Instantiate(pickUpEffect, transform.position, transform.rotation); 
            Destroy(gameObject);
        }
        
    }

}
