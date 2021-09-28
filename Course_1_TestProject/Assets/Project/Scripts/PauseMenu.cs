using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private InputHandler _inputHandler;
    private GameMaster _gameMaster;
    private static bool _gameIsPaused;
    //public static bool gameIsPaused = false;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            GetInputHandler();
        }
        _gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    private void GetInputHandler()
    {
        _inputHandler = GameObject.Find("InputHandler").GetComponent<InputHandler>();
        _gameIsPaused = _inputHandler._isPaused;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_gameIsPaused)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _gameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _gameIsPaused = true;
    }

    public void LoadMenu()
    {
        _gameMaster.ResetAll();
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}
