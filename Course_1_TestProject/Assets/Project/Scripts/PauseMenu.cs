using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private InputHandler _inputHandler;
    private static bool _gameIsPaused;
    //public static bool gameIsPaused = false;

    private void Start()
    {
        _inputHandler = GameObject.Find("InputHandler").GetComponent<InputHandler>();
        _gameIsPaused = _inputHandler._isPaused;
    }
    

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}
