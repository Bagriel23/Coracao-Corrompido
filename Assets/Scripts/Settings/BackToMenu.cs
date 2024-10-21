using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    [SerializeField] private int count;
    [SerializeField] private string title;
    private int i;
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
        while (count >= i)
        {
            i++;
        }

        if (i == count)
        {
            SceneManager.LoadScene(title);
            Debug.Log("Falta buildar a cena xd");
        }
    }
}
