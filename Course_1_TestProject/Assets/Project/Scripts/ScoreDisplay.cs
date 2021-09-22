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

    // Start is called before the first frame update
    void Start()
    {
        scoreUI.text = "Score: " + score.ToString();
        highScoreUI.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    public void AddScore()
    {
        score = score + hitScore;
        scoreUI.text = "Score: " + score.ToString();

        if (score > PlayerPrefs.GetInt ("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreUI.text = "High Score: " + score.ToString();
        }

    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
}
