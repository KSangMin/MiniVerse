using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlaneUIManager : Singleton<PlaneUIManager>
{
    public TextMeshProUGUI timerText;
    public GameObject gameoverPanel;
    public TextMeshProUGUI scoreText;
    public Button restartButton;
    public Button exitButton;

    public override void Awake()
    {
        SetInstance(gameObject);
    }

    void Start()
    {
        SetStartUI();
        exitButton.onClick.AddListener(() => SceneManager.LoadScene("Main"));
        restartButton.onClick.AddListener(() => PlaneGameManager.Instance.RestartGame());
    }

    public void SetGameOverUI()
    {
        gameoverPanel.SetActive(true);
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    public void SetStartUI()
    {
        gameoverPanel.SetActive(false);
        restartButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
