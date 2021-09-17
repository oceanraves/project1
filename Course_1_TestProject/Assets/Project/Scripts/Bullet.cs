using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;
    public int damage = 10;
    private HealthHandler _healthHandler;

    // Start is called before the first frame update
    void Start()
    {
        _healthHandler = GameObject.Find("HealthHandler").GetComponent<HealthHandler>();
        Destroy(this.gameObject, 5f);
    }

    void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.tag == "Enemy_00")
        {
            //Specifies Enemy Type #0
            _healthHandler.EnemyHealth(0);

            GameObject explosion = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(explosion,1f);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Enemy_01")
        {
            //Specifies Enemy Type #1
            _healthHandler.EnemyHealth(1);

            GameObject explosion = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(explosion, 1f);
            Destroy(this.gameObject);
        }
        
        if (collision.gameObject.tag == "Enemy_02")
        {
            //Specifies Enemy Type #2-
            _healthHandler.EnemyHealth(2);

            GameObject explosion = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(explosion, 1f);
            Destroy(this.gameObject);
        }




    }
}
