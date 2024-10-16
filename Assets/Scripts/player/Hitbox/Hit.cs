using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    float timer = 1;
    // Start is called before the first frame update
    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            timer -= 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
     //   if (!String.IsNullOrEmpty(tagFilter) && !other.gameObject.CompareTag(tagFilter)) return;
       // if(other.)
    }

    private void OnTriggerStay(Collider other)
    {
        
    }
}
