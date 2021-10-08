using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{

    [SerializeField] Material[] drkMaterial;
    [SerializeField] Material[] lightMaterial;

    public Renderer render;

    public int identity;

    Games LogicController; //referncing Games script to access public script components

    
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>(); //access renderer to change button colors
        render.enabled = true;
        render.material = drkMaterial[identity];
        LogicController = FindObjectOfType<Games>(); //Setting LogicController as reference to script
    }

    //When player clicks a color, it swaps to a lighter version to confirm the color was picked
    private void OnMouseDown()
    {
        if (LogicController.playerCanInput == true)
        {
            PickedColor();
        }
    }

    //Reverts colour back to noraml when not picked and also adds playerinput when released as to give for player to react at their own pace
    private void OnMouseUp()
    {
        if (LogicController.playerCanInput == true)//when player can interact add to choice using object identity
        {
            UnpickedColor();
            LogicController.optionPicked(identity);
        }
    }

    //Renders colour to light material
    public void PickedColor()
    {
        render.sharedMaterial = lightMaterial[identity];
    }

    //Renders color to normal dark material
    public void UnpickedColor()
    {
        render.sharedMaterial = drkMaterial[identity];
    }
}
