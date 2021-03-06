using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public List<AudioSource> sounds;

    [SerializeField]
    private bool _isMuted;
    void Start()
    {        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            MuteAudio();
        }
    }

    private void MuteAudio()
    {
        if (_isMuted)
        {
            AudioListener.volume = 1f;
            _isMuted = false;
            return;
        } else
            AudioListener.volume = 0f;
            _isMuted = true;
    }
}
