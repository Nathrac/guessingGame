using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Points : MonoBehaviour
{
    public static int score = 0; //int is static so that we don't have to access object before accessing script component in Games script
    Text points;


    // Start is called before the first frame update
    void Start()
    {
        points = GetComponent<Text>();//gets text components to set points.
    }

    // Update is called once per frame
    void Update()
    {
        points.text = "Score: " + score;//display score to text UI object. Score is added in game script and stored in the "score" int. 
        Debug.Log(score); //add score to game console
        
    }
}
