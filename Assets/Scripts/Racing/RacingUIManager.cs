using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RacingUIManager : Singleton<RacingUIManager>
{
    public GameObject gameOverPanel;
    public GameObject infoPanel;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    public Button startButton;
    public Button restartButton;
    public Button exitButton;

    public override void Awake()
    {
        isGlobal = false;

        base.Awake();
    }

    void Start()
    {
        startButton.onClick.AddListener(SetUIStart);
        restartButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
        exitButton.onClick.AddListener(() => SceneManager.LoadScene("Main"));

        SetUIAwake();
    }

    public void SetUIAwake()
    {
        RacingGameManager.Instance.isGameStopped = true;

        infoPanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    public void SetUIStart()
    {
        RacingGameManager.Instance.isGameStopped = false;

        infoPanel.SetActive(false);
    }

    public void SetUIGameOver()
    {
        highScoreText.text = PlayerPrefs.GetInt("RacingHighScore", 0).ToString();

        gameOverPanel.SetActive(true);
    }

    public void SetScore(int t)
    {
        scoreText.text = t.ToString();
    }
}
