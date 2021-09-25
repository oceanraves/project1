using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour
{
    public Text text;

    public void SetLevel(string level)
    {
        text.text = "Level " + level;
    }
}
