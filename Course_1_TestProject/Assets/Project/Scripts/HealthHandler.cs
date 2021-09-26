using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    public int _playerHealth;
    public int _maxHealth;
    private int _bulletDamage;
    private int _playerLives;

    private GameMaster _gameMaster;
    private SceneHandler _sceneHandler;
    private GameObject _player;
    private PlayerMovement _pMovement;
    private HealthBar _healthBar;
    private LivesDisplay _lDisplay;
    private LevelSystem _levelSystem;
    private EnemySpawner _enemySpawner;
    void Start()
    {
        _playerHealth = 10;
        _maxHealth = 10; 
        _bulletDamage = 1;

        _gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        _sceneHandler = GameObject.Find("SceneHandler").GetComponent<SceneHandler>();
        _player = GameObject.Find("TEST_Player_Spaceship Variant");
        _pMovement = _player.GetComponent<PlayerMovement>();
        _healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        _lDisplay = GameObject.Find("Lives").GetComponent<LivesDisplay>();
        _levelSystem = GameObject.Find("LevelSystem").GetComponent<LevelSystem>();
        _enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
    }

    public void Update()
    {
        _playerLives = _gameMaster.lives;
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
            _gameMaster.Lives(_playerLives);

            if (_playerLives <= 0)
            {
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
        ExplosionSpawner explosionSpawner = GameObject.Find("ExplosionSpawner").GetComponent<ExplosionSpawner>();
        explosionSpawner.SpawnExplosion(_player.transform.position, "Ship");
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
        _lDisplay.SetLives(_playerLives.ToString());

        int _lvl = _levelSystem.level;
        _gameMaster.Level(_lvl);
        float spawnRate = _levelSystem.level;
        _gameMaster.SpawnRate(_enemySpawner.spawnRate);
        _gameMaster.Lives(3);
        _gameMaster.lastCheckPointPos = _player.transform.position;

        _sceneHandler.LoadLevel1();
    }
}
