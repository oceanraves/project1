using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    private HealthHandler _hHandler;

    public Vector3 lastCheckPointPos;
    public Vector3 _startPos;

    //public int lastCheckPointLives;
    private AudioHandler _aHandler;

    public int startingLevel;
    public int lvl;
    public int lives;
    public float spawnRate;
    public bool firstLevel = true;
    public bool leveled = false;
    public int score;


    private void Awake()
    {        
        lastCheckPointPos = _startPos;

        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        } else {
            Destroy(gameObject);
        }
        ResetAll();
    }

    public void ResetAll()
    {
        lastCheckPointPos = _startPos;
        lvl = 1;
        lives = 3;
        spawnRate = 3f;
        score = 0;
    }

    public void Lives(int playerLives)
    {
        lives = playerLives;
    }

    public void SpawnRate(float getSpawnRate)
    {
        spawnRate = getSpawnRate;
    }
    public void Level(int level)
    {
        lvl = level;        
    }

    public void Score(int scoreIn)
    {
        score = scoreIn;
    }

    void Start()
    {
        _hHandler = GameObject.Find("HealthHandler").GetComponent<HealthHandler>();
        _aHandler = GameObject.Find("AudioHandler").GetComponent<AudioHandler>();
        if (SceneManager.sceneCount == 0)
        {
            _aHandler.Play("Music_Main_Menu");
        }

        if (SceneManager.sceneCount == 1)
        {
            _aHandler.Play("Music_Level_1");
        }
    }
}
