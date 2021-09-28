using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public int levelRate = 10;
    private GameMaster _gameMaster;
    public int level;
    private LevelDisplay _lDisplay;
    private EnemySpawner _enemySpawner;
    private float _lastTime;
    private bool _switch = true;
    void Start()
    {
        _gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        _lDisplay = GameObject.Find("Level").GetComponent<LevelDisplay>();
        _enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();

        level = _gameMaster.lvl;
        _lDisplay.SetLevel(level.ToString());
    }
    private void NextLevel()
    {
        level += 1;

        _enemySpawner.ChangeSpawnRate();
        _lDisplay.SetLevel(level.ToString());
        _switch = true;
    }

    void Update()
    {
        if (Time.time >= levelRate)
        {
            if (_lastTime != 0)
            {
                if (Time.time >= (_lastTime + levelRate))
                {
                    NextLevel();
                }
            }

            if (_switch)
            {
                GetLastTime();
            }
        }
    }
    private void GetLastTime()
    {
        _lastTime = Time.time;
        _switch = false;
    }
}
