using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{

    public float timeNow = 0f; // initialize time now
    [SerializeField] float timeStart; //Set time start in inspector 

    [SerializeField] Text countdown;

    // Start is called before the first frame update
    void Start()
    {
        timeNow = timeStart; //timeNow is equal to value we put in inspector
    }

    // Update is called once per frame
    void Update()
    {
        timeNow -= 1 * Time.deltaTime; //Take one second away from timer
        countdown.text = timeNow.ToString("0");//set so that the timer does not show decimals
        Debug.Log(timeNow);

        if (timeNow <= 0)
        {
            timeNow = 0;
        }
        if (timeNow < 10)//when timer gets below 10 change timer color to red to add a little stress to player. 
        {
            countdown.color = Color.red;
        }
    }
}
