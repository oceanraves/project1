using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private bool _isPaused = false;
    private AudioHandler _audioHandler;

    void Start()
    {
        _audioHandler = GameObject.Find("AudioHandler").GetComponent<AudioHandler>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(_isPaused)
            {
                //RESUME TIME
                Time.timeScale = 1f;
                _isPaused = false;

                //bool paused = false;
                _audioHandler.PauseAudio();

                return;
            }
            else
                //STOP TIME
                Time.timeScale = 0f;
            _isPaused = true;

            _audioHandler.PauseAudio();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _audioHandler.Play("Lazer_1");
        }
    }
}
