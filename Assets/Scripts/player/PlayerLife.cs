using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int life;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            EndGame();
        }
    }

    public void TakeDamage(int damage)
    {
        this.life -= damage;
        Debug.Log("Player Sofreu " + damage + " de dano");
    }

    public void EndGame()
    {
        Application.Quit();

    }
}
