using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenciarInputs : MonoBehaviour
{
    public PlayerControls controls;
    void Start()
    {
        controls = GetComponent<PlayerControls>();

    }



    private void OnEnable()
    {
        controls.Enable();

    }

    private void OnDisable()
    {
        controls.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
