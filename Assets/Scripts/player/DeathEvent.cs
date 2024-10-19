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
    private float interval = 1.3f;
    private float lastEffect = 0f;

    void Start()
    {
        // playerAnimator = player.GetComponent<Animator>();
        bgAnimator = bg.GetComponent<Animator>();
    }

    public void OnPlayerDeath()
    {
        deathOverlay.SetActive(true);
        Time.timeScale = 0f;
        lastEffect += Time.unscaledDeltaTime;
        // Debug.Log(lastEffect);
        // playerAnimator.SetTrigger("");
        if (lastEffect >= interval)
        {
            bgAnimator.SetTrigger("FadeIn");
        }

        if (lastEffect >= backToTitle)
        {
            SceneManager.LoadScene(menuScene);
        }

    }
}
