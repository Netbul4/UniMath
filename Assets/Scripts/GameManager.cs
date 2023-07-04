using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Problem[] problems;      // list of all problems
    public int curProblem;          // current problem the player needs to solve
    public float timePerProblem;    // time allowed to answer each problem
    public float remainingTime;     // time remaining for the current problem
    public PlayerController player; // player object
    public GameWave gameWave;

    // instance
    public static GameManager instance;
    void Awake()
    {
        // set instance to this script.
        instance = this;
    }

    void Start()
    {
        // set the initial problem
        SetProblem(0);
    }

    // called when the player answers all the problems
    void Win()
    {
        UI.instance.SetEndText(true);
        // set UI text
    }
    // called if the remaining time on a problem reaches 0
    void Lose()
    {
        UI.instance.SetEndText(false);
        // set UI text
    }

    // sets the current problem
    void SetProblem(int problem)
    {
        StartCoroutine(gameWave.Spawn(problems[problem].answers));
        curProblem = problem;
        UI.instance.SetProblemText(problems[curProblem]);
        remainingTime = timePerProblem;
        // set UI text to show problem and answers
    }

    // called when the player enters the correct tube
    void CorrectAnswer()
    {
        Debug.Log("THAT'S CORRECT!");
        SetProblem(curProblem == problems.Length - 1 ? 0 : curProblem + 1);
    }
    // called when the player enters the incorrect tube
    void IncorrectAnswer()
    {
        Debug.Log("THAT'S INCORRECT!");
        remainingTime--;
        // player.Stun();
    }

    // called when the player enters a tube
    public void OnPlayerShot(int answer)
    {
        // did they enter the correct tube?
        if (answer == problems[curProblem].correctAnswer)
            CorrectAnswer();
        else
            IncorrectAnswer();
    }

    void Update()
    {
        remainingTime -= Time.deltaTime;
        // has the remaining time ran out?
        if (remainingTime <= 0.0f)
        {
            Lose();
        }
    }
}
