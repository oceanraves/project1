using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    private int _playerHealth;
    private int _bulletDamage;
    private int _playerDamage;

    void Start()
    {
        _playerHealth = 10;
        _bulletDamage = 1;       
    }

    //GETS ENEMY TYPE FROM "PlayerCollision" CLASS.
    public void PlayerHit(int enemyType)
    {
        if (enemyType == 0)
        {
            _bulletDamage = 1;
        }

        if (enemyType == 1)
        {
            _bulletDamage = 3;
        }

        if (enemyType == 2)
        {
            _bulletDamage = 2;
        }
        PlayerHealth();
    }

    private void PlayerHealth()
    {
        _playerHealth -= _bulletDamage;
        Debug.Log("Hit! Player Health = " + _playerHealth);

        if (_playerHealth <= 0)
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        Debug.Log("Player is Dead");
        GameObject player = GameObject.Find("TEST_Player_Spaceship Variant");

        SpawnExplosion(player.transform.position);
        Destroy(player);
        //SHOW GAME OVER UI (WITH BUTTONS TO EXIT OR RESTART)
    }

    public void SpawnExplosion(Vector3 position)
    {
        GameObject explosion = Instantiate(Resources.Load("Explosion_0", typeof(GameObject))) as GameObject;
        explosion.transform.position = position;
    }
}
