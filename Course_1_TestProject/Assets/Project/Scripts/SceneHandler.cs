using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {

    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void LoadLevel1()
    {
        SceneManager.LoadScene(1);
    }

}
