using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float respawnFrequency;
    private float timeUntilNextSpawn;
    public GameObject obstaclePrefab;
    // Start is called before the first frame update
    void Start()
    {
        timeUntilNextSpawn = respawnFrequency;
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilNextSpawn -= Time.deltaTime;

        if (timeUntilNextSpawn <= 0f) {
            Vector3 spawnPosition = this.transform.position;
            spawnPosition.y += Random.Range(0.1f, 2.5f);

            timeUntilNextSpawn = respawnFrequency * Random.Range(0.1f, 4.8f);
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
