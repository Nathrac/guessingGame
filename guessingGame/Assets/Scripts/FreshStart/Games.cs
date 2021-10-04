using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Games : MonoBehaviour
{
    public Renderer[] colors;
    public Material[] lightMat;
    public Material[] darkMat;

    int optionChoice;

    public float flashLength;
    float flashLengthCount;
    public float downTime;
    float downTimeCount;

    bool shouldFlash;
    bool shouldDarken;

    public List<int> recipe = new List<int>();
    int placeInRecipe;
   
    bool playerCanInput;
    int inputRecipe;


    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldFlash)
        {
            flashLengthCount -= Time.deltaTime;

            if (flashLengthCount < 0)
            {
                colors[recipe[placeInRecipe]].material = darkMat[recipe[placeInRecipe]];
                shouldFlash = false;

                shouldDarken = true;
                downTimeCount = downTime;

                placeInRecipe++;
            }
        }

        if (shouldDarken)
        {
            downTimeCount -= Time.deltaTime;

            if (placeInRecipe >= recipe.Count)
            {
                shouldDarken = false;
                playerCanInput = true;
            }
            else
            {
                if (downTimeCount < 0)
                {
                    colors[recipe[placeInRecipe]].material = lightMat[recipe[placeInRecipe]];

                    flashLengthCount = flashLength;
                    shouldFlash = true;
                    shouldDarken = false;
                }
            }
        }
    }

    public void StartGame()
    {
        placeInRecipe = 0;
        inputRecipe = 0;
        recipe.Clear();
        

        AddToRecipe();
    }

    public void optionPicked(int choice)
    {
        if (playerCanInput)
        {
            
            if (recipe[inputRecipe] == choice)
            {
                Debug.Log("Correct");

                inputRecipe++;

                if (inputRecipe >= recipe.Count)
                {
                    inputRecipe = 0;
                    placeInRecipe = 0;
                   
                    AddToRecipe();

                    playerCanInput = false;
                }
            }
            else
            {
                Debug.Log("Wrong");
                playerCanInput = false;

            }
        }
    }

    private void AddToRecipe()
    {
        recipe.Clear();
        for (int i = 0; i < 4; i++)
        {
            optionChoice = Random.Range(0, colors.Length);

            recipe.Add(optionChoice);

            colors[recipe[placeInRecipe]].material = lightMat[recipe[placeInRecipe]];

            flashLengthCount = flashLength;
            shouldFlash = true;
        }
     
    }
}
