using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Transform player;
    private UnityEngine.AI.NavMeshAgent selfAgent;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        selfAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        anim.SetFloat("Speed", 1f);
        selfAgent.destination = player.position;
    }


}
