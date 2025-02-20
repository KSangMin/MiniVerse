using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RacingGameManager : Singleton<RacingGameManager>
{
    public bool isGameStopped = false;

    public float timeScore;

    public override void Awake()
    {
        isGlobal = false;

        base.Awake();
    }

    private void Update()
    {
        if (isGameStopped)
        {
            return;
        }

        timeScore += Time.deltaTime;
        RacingUIManager.Instance.SetScore((int)timeScore);
    }

    public void GameOver()
    {
        isGameStopped = true;
        PlayerPrefs.SetInt("RacingHighScore", Mathf.Max(((int)timeScore), PlayerPrefs.GetInt("RacingHighScore", 0)));
        RacingUIManager.Instance.SetUIGameOver();
    }
}
