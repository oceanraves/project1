using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    private int _playerHealth;
    private int _bulletDamage;
    private int _playerDamage;
    private int _playerLives;

    private GameMaster _gameMaster;
    private SceneHandler _sceneHandler;
    private GameObject _player;
    private PlayerMovement _pMovement;
    private HealthBar _healthBar;
    private LivesDisplay _lDisplay;

    void Start()
    {
        _playerHealth = 10;
        _bulletDamage = 1;
        _playerLives = 3;

        //_gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        _sceneHandler = GameObject.Find("SceneHandler").GetComponent<SceneHandler>();
        _player = GameObject.Find("TEST_Player_Spaceship Variant");
        _pMovement = _player.GetComponent<PlayerMovement>();
        _healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        _lDisplay = GameObject.Find("Lives").GetComponent<LivesDisplay>();
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
        _healthBar.SetHealth(_playerHealth);

        if (_playerHealth <= 0)
        {
            _playerLives -= 1;
            _lDisplay.SetLives(_playerLives.ToString());
            if (_playerLives <= 0)
            {
                Debug.Log("GAME OVEAH");
                GameOver();
            } else
            {
                PlayerDeath();
            }
        }
    }

    private void PlayerDeath()
    {
        //INSTANTIATE EXPLOSION
        EnemySpawner enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        enemySpawner.SpawnExplosion(_player.transform.position, "Ship");
        //---------------------

        //PLAY DEATH ANIMATION
        _player.GetComponent<Animator>().SetTrigger("Finished");
        //---------------------

        //DISABLE PLAYER CONTROL UNTIL RESPAWN
        _pMovement.playerEnabled = false;
        //---------------------
    }
    public void Respawn()
    {
        _playerHealth = 10;
        _healthBar.SetHealth(_playerHealth);
        _pMovement.playerEnabled = true;
    }
    private void GameOver()
    {
        Debug.Log("GAME OVEAH");
        //CALL UI OVERLAY (GAME OVER SCREEN, RESTART OR QUIT OPTIONS)
        _gameMaster.lastCheckPointPos = _player.transform.position;
        _lDisplay.SetLives(_playerLives.ToString());
        _sceneHandler.LoadLevel1();
    }
}
