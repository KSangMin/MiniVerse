using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGame : Interactable
{
    public GameObject sign;

    public string sceneName;
    public string GameName;

    public TextMeshProUGUI hScoreText;

    private void Start()
    {
        sign.SetActive(false);
        hScoreText.text = GameName + "\nHighScore: " + PlayerPrefs.GetInt(GameName + "HighScore", 0);
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.CompareTag("Player"))
        {
            sign.SetActive(true);
        }
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        base .OnTriggerExit2D(collision);

        if (collision.CompareTag("Player"))
        {
            sign.SetActive(false);
        }
    }

    public override void Interact()
    {
        SceneManager.LoadScene(sceneName);
    }
}
