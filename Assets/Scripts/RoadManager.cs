using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject[] roadPrefabs;
    private Transform playerTransform;

    private float roadLength = 58.0f;
    private float spawnZ = 0.0f;
    private int amOfPrefabs = 2;
    private int startingChildObjects;

    void Start()
    {
        // Assign player position to variable
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;     
        
        for (int i = 0; i < amOfPrefabs; i++)
        {
            SpawnRoad();
        }

        // Get the number of road prefabs at the beginning
        startingChildObjects = transform.childCount;
    }

    void Update()
    {
        // Spawn one road prefab depending on player position
        if (playerTransform.position.z > (spawnZ - amOfPrefabs * roadLength))
        {
            SpawnRoad();
        }
        // Destroy first road prefab (FIFO) if there are more than 4 in total  
        int updatedChildObjects = transform.childCount;
        if (updatedChildObjects - startingChildObjects > 2)
        {
            Destroy(GetComponent<Transform>().GetChild(0).gameObject);
        }
    }
    // Spawns one road prefab and puts the clone inside RoadManager as a child object
    void SpawnRoad()
    {
        int prefabIndex = Random.Range(0, roadPrefabs.Length);
        GameObject go;
        go = Instantiate(roadPrefabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += roadLength;
    }
}