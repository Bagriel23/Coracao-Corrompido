using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public bool attackPlayer;
    private Animator anim;
    public Transform attackHitbox;

    public float attackRadius;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    void Update()
    {
           
    }

    public void Attack()
    {
        anim.SetTrigger("AttackPlayer");
        if (attackPlayer)
        {

            Vector3 hitBoxSize = new Vector3(attackRadius, attackRadius, attackRadius);

            Collider[] playerToDamge = Physics.OverlapBox(attackHitbox.position, hitBoxSize / 2, Quaternion.identity);
            for (int i = 0; i < playerToDamge.Length; i++)
            {
                PlayerLife playerLife = playerToDamge[i].GetComponent<PlayerLife>();
                if (playerLife != null)
                {
                    playerLife.TakeDamage(1);
                    attackPlayer = false;
                }
            }
        }
    }

    public void BodyAttack()
    {
        Vector3 hitBoxSize = new Vector3(attackRadius, attackRadius, attackRadius);

        Collider[] playerToDamge = Physics.OverlapBox(attackHitbox.position, hitBoxSize / 2, Quaternion.identity);
        for (int i = 0; i < playerToDamge.Length; i++)
        {
            PlayerLife playerLife = playerToDamge[i].GetComponent<PlayerLife>();
            if (playerLife != null)
            {
                playerLife.TakeDamage(1);
            }
        }
    }
}
