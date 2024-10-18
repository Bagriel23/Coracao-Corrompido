using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int life;
    

    public void TakeDamage(int damage)
    {
        this.life -= damage;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
