using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoUI : MonoBehaviour
{
    public GameObject infoPanel;
    public Button startButton;

    void Start()
    {
        startButton.onClick.AddListener(() => infoPanel.SetActive(false));

        if (GameManager.Instance.isSecond)
        {
            infoPanel.SetActive(false);
        }
        else
        {
            infoPanel.SetActive(true);
            GameManager.Instance.isSecond = true;
        }
    }
}
