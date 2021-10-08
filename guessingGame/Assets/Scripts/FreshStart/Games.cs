using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Games : MonoBehaviour
{
    [SerializeField] Material[] lightMat; //materials for lighter version to represent flash to either show options or click
    [SerializeField] Material[] darkMat; //materials to set options back to normal
    
    int optionChoice;

    //times for recipe flash, time between flashes and start game that can be changed in the editor.
    [SerializeField] float flashLength;
    float flashLengthCount;
    [SerializeField] float downTime;
    float downTimeCount;
    [SerializeField] float startWait;
    [SerializeField] float resetWait;

    //Setting recipe options to flash or return to normal 
    bool shouldFlash;
    bool shouldDarken;

    //Needed Recipe displayed to player
    public List<int> recipe = new List<int>();
    int placeInRecipe;
    [SerializeField] int recipeLenght;
    
    public bool playerCanInput; //Turn on and off to stop player input during recipe display and restarts
    int inputRecipe; //check next recipe option to identity choice

    [SerializeField] GameObject colorGroup; //object slot for parent of option/display objects
    CountdownTimer Timer; //Reference to timer script as to create stop protocol for when timer hits 0.


    // Start is called before the first frame update
    void Start()
    {
        colorGroup.SetActive(true);
        StartCoroutine(Begin()); // coroutine with startgame method so that there can be a delay before color flashes
        Timer = FindObjectOfType<CountdownTimer>(); //initializing Timer class with countdownTimer script acces 
       
    }

    // Update is called once per frame
    void Update()
    {

        if(shouldFlash) //object should flash if applied
        {
            flashLengthCount -= Time.deltaTime;

            if (flashLengthCount < 0) //if flash length is less than zero(aka no longer flashing), material is dark/neutral and place in recipe is moved up. 
            {
                GameObject.FindGameObjectWithTag(recipe[placeInRecipe].ToString()).GetComponent<Renderer>().material = darkMat[recipe[placeInRecipe]];
                shouldFlash = false;

                shouldDarken = true;
                downTimeCount = downTime;

                placeInRecipe++;
            }
        }

        if (shouldDarken) //object darkens
        {
            downTimeCount -= Time.deltaTime;

            if (placeInRecipe >= recipe.Count)//checks if flash sequence is over and lets player input
            {
                shouldDarken = false;
                playerCanInput = true;
            }
            else
            {
                if (downTimeCount < 0)//object lights up as next object in recipe sequence 
                {
                    GameObject.FindGameObjectWithTag(recipe[placeInRecipe].ToString()).GetComponent<Renderer>().material = lightMat[recipe[placeInRecipe]];

                    flashLengthCount = flashLength;
                    shouldFlash = true;
                    shouldDarken = false;
                }
            }
        }
        if (Timer.timeNow <= 0)//once time runs out, objects de activate and player can no longer input anything.
        {
            colorGroup.SetActive(false);
            playerCanInput = false;
        }
    }

    public void StartGame() //starts game by setting up booleans and resets positions in list integers
    {
        shouldFlash = true;
        placeInRecipe = 0;
        inputRecipe = 0;
        recipe.Clear();
        
        AddToRecipe();
    }

    public void optionPicked(int choice)//adding values to player input recipe and when they are equal, move up the recipe and check again until the player recipe size is eu
    {
        if (playerCanInput)
        {
            
            if (recipe[inputRecipe] == choice) //checks if player choice of input has an equal identiy as the recipe. If yes than continue checking by moving to the next input, if no turn off player input ability and restart.
               
            {

                inputRecipe++;

                if (inputRecipe >= recipe.Count) //if player inputs recipe correctly until their input counts are equal to the recipe count then reset for new round and add to score
                {
                    inputRecipe = 0;
                    placeInRecipe = 0;

                    StartCoroutine(Begin());

                    playerCanInput = false;

                    Points.score += 1; //only adds a point if the player guesses the full routine correctly

                    Debug.Log("Correct");

                }
            }
            else//if player inputs wrong then objects will darken to neutral colour and player can no longer input. Send "wrong" to long and restart game with "begin" coroutine.
            
            {
                playerCanInput = false;
                shouldDarken = false;
                Debug.Log("Wrong");
                StartCoroutine(Begin());
            }
        }
    }

    private void AddToRecipe()//method that adds to recipe for player to guess. Clears previous recipe before inputting new one and turns off player input so they cant interact with buttons and distract themselves.
    {
        playerCanInput = false;
        recipe.Clear();
        for (int i = 0; i < recipeLenght; i++) //sets recipe length to integer that is chosen in the inspector so as not to hard code length
        {
            optionChoice = Random.Range(0, darkMat.Length); //chooses randomly from color array filled with object render materials.

            recipe.Add(optionChoice);
          
            StartCoroutine(Flashing()); //flashes the random component material but in a lighter material as to show player

            flashLengthCount = flashLength;
            shouldFlash = true;
            
        }
     
    }
    IEnumerator Begin() //Start game funcntion but added to coroutine as to add wait time before game starts
    {
        yield return new WaitForSeconds(startWait);
        StartGame();
    }
   IEnumerator Flashing() //Flashing of Recipe Options
    {
        yield return new WaitForSeconds(0.1f);
        GameObject.FindGameObjectWithTag(recipe[placeInRecipe].ToString()).GetComponent<Renderer>().material = lightMat[recipe[placeInRecipe]];
    }
}
