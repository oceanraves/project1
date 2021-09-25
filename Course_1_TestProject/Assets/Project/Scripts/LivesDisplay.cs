using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    public Text text;

    public void SetLives(string lives)
    {
        text.text = lives;
    }
}
