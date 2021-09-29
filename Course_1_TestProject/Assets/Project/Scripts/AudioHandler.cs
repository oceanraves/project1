using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class AudioHandler : MonoBehaviour
{
    //public List<AudioSource> sounds;

    [SerializeField]
    private bool _isMuted;

    private bool _isPaused;

    [SerializeField]
    private AudioMixerGroup musicMixerGroup;
    [SerializeField]
    private AudioMixerGroup sfxMixerGroup;

    public Slider musicSlider;
    public Slider sfxSlider;
    public Sound[] sounds;

    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            switch (s.audioType)
            {
                case Sound.AudioTypes.soundEffect:
                    s.source.outputAudioMixerGroup = sfxMixerGroup;
                    break;
                case Sound.AudioTypes.music:
                    s.source.outputAudioMixerGroup = musicMixerGroup;
                    break;
            }
        }
    }


    void Start()
    {
        if (_isMuted)
        {
            AudioListener.volume = 0f;
        }
        Scene currentScene = SceneManager.GetActiveScene(); 
        if (currentScene.buildIndex == 1) //"Level_1(Samuel)")
        {
            Play("Music_Level_1");
        }
        
        if (currentScene.buildIndex == 0) //name== "MainMenu")
        {
            Play("Music_Main_Menu");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            MuteAudio();
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Cound not find Audio Source: " + name);
            return;
        }
        s.source.Play();
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

    public void PauseAudio()
    {
        if (_isPaused)
        {
            AudioListener.pause = true;
        } else
            AudioListener.pause = false;
    }
}