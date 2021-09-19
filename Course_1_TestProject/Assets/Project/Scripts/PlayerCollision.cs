using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private HealthHandler _healthHandler;
    void Start()
    {
        _healthHandler = GameObject.Find("HealthHandler").GetComponent<HealthHandler>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //ENEMY COLLISION BEHAVIOUR
        if (collision.collider.tag == "Enemy")
        {
            _healthHandler.PlayerHit(2);
            GameObject explosion = Instantiate(Resources.Load("Explosion_0", typeof(GameObject))) as GameObject;
            explosion.transform.position = collision.collider.transform.position;
            Destroy(collision.gameObject);
        }
    }



    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            _healthHandler.PlayerHit(0);
        }


        //ADD PLAY HURT ANIMATION
        if (collision.gameObject.tag == "Bullet_00")
        {
            _healthHandler.PlayerHit(0);
        }
        if (collision.gameObject.tag == "Bullet_01")
        {
            _healthHandler.PlayerHit(1);
        }
        if (collision.gameObject.tag == "Bullet_02")
        {
            _healthHandler.PlayerHit(2);
        }
        Destroy(collision.gameObject);
    }

    /*
    private void OnCollisionExit(Collision boundary)
    {
        if(boundary.gameObject.tag == "BoundaryPlayer")
        {

        }
        
    }
    */


}
