using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAttack : MonoBehaviour
{
    private EnemyAI AI;

    private void Start()
    {
        AI = GetComponentInParent<EnemyAI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("Algo entrou no trigger: " + other.name); 

        if (!other.gameObject.CompareTag("Player")) return;
            AI.BodyAttack();

    }
}
