using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour
{
    public bool _isPaused = false;
    float timer;
    public float cooldown = 2f;
    private AudioHandler _audioHandler;
    private PlayerMovement _playerMovement;
    private PlayerShooting _playerShooting;
    Vector3 moveInput;
    private InputHandler _inputHandler;
    public GameObject pauseMenuUI;
    private GameMaster _gameMaster;



    void Start()
    {
        _audioHandler = GameObject.Find("AudioHandler").GetComponent<AudioHandler>();
        _playerMovement = GameObject.Find("TEST_Player_Spaceship Variant").GetComponent<PlayerMovement>();
        _playerShooting = GameObject.Find("TEST_Player_Spaceship Variant").GetComponent<PlayerShooting>();
        _inputHandler = GameObject.Find("InputHandler").GetComponent<InputHandler>();
        _gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }
    void Update()
    {
        timer += Time.deltaTime;

        //GET PLAYER MOVEMENT INPUT
        moveInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        if (moveInput != Vector3.zero)
        {
            _playerMovement.Move(moveInput);
        }

        //GET PLAYER SHOOTING INPUT
        if (_playerMovement.playerEnabled == true && Input.GetButton("Fire1") && !_inputHandler._isPaused && timer > cooldown)
        {
            _playerShooting.Shoot();
            _audioHandler.Play("Lazer_1");
            timer = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(_isPaused)
            {
                //RESUME TIME
                Time.timeScale = 1f;
                _isPaused = false;
                _audioHandler.PauseAudio();
                Resume();
                return;
            }
            else
            Time.timeScale = 0f;
            _isPaused = true;
            Pause();
            _audioHandler.PauseAudio();
        }

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        _isPaused = false;
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        _isPaused = true;
        Time.timeScale = 0f;
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
