using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DeathEvent : MonoBehaviour
{
    [SerializeField] private Animator overlayAnimator;
    [SerializeField] private Image deathOverlay;
    private float interval = 1.3f;
    private float lastEffect = 0f;
    void Start()
    {
        // playerAnimator = player.GetComponent<Animator>();
        overlayAnimator = deathOverlay.GetComponent<Animator>();   
    }
    public void OnPlayerDeath()
    {
        Time.timeScale = 0f;
        lastEffect += Time.unscaledDeltaTime;
        Debug.Log(lastEffect);
        // playerAnimator.SetTrigger("");
        if (lastEffect >= interval)
            {
                Debug.Log("entrou na condição");
                overlayAnimator.SetTrigger("FadeIn");
                lastEffect = 0.0f;
            }
    }
}
