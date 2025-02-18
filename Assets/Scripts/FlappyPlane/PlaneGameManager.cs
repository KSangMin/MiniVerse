using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneGameManager : Singleton<PlaneGameManager>
{
    private int _score = 0;

    public override void Awake()
    {

    }

    public void AddScore(int s)
    {
        _score += s;
        Debug.Log(_score);
        PlaneUIManager.Instance.UpdateScore(_score);
    }

    public void GameOver()
    {
        Debug.Log("게임오버");
        PlaneUIManager.Instance.SetGameOverUI();
    }

    public void RestartGame()
    {
        PlaneUIManager.Instance.Restart();
        PlayerPrefs.SetInt("PlaneHighScore", Mathf.Max(_score, PlayerPrefs.GetInt("PlaneHighScore", 0)));
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _score = 0;
        PlaneUIManager.Instance.UpdateScore(_score);
    }
}
