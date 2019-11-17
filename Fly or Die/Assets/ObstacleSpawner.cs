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
            timeUntilNextSpawn = respawnFrequency;
            Instantiate(obstaclePrefab, this.transform.position, Quaternion.identity);
        }
    }
}
