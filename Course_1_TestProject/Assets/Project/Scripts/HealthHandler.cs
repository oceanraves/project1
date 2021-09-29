using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    public int _playerHealth;
    public int _maxHealth;
    private int _bulletDamage;
    private int _playerLives;
    public int healthBonus = 2;

    private GameMaster _gameMaster;
    private SceneHandler _sceneHandler;
    private GameObject _player;
    private PlayerMovement _pMovement;
    private HealthBar _healthBar;
    private LivesDisplay _lDisplay;
    private LevelSystem _levelSystem;
    private EnemySpawner _enemySpawner;
    private Health_PickUp _healthPickup;
    private ScoreDisplay _scoreDisplay;

    public bool invincible;



    private GameObject _life1;
    private GameObject _life2;
    private GameObject _life3;
    private string _ogLife;

    void Start()
    {
        _playerHealth = 10;
        _maxHealth = 10; 
        _bulletDamage = 1;
        DisplayLives();

        _gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        _sceneHandler = GameObject.Find("SceneHandler").GetComponent<SceneHandler>();
        _player = GameObject.Find("TEST_Player_Spaceship Variant");
        _pMovement = _player.GetComponent<PlayerMovement>();
        _healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        //_lDisplay = GameObject.Find("Lives").GetComponent<LivesDisplay>();
        _levelSystem = GameObject.Find("LevelSystem").GetComponent<LevelSystem>();
        _enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        _scoreDisplay = GameObject.Find("ScoreDisplay").GetComponent<ScoreDisplay>();
    }


    public void DisplayLives()
    {
        Vector3 rotation = new Vector3(2, 0, 0);
        _ogLife = "Life";

        _life1 = Instantiate(Resources.Load(_ogLife, typeof(GameObject))) as GameObject;
        _life1.transform.position = new Vector3(-3.2f, 40.5f, 17f);
        _life1.gameObject.AddComponent<ObjectRotater>();
        _life1.gameObject.GetComponent<ObjectRotater>().SetRotation(rotation);
        _life1.gameObject.AddComponent<ObjectRotater>().rotationSpeed = 5;

        _life2 = Instantiate(Resources.Load(_ogLife, typeof(GameObject))) as GameObject;
        _life2.transform.position = new Vector3(-0.4f, 40.5f, 17f);
        _life2.gameObject.GetComponent<ObjectRotater>().SetRotation(rotation);
        _life2.gameObject.AddComponent<ObjectRotater>().rotationSpeed = 5;

        _life3 = Instantiate(Resources.Load(_ogLife, typeof(GameObject))) as GameObject;
        _life3.transform.position = new Vector3(2.75f, 40.5f, 17f);
        _life3.gameObject.GetComponent<ObjectRotater>().SetRotation(rotation);
        _life3.gameObject.AddComponent<ObjectRotater>().rotationSpeed = 5;
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

            if (_playerLives == 3)
            {
                _life1.SetActive(true);
                _life2.SetActive(true);
                _life3.SetActive(true);
            }
            if (_playerLives == 2)
            {
                _life1.SetActive(true);
                _life2.SetActive(true);
                _life3.SetActive(false);
            }
            if (_playerLives == 1)
            {
                _life1.SetActive(true);
                _life2.SetActive(false);
                _life3.SetActive(false);
            }
            if (_playerLives <= 0)
            {
                _life1.SetActive(false);
                _life2.SetActive(false);
                _life3.SetActive(false);
            }


            //_lDisplay.SetLives(_playerLives.ToString());
            _gameMaster.Lives(_playerLives);

            if (_playerLives <= 0 && !invincible)
            {
                GameOver();
            } else
            {
                PlayerDeath();
            }
        }
    }

    public void PlayerHealthUp()
    {
        _playerHealth += healthBonus;
        _healthBar.SetHealth(_playerHealth);
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
        //_lDisplay.SetLives(_playerLives.ToString());

        int _lvl = _levelSystem.level;
        _gameMaster.Level(_lvl);
        _gameMaster.spawnRate = _enemySpawner.spawnRate;
        _gameMaster.Lives(3);
        _gameMaster.lastCheckPointPos = _player.transform.position;
        _gameMaster.Score(_scoreDisplay.score);
        _sceneHandler.LoadLevel1();
    }
}
