using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Two tones of materials to have a sense of feedback for when player picks colors.
    public Material drkMaterial;
    public Material lightMaterial;

    private Renderer render;


    //Initialize render components.
    private void Awake()
    {
        render = GetComponent<Renderer>();
        render.enabled = true;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

