using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int life;
    public bool canTakeRightSlow = true, canTakeLeftDamage = true;
    public float timerToTakeRightSlow, timerToTakeLeftDamage;

    public void TakeDamage(int damage)
    {
        this.life -= damage;
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
}
