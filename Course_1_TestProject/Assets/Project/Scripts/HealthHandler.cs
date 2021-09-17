using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    private int _playerHealth;
    private int bulletDamage;

    void Start()
    {
        _playerHealth = 10;
        bulletDamage = 1;
        //collision damage
        //bullet damage (Enemy0)
        //bullet damage (Enemy1)
        //bullet damage (Enemy2)
    }

    public void PlayerHit()
    {
        _playerHealth = _playerHealth - bulletDamage;
        Debug.Log("Hit! Player Health = " + _playerHealth);

        if (_playerHealth <= 0)
        {
            PlayerDeath();
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
