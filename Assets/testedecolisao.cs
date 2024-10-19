using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testedecolisao : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        
        if (!other.gameObject.CompareTag("Player")) return;
            Debug.Log("Player entrou na zona");
       
    }
}
