using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    private int _playerHealth;
    private int _bulletDamage;
    private int _playerDamage;

    private GameObject _enemy00;
    private GameObject _enemy01;
    private GameObject _enemy02;
    private GameObject _enemy03;

    private int _enemyHealth00 = 1;
    private int _enemyHealth01 = 1;
    private int _enemyHealth02 = 1;
    private int _enemyHealth03 = 1;



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


    public void EnemyHealth(int enemyType)
    {
        if (enemyType == 0)
        {

        }
        if (enemyType == 1)
        {

        }
        if (enemyType == 2)
        {

        }

    }

    private void PlayerDeath()
    {
        Debug.Log("Player is Dead");
        GameObject player = GameObject.Find("Player_Spaceship");

        GameObject explosion = Instantiate(Resources.Load("Explosion_0", typeof(GameObject))) as GameObject;
        explosion.transform.position = player.transform.position;

        Destroy(player);
        //SHOW GAME OVER UI (WITH BUTTONS TO EXIT OR RESTART)
    }








}
