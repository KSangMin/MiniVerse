using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarManager : Singleton<AvatarManager>
{
    public GameObject player;

    public GameObject avatarBackground;

    public Image tempImage;

    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;

    public Button applybutton;
    public Button exitbutton;

    Color curColor;

    public override void Awake()
    {
        isGlobal = false;

        base.Awake();
    }

    private void Start()
    {
        avatarBackground.SetActive(false);

        ResetUI();

        redSlider.onValueChanged.AddListener(OnRedSliderChanged);
        greenSlider.onValueChanged.AddListener(OnGreenSliderChanged);
        blueSlider.onValueChanged.AddListener(OnBlueSliderChanged);

        applybutton.onClick.AddListener(Apply);
        exitbutton.onClick.AddListener(ToggleAvatar);
    }

    void OnAvatar()
    {
        TurnOffAvatar();
    }

    public void TurnOnAvatar()
    {
        avatarBackground.SetActive(true);
    }

    public void TurnOffAvatar()
    {
        avatarBackground.SetActive(false);
    }

    public void ToggleAvatar()
    {
        avatarBackground.SetActive(!avatarBackground.activeSelf);

        if(avatarBackground.activeSelf == true)
        {
            ResetUI();

        }
        else
        {
            
        }
    }

    void ResetUI()
    {
        curColor = player.GetComponentInChildren<SpriteRenderer>().color;

        tempImage.sprite = player.GetComponentInChildren<SpriteRenderer>().sprite;
        tempImage.color = curColor;

        redSlider.value = curColor.r;
        greenSlider.value = curColor.g;
        blueSlider.value = curColor.b;
    }

    void OnRedSliderChanged(float value)
    {
        curColor.r = value;
        tempImage.color = curColor;
    }

    void OnGreenSliderChanged(float value)
    {
        curColor.g = value;
        tempImage.color = curColor;
    }

    void OnBlueSliderChanged(float value)
    {
        curColor.b = value;
        tempImage.color = curColor;
    }

    void Apply()
    {
        player.GetComponentInChildren<SpriteRenderer>().color = curColor;
        ToggleAvatar();
    }
}
