using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInputs : MonoBehaviour
{
    GameObject[] spawnPoints;
    [SerializeField] GameObject inputPrefab;
    [SerializeField] int x;
    [SerializeField] int y;
    [SerializeField] int z;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawn");
        foreach (GameObject spawn in spawnPoints)
        {
            GameObject spawnObj = Instantiate(inputPrefab, spawn.transform, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
