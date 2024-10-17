using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField] private string nextScene;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject settingsPanel;
    public Slider globalVol, musicVol, effectsVol, sense;

    private string configPath;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        LoadConfigs();
    }

    public void Play()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void Save()
    {
        SaveConfigs();
        CloseSettings();

        Debug.Log("Salvou as config");
    }

        public void Quit()
    {
        Application.Quit();
        Debug.Log("Quitaste xD");
    }

    public void OpenSettings()
    {
        menuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        menuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
    
    private void SaveConfigs()
    {
        PlayerPrefs.SetFloat("GlobalVolume", globalVol.value);
        PlayerPrefs.SetFloat("MusicVolume", musicVol.value);
        PlayerPrefs.SetFloat("EffectsVolume", effectsVol.value);
        PlayerPrefs.SetFloat("PlayerSense", sense.value);

        PlayerPrefs.Save();
    }

    private void LoadConfigs()
    {
        globalVol.value = PlayerPrefs.HasKey("GlobalVolume") ? PlayerPrefs.GetFloat("GlobalVolume") : 0.5f;
        musicVol.value = PlayerPrefs.HasKey("MusicVolume") ? PlayerPrefs.GetFloat("MusicVolume") : 0.5f;
        effectsVol.value = PlayerPrefs.HasKey("EffectsVolume") ? PlayerPrefs.GetFloat("EffectsVolume") : 0.5f;
        sense.value = PlayerPrefs.HasKey("PlayerSense") ? PlayerPrefs.GetFloat("PlayerSense") : 15.0f;
    }

    public void ResetToDefault()
    {
        globalVol.value = 0.8f;
        musicVol.value = 0.6f;
        effectsVol.value = 0.5f;
        sense.value = 15f;

        SaveConfigs();

        Debug.Log("Retornou ao default");
    }
}
