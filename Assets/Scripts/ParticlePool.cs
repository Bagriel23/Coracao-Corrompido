using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : MonoBehaviour
{
    public GameObject particlePrefab;
    public int poolSize = 100;

    private Queue<GameObject> particlePool;

    void Start()
    {
        particlePool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject particle = Instantiate(particlePrefab);
            particle.SetActive(false);
            particlePool.Enqueue(particle);
        }
    }

    public GameObject GetParticle()
    {
        if (particlePool.Count > 0)
        {
            GameObject particle = particlePool.Dequeue();
            particle.SetActive(true);
            return particle;
        }
        else
        {
            return null; 
        }
    }

    // Método para devolver a partícula à pool
    public void ReturnParticle(GameObject particle)
    {
        particle.SetActive(false);
        particlePool.Enqueue(particle);
    }
}
