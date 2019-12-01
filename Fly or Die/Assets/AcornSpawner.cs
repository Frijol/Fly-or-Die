using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornSpawner : MonoBehaviour
{
    public float respawnFrequency;
    public float verticalVariance;
    public GameObject pickupPrefab;

    private float timeUntilNextSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timeUntilNextSpawn = respawnFrequency;

        // Add in a small random initial spawn variance
        timeUntilNextSpawn += Random.Range(0.1f, 4.8f);
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilNextSpawn -= Time.deltaTime;

        if (timeUntilNextSpawn <= 0f) {
            Vector3 spawnPosition = this.transform.position;
            spawnPosition.y += Random.Range(0.1f, verticalVariance);

            timeUntilNextSpawn = respawnFrequency * Random.Range(0.1f, 4.8f);
            Instantiate(pickupPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
