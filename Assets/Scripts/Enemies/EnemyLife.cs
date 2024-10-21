using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int life;
    public bool canTakeRightSlow = true, IsSlowSignVisible=false, canTakeLeftDamage = true;
    public float timerToTakeRightSlow, timerToTakeLeftDamage;
    public GameObject img;

    public void TakeDamage(int damage)
    {
        this.life -= damage;
    }
    private void Awake()
    {
        img.SetActive(false);
        IsSlowSignVisible = false;
    }
    public void Die()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        CanTakeAttackEffect();
    }
    public void CanTakeAttackEffect() {
        if(timerToTakeLeftDamage <= 0)
        {
            canTakeLeftDamage = true;
        }
        else if(!canTakeLeftDamage)
        {
            timerToTakeLeftDamage -= Time.deltaTime;
        }

        if(timerToTakeRightSlow <= 0)
        {
            canTakeRightSlow = true;
        }
        else if (!canTakeRightSlow)
        {
            timerToTakeRightSlow -= Time.deltaTime;
        }
    }

    public void TookRightSlow() {
        this.canTakeRightSlow = false;
        timerToTakeRightSlow = 2;
    }
    public void TookLeftDamage() {
        this.canTakeLeftDamage = false;
        timerToTakeLeftDamage = 1.5f;
    }

    public void ShowSlowSign()
    {
        img.SetActive(true);
    }
    public void HideSlowSign()
    {
        img.SetActive(false);
    }

}
