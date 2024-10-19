using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DetectPlayer : MonoBehaviour
{
    private EnemyAI AI;

    private void Start()
    {
        AI = GetComponentInParent<EnemyAI>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (!String.IsNullOrEmpty("Player") && !other.gameObject.CompareTag("Player")) return;
        //Console.WriteLine("Entrou");
        Debug.Log("Algo entrou no trigger: " + other.name); // Verifique qual objeto está entrando no trigger

        if (!other.gameObject.CompareTag("Player")) return;
            Debug.Log("Player entrou na zona");
            AI.attackPlayer = true;
            AI.Attack();
        
    }
}
