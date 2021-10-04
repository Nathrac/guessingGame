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

        AddToRecipe();
    }

    public void optionPicked(int choice)
    {
        if(optionChoice == choice)
        {
            Debug.Log("Correct");
        }
        else
        {
            Debug.Log("Wrong");

        }
    }

    private void AddToRecipe()
    {
        optionChoice = Random.Range(0, colors.Length);

        recipe.Add(optionChoice);

        colors[recipe[placeInRecipe]].material = lightMat[recipe[placeInRecipe]];

        flashLengthCount = flashLength;
        shouldFlash = true;
    }
}
