using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public Slider hpSlider, easeHpSlider;
    [SerializeField] private float maxHP;
    [SerializeField] private float currentHP;
    private float smoothVelocity = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        hpSlider.value = currentHP;
        easeHpSlider.value = currentHP;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHP();
        testDamage();        
        easeEffect();

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

    public void testDamage()
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
    }
}
