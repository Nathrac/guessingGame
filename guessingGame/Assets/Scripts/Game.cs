using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    [SerializeField] GameObject[] options;
    [SerializeField] List<int> taskOrder = new List<int>();
    [SerializeField] List<int> playerInput = new List<int>();

    int score = 0;
    int buttonsPressed = 0;
    bool pass = false;

    // Start is called before the first frame update
    void Start()
    {
        taskOrder.Clear();
        playerInput.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddtoTask()
    {
        int order = Random.Range(0, options.Length);
        taskOrder.Add(order);
    }


}


