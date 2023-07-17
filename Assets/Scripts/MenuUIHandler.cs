using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public Text highScoreText;
    public string playerName;

    private void Start()
    {
        DisplayHighScore();
    }

    public void GetPlayerName(string name)
    {
        playerName = name;
    }

    public void StartNewGame()
    {
        MenuManager.instance.playerName = playerName;
        SceneManager.LoadScene(1);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        MenuManager.instance.SaveHighScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void DisplayHighScore()
    {
        highScoreText.text = $"Best Score : {MenuManager.instance.highestScoringPlayer} :"
            + $" {MenuManager.instance.highestScore}";
    }

    public void ResetHighScore()
    {
        MenuManager.instance.ResetHighScore();
    }
}
