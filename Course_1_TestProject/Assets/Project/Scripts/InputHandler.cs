using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private bool _isPaused = false;
    private AudioHandler _audioHandler;
    private PlayerMovement _playerMovement;
    private PlayerShooting _playerShooting;
    Vector3 moveInput;

    void Start()
    {
        _audioHandler = GameObject.Find("AudioHandler").GetComponent<AudioHandler>();
        _playerMovement = GameObject.Find("TEST_Player_Spaceship Variant").GetComponent<PlayerMovement>();
        _playerShooting = GameObject.Find("TEST_Player_Spaceship Variant").GetComponent<PlayerShooting>();
    }
    void Update()
    {
        //GET PLAYER MOVEMENT INPUT
        moveInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        if (moveInput != Vector3.zero)
        {
            _playerMovement.Move(moveInput);
        }

        //GET PLAYER SHOOTING INPUT
        if (_playerMovement.playerEnabled == true && Input.GetButtonDown("Fire1"))
        {
            _playerShooting.Shoot();
            _audioHandler.Play("Lazer_1");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(_isPaused)
            {
                //RESUME TIME
                Time.timeScale = 1f;
                _isPaused = false;
                _audioHandler.PauseAudio();
                return;
            }
            else
            Time.timeScale = 0f;
            _isPaused = true;

            _audioHandler.PauseAudio();
        }
    }
}
