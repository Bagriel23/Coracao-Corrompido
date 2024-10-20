using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PauseElement
{
    public Button button;
    public Slider slider;
    public Toggle toggle;
}
public class PauseMenu : MonoBehaviour
{

    public PauseElement[] settingsElements;
    private int optionsIndex;
    [SerializeField] private CameraControl cameraControl;
    [SerializeField] private Toggle invertAnalog;
    [SerializeField] private Slider globalVol, musicVol, effectsVol, sense;
    private string configPath;
    private void Start()
    {
        optionsIndex = 0;
        LoadConfigs();
    }

    public void Save()
    {
        SaveConfigs();
        cameraControl.LoadSettings();
        Debug.Log("Salvou as config");
    }

    private void SaveConfigs()
    {
        PlayerPrefs.SetFloat("GlobalVolume", globalVol.value);
        PlayerPrefs.SetFloat("MusicVolume", musicVol.value);
        PlayerPrefs.SetFloat("EffectsVolume", effectsVol.value);
        PlayerPrefs.SetFloat("PlayerSense", sense.value);

        PlayerPrefs.SetInt("InvertAnalog", invertAnalog.isOn ? 1 : 0);

        PlayerPrefs.Save();
    }

    private void LoadConfigs()
    {
        globalVol.value = PlayerPrefs.HasKey("GlobalVolume") ? PlayerPrefs.GetFloat("GlobalVolume") : 0.5f;
        musicVol.value = PlayerPrefs.HasKey("MusicVolume") ? PlayerPrefs.GetFloat("MusicVolume") : 0.5f;
        effectsVol.value = PlayerPrefs.HasKey("EffectsVolume") ? PlayerPrefs.GetFloat("EffectsVolume") : 0.5f;
        sense.value = PlayerPrefs.HasKey("PlayerSense") ? PlayerPrefs.GetFloat("PlayerSense") : 5.0f;
        
        int isInverted = PlayerPrefs.GetInt("InvertAnalog", 0);
        invertAnalog.isOn = isInverted == 1;
        Debug.Log(isInverted);
    }

    public void ResetToDefault()
    {
        globalVol.value = 0.8f;
        musicVol.value = 0.6f;
        effectsVol.value = 0.5f;
        sense.value = 5f;

        invertAnalog.isOn = false;
        
        SaveConfigs();
        Debug.Log("Retornou ao default");
    }
}
