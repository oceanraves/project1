using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private GameMaster _gameMaster;
    private int level;
    private LevelDisplay _lDisplay;
    void Start()
    {
        _gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        _lDisplay = GameObject.Find("Level").GetComponent<LevelDisplay>();
        transform.position = _gameMaster.lastCheckPointPos;
        level = 1;
        _lDisplay.SetLevel(level.ToString());
    }
    void Update()
    {
        if (Time.time >= 10 && level <= 1)
        {
            level = 2;
            _gameMaster.lastCheckPointPos = transform.position;
            _lDisplay.SetLevel(level.ToString());
        }
        if (Time.time >= 20 && level <= 2)
        {
            level = 3;
            _gameMaster.lastCheckPointPos = transform.position;
            _lDisplay.SetLevel(level.ToString());
        }
        if (Time.time >= 30 && level <= 3)
        {
            level = 4;
            _gameMaster.lastCheckPointPos = transform.position;
            _lDisplay.SetLevel(level.ToString());
        }
        if (Time.time >= 40 && level <= 4)
        {
            level = 5;
            _gameMaster.lastCheckPointPos = transform.position;
            _lDisplay.SetLevel(level.ToString());
        }
    }
}
