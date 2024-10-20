using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    [SerializeField] private ParticlePool particlePool;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float spawnRadius;
    [SerializeField] private float despawnRadius;
    [SerializeField] private float spawnInterval;
    [SerializeField] private float spawnTimer;
    private List<GameObject> activeParticles = new List<GameObject>();

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnParticlesAroundCamera();
            spawnTimer = 0f;
        }

        DespawnFarParticles();
    }

    private void SpawnParticlesAroundCamera()
    {

        int particlesToSpawn = Mathf.FloorToInt(particlePool.poolSize * 0.1f);

        for (int i = 0; i < particlesToSpawn; i++)
        {
            GameObject particle = particlePool.GetParticle();

            if (particle == null)
            {
                continue;
            }

            Vector3 randomPosition = cameraTransform.position + Random.insideUnitSphere * spawnRadius;
            randomPosition.y = cameraTransform.position.y;

            particle.transform.position = randomPosition;
            particle.SetActive(true);

            activeParticles.Add(particle);
        }
    }

    private void UpdateParticlePositions()
    {
        for (int i = 0; i < activeParticles.Count; i++)
        {
            GameObject particle = activeParticles[i];

            if (particle.activeSelf)
            {
                Vector3 newPos = cameraTransform.position + Random.insideUnitSphere * spawnRadius;
                newPos.y = cameraTransform.position.y;

                particle.transform.position = newPos;
            }
        }
    }

    private void DespawnFarParticles()
    {
        for (int i = activeParticles.Count - 1; i >= 0; i--)
        {
            GameObject particle = activeParticles[i];

            if (Vector3.Distance(particle.transform.position, cameraTransform.position) > despawnRadius)
            {
                particlePool.ReturnParticle(particle);
                activeParticles.RemoveAt(i);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(cameraTransform.position, spawnRadius);
    }
}
