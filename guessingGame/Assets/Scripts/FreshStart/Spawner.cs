using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] GameObject ballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnPoints.Length; i++)

        {
            GameObject ball = Instantiate(ballPrefab, spawnPoints[i].transform, false);
            ball.GetComponent<HitDetection>().identity = i;
            ball.tag = i.ToString();

        }
        
    }

}
