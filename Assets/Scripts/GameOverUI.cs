using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] Button retryButton;
    [SerializeField] Button closeButton;

    private void OnEnable()
    {
        retryButton.onClick.AddListener(Retry);
        closeButton.onClick.AddListener(Close);
    }

    private void OnDisable()
    {
        retryButton.onClick.RemoveAllListeners();
        closeButton.onClick.RemoveAllListeners();
    }

    void Retry()
    {
        SceneManager.LoadScene(1);
    }

    void Close()
    {
        Application.Quit();
    }
}
