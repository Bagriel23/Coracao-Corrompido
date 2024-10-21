using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    [SerializeField] private float waitTime = 5f;
    [SerializeField] private string title;
    private float elapsedTime = 0f;

    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        BackToTitle();
    }

    private void BackToTitle()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= waitTime)
        {
            SceneManager.LoadScene(title);
        }
    }
}
