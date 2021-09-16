using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;
    public int damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject explosion = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(explosion,1f);
            Destroy(this.gameObject);

        }
    }
}
