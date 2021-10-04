using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionValues : MonoBehaviour

{

    public int identity = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.name == "Red")
        {
            identity = 1;
        }
        else if (this.gameObject.name == "Green")
        {
            identity = 2;
        }
        else if (this.gameObject.name == "Teal")
        {
            identity = 3;
        }
        else if (this.gameObject.name == "Yellow")
        {
            identity = 4;
        }
        else if (this.gameObject.name == "Pink")
        {
            identity = 5;
        }
        else if (this.gameObject.name == "Blue")
        {
            identity = 6;
        }
    }
}
