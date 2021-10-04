using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueInput : MonoBehaviour
{
    // Two tones of materials to have a sense of feedback for when player picks colors.
    public Material drkMaterial;
    public Material lightMaterial;
    private Renderer render;

    public int identity;

    public delegate void PickedColor(int number);
    public event PickedColor chosen;

    //Initialize render components.
    private void Awake()
    {
        render = GetComponent<Renderer>();
        render.enabled = true;
    }
  


    //When player clicks a color, it swaps to a lighter version to confirm the color was picked
    private void OnMouseDown()
    {
        Picked();
        chosen.Invoke(identity);
    }

    //Reverts colour back to noraml when not picked
    private void OnMouseUp()
    {
        UnpickedColor();
    }

    //Renders colour to light material
    public void Picked()
    {
        render.sharedMaterial = lightMaterial;

    }

    //Renders color to normal dark material
    public void UnpickedColor()
    {
        render.sharedMaterial = drkMaterial;
    }



}

