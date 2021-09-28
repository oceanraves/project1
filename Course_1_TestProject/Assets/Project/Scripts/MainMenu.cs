using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private InputHandler _inputHandler;
    private static bool _gameIsPaused;
    private GameMaster _gameMaster;


    private void Start()
    {
        _gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            GetInputHandler();
        }
    }
    private void GetInputHandler()
    {
        _inputHandler = GameObject.Find("InputHandler").GetComponent<InputHandler>();
        _gameIsPaused = _inputHandler._isPaused;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
        _gameIsPaused = false; 
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
