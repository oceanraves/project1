using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    int hitScore = 10;
    public int score;
    public Text scoreUI;
    public Text highScoreUI;
    private GameMaster _gameMaster;

    void Start()
    {
        _gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        score = _gameMaster.score;

        scoreUI.text = score.ToString();
        highScoreUI.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    private void Update()
    {
        highScoreUI.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void AddScore()
    {
        score = score + hitScore;
        scoreUI.text = score.ToString();

        if (score > PlayerPrefs.GetInt ("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreUI.text = score.ToString();
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
}
