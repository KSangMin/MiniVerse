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
        PlaneUIManager.Instance.UpdateScore(_score);
    }

    public void GameOver()
    {
        Debug.Log("���ӿ���");
        PlayerPrefs.SetInt("PlaneHighScore", Mathf.Max(_score, PlayerPrefs.GetInt("PlaneHighScore", 0)));
        PlaneUIManager.Instance.SetGameOverUI();
    }

    public void RestartGame()
    {
        PlaneUIManager.Instance.SetStartUI();
        _score = 0;
        PlaneUIManager.Instance.UpdateScore(_score);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
