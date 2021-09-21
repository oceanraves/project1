using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{

    int HitScore = 10;
    public int score;
    public Text ScoreUI;
    // Start is called before the first frame update
    void Start()
    {
        ScoreUI.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    public void AddScore()
    {
        score = score + HitScore;
        ScoreUI.text = "Score: " + score.ToString();
    }
}
