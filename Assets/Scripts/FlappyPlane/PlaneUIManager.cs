using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneUIManager : Singleton<PlaneUIManager>
{
    public GameObject gameoverPanel;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;

    public override void Awake()
    {
        SetInstance(gameObject);
    }

    void Start()
    {
        gameoverPanel.SetActive(false);
        restartText.gameObject.SetActive(false);
    }

    public void SetGameOverUI()
    {
        gameoverPanel.SetActive(true);
        restartText.gameObject.SetActive(true);
    }

    public void Restart()
    {
        gameoverPanel.SetActive(false);
        restartText.gameObject.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
