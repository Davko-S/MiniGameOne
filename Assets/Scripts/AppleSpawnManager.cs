using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawnManager : MonoBehaviour
{
    public GameObject[] applePrefabs;
    public GameObject[] enemyTruckPrefabs;
    
    private float spawnRangeX = 5.0f;
    private const float spawnPosY = 2.0f;
    private float playerStartPosZ;
    private float playerCurrentPosZ;

    private GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStartPosZ = player.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        playerCurrentPosZ = player.transform.position.z;

        if (playerCurrentPosZ - playerStartPosZ > 12)
        {
            SpawnApple();
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                SpawnEnemy();
            }
        }
    }

    void SpawnApple()    //Randomly generate apple index and spawn position
    {
        int appleIndex = Random.Range(0, applePrefabs.Length);
        float spawnDistanceZ = Random.Range(12, 16);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY , playerCurrentPosZ + spawnDistanceZ);
        Instantiate(applePrefabs[appleIndex], spawnPos, applePrefabs[appleIndex].transform.rotation);
        playerStartPosZ = player.transform.position.z;
    }

    void SpawnEnemy()    //Randomly generate enemy truck's index and spawn position
    {
        int enemyIndex = Random.Range(0, enemyTruckPrefabs.Length);
        float spawnDistanceZ = Random.Range(28, 33);
        float spawnLimitX = 2.0f;
        float spawnLimitY = 0.1f;
        Vector3 spawnPos = new Vector3(Random.Range(-spawnLimitX, spawnLimitX), spawnLimitY, playerCurrentPosZ + spawnDistanceZ);
        Instantiate(enemyTruckPrefabs[enemyIndex], spawnPos, enemyTruckPrefabs[enemyIndex].transform.rotation);
    }
}
