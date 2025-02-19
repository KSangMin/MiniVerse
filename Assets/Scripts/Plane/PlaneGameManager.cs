using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneGameManager : Singleton<PlaneGameManager>
{
    private int _score = 0;
    
    public Plane plane;

    public bool isStart = false;

    public override void Awake()
    {
        
    }

    public void AddScore(int s)
    {
        _score += s;
        PlaneUIManager.Instance.UpdateScore(_score);
    }

    public void StartGame()
    {
        plane = Instantiate(Resources.Load("Plane/Plane")).GetComponent<Plane>();
        isStart = true;
    }

    public void GameOver()
    {
        Debug.Log("게임오버");
        PlayerPrefs.SetInt("PlaneHighScore", Mathf.Max(_score, PlayerPrefs.GetInt("PlaneHighScore", 0)));
        PlaneUIManager.Instance.SetUIGameOver();
    }
}
