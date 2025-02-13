using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public Slider hpSlider, easeHpSlider;
    [SerializeField] private float maxHP;
    [SerializeField] private float currentHP;
    [SerializeField] private GameObject screenOverlay;
    [SerializeField] private GameObject hitEffect;

    [SerializeField] private float flashDuration = 0.1f;
    private float flashEndTime;
    private DeathEvent deathEvent;
    private float smoothVelocity = 0f;


    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        hpSlider.value = currentHP;
        easeHpSlider.value = currentHP;
        hitEffect.SetActive(false);

        deathEvent = GetComponent<DeathEvent>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHP();
        // testDamage();        
        easeEffect();
        DeathScenario();
        DisableHitEffect();
        // XD();

        currentHP =  Mathf.Clamp(currentHP, 0, maxHP);
    }

    private void UpdateHP()
    {
        if (hpSlider.value != currentHP)
        {
            hpSlider.value = currentHP;
        }
    }

    private void easeEffect()
    {
        if (hpSlider.value != easeHpSlider.value)
        {
            easeHpSlider.value = Mathf.SmoothDamp(easeHpSlider.value, currentHP, ref smoothVelocity, 0.09f);
        }   
    }

    private void testDamage()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(10);
        }
    }
    
    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        Debug.Log("Player Sofreu " + damage + " de dano. Vida atual: " + currentHP + ".");
        TriggerHitEffect();
    }

    public void DeathScenario()
    {
        if (currentHP <= 0)
        {
            deathEvent.OnPlayerDeath();
            screenOverlay.SetActive(false);
        }
    }

    private void DisableHitEffect()
    {
        if (hitEffect.activeSelf && Time.time > flashEndTime)
        {
            hitEffect.SetActive(false);
        }
    }

    private void TriggerHitEffect()
    {
        hitEffect.SetActive(true);
        flashEndTime = Time.time + flashDuration;
    }

    private void XD()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("TelaDeVitoria");
        }
    }
}
