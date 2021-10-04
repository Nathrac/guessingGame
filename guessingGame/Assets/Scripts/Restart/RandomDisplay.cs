using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDisplay : MonoBehaviour
{

    [SerializeField] int[] options;
    [SerializeField] List<int> taskOrder = new List<int>();
    public List<int> playerOrder = new List<int>();
    public GameObject Display;
    public Material[] materials;
    Material newColor;
    [SerializeField] Material basic;


    public float displayTime = 1f;
    public float downTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Logic());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddtoTask()
    {
        int order = Random.Range(0, options.Length);
        newColor = materials[order];
        taskOrder.Add(order);
        Display.GetComponent<MeshRenderer>().material = newColor;
    }
    private IEnumerator Logic()
    {
        yield return new WaitForSeconds(1f);
        int order = Random.Range(0, options.Length);
        newColor = materials[order];
        taskOrder.Add(order);
        Display.GetComponent<MeshRenderer>().material = newColor;
        yield return new WaitForSeconds(displayTime);
        Display.GetComponent<MeshRenderer>().material = basic;
        yield return new WaitForSeconds(downTime);
    }
}
