using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawnManager : MonoBehaviour
{
    public GameObject[] applePrefabs;
    
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
}
