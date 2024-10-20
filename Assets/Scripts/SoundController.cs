using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip[] musicPlaylist;
    public AudioClip[] effectsPlaylist;
    private AudioSource musicSource;
    private AudioSource effectsSource;

    private float globalVolume;
    private float musicVolume;
    private float effectsVolume;

    private void Start()
    {
        musicSource = gameObject.AddComponent<AudioSource>();
        effectsSource = gameObject.AddComponent<AudioSource>();

        LoadVolumeSettings();
    }

    private void LoadVolumeSettings()
    {
        globalVolume = PlayerPrefs.GetFloat("GlobalVolume", 0.5f);
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f) * globalVolume;
        effectsVolume = PlayerPrefs.GetFloat("EffectsVolume", 0.5f) * globalVolume;

        musicSource.volume = musicVolume;
        effectsSource.volume = effectsVolume;
    }

    public void PlayMusic(int clipIndex)
    {
        if (clipIndex < 0 || clipIndex >= musicPlaylist.Length) return;

        musicSource.clip = musicPlaylist[clipIndex];
        musicSource.Play();
    }

    public void PlaySoundEffect(int clipIndex)
    {
        if (clipIndex < 0 || clipIndex >= effectsPlaylist.Length) return;

        effectsSource.PlayOneShot(effectsPlaylist[clipIndex], effectsVolume);
    }

    public void UpdateVolumeSettings()
    {
        globalVolume = PlayerPrefs.GetFloat("GlobalVolume", 0.5f);
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f) * globalVolume;
        effectsVolume = PlayerPrefs.GetFloat("EffectsVolume", 0.5f) * globalVolume;

        musicSource.volume = musicVolume;
        effectsSource.volume = effectsVolume;
    }

}
