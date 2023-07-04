using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] Button instructionsButton;
    [SerializeField] Button playButton;
    [SerializeField] Button exitButton;
    [SerializeField] GameObject instructions;

    private void OnEnable()
    {
        instructionsButton.onClick.AddListener(EnableInstructionsMenu);
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void OnDisable()
    {
        instructionsButton.onClick.RemoveAllListeners();
        playButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
    }

    public void EnableInstructionsMenu()
    {
        instructions.SetActive(true);
    }

    public void DisableInstructionsMenu()
    {
        instructions.SetActive(false);
    }

    public void PlayGame()
    {
        DisableInstructionsMenu();
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
