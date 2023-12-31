using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Problem;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject gameOverObject;
    [SerializeField] TextMeshProUGUI problemText;                // text that displays the maths problem
    [SerializeField] Image remainingTimeDial;         // remaining time image with radial fill
    [SerializeField] TextMeshProUGUI endText;                    // text displayed a the end of the game (win or game over)

    private float remainingTimeDialRate;    // 1.0 / time per problem


    // instance
    public static UI instance;
    void Awake()
    {
        // set instance to be this script
        instance = this;
    }

    void Start()
    {
        // set the remaining time dial rate
        // used to convert the time per problem (8 secs for example)
        // and converts that to be used on a 0.0 - 1.0 scale
        remainingTimeDialRate = 1.0f / GameManager.instance.timePerProblem;
    }

    void Update()
    {
        // update the remaining time dial fill amount
        remainingTimeDial.fillAmount = remainingTimeDialRate * GameManager.instance.remainingTime;
    }

    // sets the ship UI to display the new problem
    public void SetProblemText(Problem problem)
    {
        string operatorText = "";
        // convert the problem operator from an enum to an actual text symbol
        switch (problem.operation)
        {
            case MathsOperation.Addition: operatorText = " + "; break;
            case MathsOperation.Subtraction: operatorText = " - "; break;
            case MathsOperation.Multiplication: operatorText = " x "; break;
            case MathsOperation.Division: operatorText = " � "; break;
        }
        // set the problem text to display the problem
        problemText.text = problem.firstNumber + operatorText + problem.secondNumber;
    }

    // sets the end text to display if the player won or lost
    public void SetEndText(bool win)
    {
        // enable the end text object
        gameOverObject.SetActive(true);
        endText.gameObject.SetActive(true);
        // did the player win?
        if (win)
        {
            endText.text = "You Win!";
            endText.color = Color.green;
        }
        // did the player lose?
        else
        {
            endText.text = "Game Over!";
            endText.color = Color.red;
        }
    }


}
