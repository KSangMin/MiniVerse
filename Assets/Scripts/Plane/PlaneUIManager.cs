using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlaneUIManager : Singleton<PlaneUIManager>
{
    public GameObject infoPanel;
    public Button startButton;

    public TextMeshProUGUI timerText;

    public TextMeshProUGUI scoreText;

    public GameObject gameoverPanel;
    public Button restartButton;
    public Button exitButton;

    public override void Awake()
    {
        isGlobal = false;

        base.Awake();
    }

    void Start()
    {
        SetUIStart();
        startButton.onClick.AddListener(GameStart);
        exitButton.onClick.AddListener(() => SceneManager.LoadScene("Main"));
        restartButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
    }

    public void SetUIGameOver()
    {
        gameoverPanel.SetActive(true);
    }

    public void SetUIStart()
    {
        infoPanel.SetActive(true);
        timerText.gameObject.SetActive(false);
        gameoverPanel.SetActive(false);
    }

    public void GameStart()
    {
        PlaneGameManager.Instance.StartGame();
        infoPanel.SetActive(false);
        timerText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
