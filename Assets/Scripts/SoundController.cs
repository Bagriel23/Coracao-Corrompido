using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource[] musicPlaylist;
    public AudioSource[] effectsPlaylist;

    private float globalVolume;
    private float musicVolume;
    private float effectsVolume;

    private void Start()
    {
        LoadVolumeSettings();
    }

    private void Update()
    {
        UpdateVolumeSettings();
    }

    private void LoadVolumeSettings()
    {
        globalVolume = PlayerPrefs.GetFloat("GlobalVolume", 0.6f);
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f) * globalVolume;
        effectsVolume = PlayerPrefs.GetFloat("EffectsVolume", 0.4f) * globalVolume;

        foreach (AudioSource musicSource in musicPlaylist)
        {
            musicSource.volume = musicVolume;
        }

        foreach (AudioSource effectSource in effectsPlaylist)
        {
            effectSource.volume = effectsVolume;
        }
    }

    public void UpdateVolumeSettings()
    {
        globalVolume = PlayerPrefs.GetFloat("GlobalVolume", 0.5f);
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f) * globalVolume;
        effectsVolume = PlayerPrefs.GetFloat("EffectsVolume", 0.5f) * globalVolume;

        foreach (AudioSource musicSource in musicPlaylist)
        {
            musicSource.volume = musicVolume;
        }

        foreach (AudioSource effectSource in effectsPlaylist)
        {
            effectSource.volume = effectsVolume;
        }
    }

}
