using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{

    public float timeNow = 0f;
    public float timeStart;

    [SerializeField] Text countdown;

    // Start is called before the first frame update
    void Start()
    {
        timeNow = timeStart;
    }

    // Update is called once per frame
    void Update()
    {
        timeNow -= 1 * Time.deltaTime;
        countdown.text = timeNow.ToString("0");

        if (timeNow <= 0)
        {
            timeNow = 0;
        }
        if (timeNow < 10)
        {
            countdown.color = Color.red;
        }
    }
}
