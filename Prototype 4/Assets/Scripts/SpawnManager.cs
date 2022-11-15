using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public GameObject powerupPrefab;
    private float spawnRange = 9f;
    public int enemyCount = 0;
    public int wave = 1;
    
    void Start()
    {
        SpawnWave(wave);
        SpawnPowerup();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0)
        {
            wave++;
            SpawnWave(wave);
            SpawnPowerup();
        }
    }
    void SpawnWave(int wave)
    {
        for (int i = 0; i < wave; i++)
        {
            Instantiate(enemy, GenerateSpawnPosition(), enemy.transform.rotation);
        }
    }

    void SpawnPowerup()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(randomX, 0, randomZ);
        return randomPos;
    }
}
