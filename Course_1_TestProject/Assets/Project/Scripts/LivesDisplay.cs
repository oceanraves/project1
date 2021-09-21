using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    public Text text;

    public void Start()
    {
        //text.text = "3".ToString();
    }

    public void SetLives(string lives)
    {
        text.text = lives;
    }
}
