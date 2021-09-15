using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //ENEMY COLLISION BEHAVIOUR
        if (collision.collider.tag == "Enemy")
        {
            GameObject explosion = Instantiate(Resources.Load("Explosion_0", typeof(GameObject))) as GameObject;
            explosion.transform.position = collision.collider.transform.position;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Projectile_00")
        {            
            //LOOSE HEALTH
            //PLAY HURT ANIMATION
            //(DEATH)
            Destroy(collision.gameObject);
        }
    }
}
