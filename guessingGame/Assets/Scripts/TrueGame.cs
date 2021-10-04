using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrueGame : MonoBehaviour
{
    public TrueInput[] options;

    public float displayTime = 0.5f;
    public float downTime = 0.5f;

    bool robot = false;
    bool player = false;

    int randNum;





    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].chosen += ButtonClicked;
            options[i].identity = i;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ButtonClicked(int mynumber)
    {

    }

    private IEnumerator Logic()
    {
        yield return new WaitForSeconds(1f);
        randNum = Random.Range(0, options.Length);
        options[randNum].Picked();
        yield return new WaitForSeconds(displayTime);
        options[randNum].UnpickedColor();
        yield return new WaitForSeconds(downTime);
    }

    void StartGame()
    {
        StartCoroutine(Logic());
    }
    void GameOver()
    {

    }
}
