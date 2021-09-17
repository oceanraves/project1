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
            _healthHandler.PlayerHit();
            GameObject explosion = Instantiate(Resources.Load("Explosion_0", typeof(GameObject))) as GameObject;
            explosion.transform.position = collision.collider.transform.position;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //LOOSE HEALTH
            //PLAY HURT ANIMATION
            //(DEATH)

            _healthHandler.PlayerHit();

            Destroy(collision.gameObject);
        }
    }
}
