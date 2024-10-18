

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;

    private WaveSpawner waveSpawner;
    private EnemyLife enemyLife;
    private int originalWave;
    public float countdown = 5f;
    // Start is called before the first frame update
    void Start()
    {
        waveSpawner = GetComponentInParent<WaveSpawner>();
        enemyLife = GetComponent<EnemyLife>();
        if (waveSpawner != null)
        {
            originalWave = waveSpawner.currentWaveIndex;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //transform.Translate(transform.forward * speed * Time.deltaTime);

        countdown -= Time.deltaTime;



        if (enemyLife.life <= 0)
        {
            Debug.Log(waveSpawner.currentWaveIndex);
            waveSpawner.waves[waveSpawner.currentWaveIndex].enemiesLeft--;
            Debug.Log("Numero de inimigos sobrando segundo o atributo da wave: "+ waveSpawner.waves[waveSpawner.currentWaveIndex].enemiesLeft);
            Debug.Log("Numero de inimigos sobrando segundo o atributo local: "+ waveSpawner.waves[originalWave].enemiesLeft);
            enemyLife.Die();
        }
    }
}
