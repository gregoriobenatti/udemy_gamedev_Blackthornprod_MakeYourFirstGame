using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] hazards;
    private float timeBetweenSpawns = 0f;
    public float startTimeBetweenSpawns = 1.25f;
    public float minTimeBetweenSpawns = 0.5f;
    public float decrease = 0.1f;
    public GameObject player;

    void Update()
    {
        if (player == null )
        {
            return;
        }

        if (timeBetweenSpawns <= 0)
        {
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject randomHazard = hazards[Random.Range(0, hazards.Length)];

            Instantiate(randomHazard, randomSpawnPoint.position, Quaternion.identity);

            if (startTimeBetweenSpawns > minTimeBetweenSpawns)
            {
                startTimeBetweenSpawns -= decrease;
            }

            timeBetweenSpawns = startTimeBetweenSpawns;
        }
        else
        {
            timeBetweenSpawns -= Time.deltaTime;
        }
    }
}
