using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject[] roadPrefabs;
    private Transform playerTransform;

    private float roadLength = 58.0f;
    private float spawnZ = 0.0f;
    private int amOfPrefabs = 3;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;     
        for (int i = 0; i < amOfPrefabs; i++)
        {
            SpawnRoad();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z > (spawnZ - amOfPrefabs * roadLength))
        {
            SpawnRoad();
        }
    }
    // Spawns one road prefab and puts the clone inside RoadManager hierarchy object
    void SpawnRoad()
    {
        int prefabIndex = Random.Range(0, 2);
        GameObject go;
        go = Instantiate(roadPrefabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += roadLength;
    }
}