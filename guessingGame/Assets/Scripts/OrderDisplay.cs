using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderDisplay : MonoBehaviour
{


    List<Material> taskOrder = new List<Material>();
    List<Material> playerOrder = new List<Material>();
    public Material[] materials;
    Material newColor;
    public GameObject Display;

    // Start is called before the first frame update
    void Start()
    {
        AddtoTaskOrder();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void AddtoTaskOrder()
    {
        for (int i = 0; i < 4; i++)
        {
            int randColor = Random.Range(0, materials.Length);
            newColor = materials[randColor];
            taskOrder.Add(newColor);
            Display.GetComponent<MeshRenderer>().material = newColor;
        }

    }
}
