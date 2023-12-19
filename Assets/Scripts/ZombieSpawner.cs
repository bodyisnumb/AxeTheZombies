using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform[] spawnPoints;
    public int maxSimultaneousZombies = 5;
    public float spawnInterval = 2f;

    private int currentZombies;

    void Start()
    {
        StartCoroutine(SpawnZombies());
    }

    IEnumerator SpawnZombies()
    {
        while (true)
        {
            // Check if we can spawn more zombies
            if (currentZombies < maxSimultaneousZombies)
            {
                // Randomly select a spawn point
                int randomIndex = Random.Range(0, spawnPoints.Length);
                Transform spawnPoint = spawnPoints[randomIndex];

                // Instantiate a new zombie at the spawn point
                Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);
                
                // Increment the current zombie count
                currentZombies++;
            }

            // Wait for the specified interval before attempting to spawn another zombie
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // This function should be called by your zombie when it gets destroyed
    public void ZombieDestroyed()
    {
        // Decrement the current zombie count
        currentZombies = Mathf.Max(0, currentZombies - 1);
    }
}
