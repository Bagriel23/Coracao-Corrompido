using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public Transform hitBoxPosition;
    public float attackRadius;
    public float timerToAttack, timer;
    [SerializeField] private bool attack;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            attack = true;
            Attack();
            timer = timerToAttack;
        }
        else
        {
            timer -= 1 * Time.deltaTime;
        }
    }

    private void Attack()
    {
        if (attack)
        {


            Vector3 hitBoxSize = new Vector3(attackRadius, attackRadius, attackRadius);

            Collider[] playerToDamge = Physics.OverlapBox(hitBoxPosition.position, hitBoxSize / 2, Quaternion.identity);
            for (int i = 0; i < playerToDamge.Length; i++)
            {
                PlayerLife playerLife = playerToDamge[i].GetComponent<PlayerLife>();
                if (playerLife != null)
                {
                    playerLife.TakeDamage(1);
                    attack = false;
                }
            }
        }
    }
}
