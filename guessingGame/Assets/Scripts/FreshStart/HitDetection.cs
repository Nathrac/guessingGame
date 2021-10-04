using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{

    [SerializeField] Material drkMaterial;
    [SerializeField] Material lightMaterial;

    private Renderer render;

    public int identity;

    private Games LogicController;

    
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        render.enabled = true;
        LogicController = FindObjectOfType<Games>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //When player clicks a color, it swaps to a lighter version to confirm the color was picked
    private void OnMouseDown()
    {
        if (LogicController.playerCanInput == true)
        {
            PickedColor();
        }
    }

    //Reverts colour back to noraml when not picked
    private void OnMouseUp()
    {
        if (LogicController.playerCanInput == true)
        {
            UnpickedColor();
            LogicController.optionPicked(identity);
        }
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
