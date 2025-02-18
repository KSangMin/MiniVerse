using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGame : Interactable
{
    public string sceneName;
    public string GameName;

    public TextMeshProUGUI hScoreText;

    public override void Start()
    {
        base.Start();

        hScoreText.text = sceneName + "\nHighScore: " + PlayerPrefs.GetInt(GameName + "HighScore", 0);
    }

    public override void Interact()
    {
        base.Interact();

        SceneManager.LoadScene(sceneName);
    }
}
