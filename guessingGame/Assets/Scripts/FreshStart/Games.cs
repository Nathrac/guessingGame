using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Games : MonoBehaviour
{
    [SerializeField] Renderer[] colors;
    [SerializeField] Material[] lightMat;
    [SerializeField] Material[] darkMat;
   

    int optionChoice;

    [SerializeField] float flashLength;
    float flashLengthCount;
    [SerializeField] float downTime;
    float downTimeCount;
    [SerializeField] float startWait;


    bool shouldFlash;
    bool shouldDarken;

    public List<int> recipe = new List<int>();
    int placeInRecipe;
   
    public bool playerCanInput;
    int inputRecipe;

    [SerializeField] GameObject colorGroup;
    CountdownTimer Timer;

    // Start is called before the first frame update
    void Start()
    {
        colorGroup.SetActive(true);
        StartCoroutine(Begin());
        Timer = FindObjectOfType<CountdownTimer>();
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
        if (Timer.timeNow <= 0)
        {
            colorGroup.SetActive(false);
            playerCanInput = false;
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

                inputRecipe++;

                if (inputRecipe >= recipe.Count)
                {
                    inputRecipe = 0;
                    placeInRecipe = 0;
                   
                    AddToRecipe();

                    playerCanInput = false;

                    Points.score += 1;
                    Debug.Log("Correct");

                }
            }
            else
            {
                Debug.Log("Wrong");
                StartCoroutine(Begin());

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
    IEnumerator Begin()
    {
        yield return new WaitForSeconds(startWait);
        StartGame();
    }
}
