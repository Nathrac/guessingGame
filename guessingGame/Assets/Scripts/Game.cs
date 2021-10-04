using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    [SerializeField] GameObject[] options;
    [SerializeField] List<int> taskOrder = new List<int>();
    public List<int> playerOrder = new List<int>();
    public GameObject Display;
    public Material[] materials;
    Material newColor;
    private Renderer render;
    public GameObject startButton;

    // Two tones of materials to have a sense of feedback for when player picks colors.
    public Material drkMaterial;
    public Material lightMaterial;

    int score = 0;
    int buttonsPressed = 0;
    bool pass = false;

    //Initialize render components.
    private void Awake()
    {
        render = GetComponent<Renderer>();
        render.enabled = true;

    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        buttonsPressed = 0;
        taskOrder.Clear();
        playerOrder.Clear();

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

    public void AddtoInput(int button)
    {
        playerOrder.Add(button);
        for (int i = 0; i < playerOrder.Count; i++)
        {
            if (taskOrder[i] == playerOrder[i])
            {
                continue;
            }
            else
            {
                Debug.Log("wrong");
                return;
            }
        }
        if (playerOrder.Count == taskOrder.Count)
        {
            Debug.Log("StartNExtround");
        }
    }

    public void StartGame()
    {
        Debug.Log("StartNExtRound");
        startButton.SetActive(false);
    }

    public IEnumerator StartNextRound()
    {
        playerOrder.Clear();
        
        yield return null;
    }

   
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    //When player clicks a color, it swaps to a lighter version to confirm the color was picked
    private void OnMouseDown()
    {
        PickedColor();
    }

    //Reverts colour back to noraml when not picked
    private void OnMouseUp()
    {
        UnpickedColor();
    }

    //Renders colour to light material
    public void PickedColor()
    {
        render.sharedMaterial = lightMaterial;
    }

    //Renders color to normal dark material
    public void UnpickedColor()
    {
        render.sharedMaterial = drkMaterial;
    }

}


