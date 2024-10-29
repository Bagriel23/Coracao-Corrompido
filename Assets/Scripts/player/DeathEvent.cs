using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathEvent : MonoBehaviour
{
    [SerializeField] private Animator bgAnimator;
    [SerializeField] private GameObject deathOverlay;
    [SerializeField] private Image bg;
    [SerializeField] private string menuScene;
    [SerializeField] private float backToTitle = 5f;
    private float interval = 0f;

    void Start()
    {
        bgAnimator = bg.GetComponent<Animator>();
    }

    public void OnPlayerDeath()
    {
        deathOverlay.SetActive(true);
        Time.timeScale = 0f;
        interval += Time.unscaledDeltaTime;
        bgAnimator.SetTrigger("FadeIn");
        
        if (interval >= backToTitle)
        {
            SceneManager.LoadScene(menuScene);
        }

    }
}
