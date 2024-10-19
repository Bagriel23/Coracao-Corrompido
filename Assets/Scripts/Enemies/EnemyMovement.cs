using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Animator anim;
    private Transform player;
    private UnityEngine.AI.NavMeshAgent selfAgent;
    private float speed = 1f;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        selfAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         MoveTowardsPlayer();  
    }

    private void MoveTowardsPlayer()
    {
        if (player != null && !anim.GetBool("AttackPlayer"))
        { 
            anim.SetFloat("Speed", speed);
            selfAgent.destination = player.position;
        }
        else
        {
            selfAgent.destination = this.transform.position;
        }
       
    }


}
