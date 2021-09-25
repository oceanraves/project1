using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpawner : MonoBehaviour
{
    public void SpawnExplosion(Vector3 position, string typeOf)
    {
        if (typeOf == "Ship")
        {
            GameObject explosion = Instantiate(Resources.Load("Explosion_0", typeof(GameObject))) as GameObject;
            explosion.transform.position = position;
            Destroy(explosion, 5f);
        }

        if (typeOf == "Bullet")
        {
            GameObject explosion = Instantiate(Resources.Load("BulletExplosion", typeof(GameObject))) as GameObject;
            explosion.transform.position = position;
            Destroy(explosion, 5f);
        }
    }
}
