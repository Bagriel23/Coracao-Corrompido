using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testedecolisao : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        //if (!String.IsNullOrEmpty("Player") && !other.gameObject.CompareTag("Player")) return;
        //Console.WriteLine("Entrou");
       // Debug.Log("Algo entrou no trigger: " + other.name); // Verifique qual objeto está entrando no trigger

        if (!other.gameObject.CompareTag("Player")) return;
            Debug.Log("Player entrou na zona");
       // AI.AttackPlayer = true;
        //A/I.Attack();

    }
}
