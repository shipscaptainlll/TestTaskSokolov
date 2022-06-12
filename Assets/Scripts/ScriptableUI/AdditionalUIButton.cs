using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Text))]
public class AdditionalUIButton : FlexibleUI
{
    public enum ButtonType
    {
        backButton,
        carLightsButton,
        czechLanguage,
        englishLanguage
    }

    Image image;
    Button button;
    Text text;


    public ButtonType buttonType;

    public event Action<String> buttonClicked = delegate { };
    public event Action<String> languageSelected = delegate { };

    private void Start()
    {
        button = GetComponent<Button>();
        UIInitialisation();
    }
    void UIInitialisation()
    {
        image = GetComponent<Image>();
        text = transform.Find("text").GetComponent<Text>();

        image.type = Image.Type.Sliced;

        switch (buttonType)
        {
            case ButtonType.backButton:
                image.sprite = additionalUIData.backButtonImage;
                text.text = " ";
                name = buttonType.ToString();
                button.onClick.AddListener(NotifyUIOpener);
                break;
            case ButtonType.carLightsButton:
                image.sprite = additionalUIData.carLightsImage;
                text.text = additionalUIData.carLightsText;
                name = buttonType.ToString();
                button.onClick.AddListener(NotifyUIOpener);
                break;
            case ButtonType.czechLanguage:
                image.sprite = additionalUIData.czFlagImage;
                text.text = additionalUIData.czechLanguageName;
                name = buttonType.ToString();
                button.onClick.AddListener(NotifyLocalizator);
                break;
            case ButtonType.englishLanguage:
                image.sprite = additionalUIData.engFlagImage;
                text.text = additionalUIData.englishLanguageName;
                name = buttonType.ToString();
                button.onClick.AddListener(NotifyLocalizator);
                break;
        }
    }

    void NotifyUIOpener()
    {
        buttonClicked(buttonType.ToString());
    }

    void NotifyLocalizator()
    {
        languageSelected(buttonType.ToString());
    }

    

    //UI update in Editor mode
    protected override void OnSkinUI()
    {
        base.OnSkinUI();

        image = GetComponent<Image>();
        button = GetComponent<Button>();
        text = transform.Find("text").GetComponent<Text>();

        image.type = Image.Type.Sliced;

        switch (buttonType)
        {
            case ButtonType.backButton:
                image.sprite = additionalUIData.backButtonImage;
                //image.color = additionalUIData.backButtonColor;
                text.text = " ";
                name = buttonType.ToString();
                break;
            case ButtonType.carLightsButton:
                image.sprite = additionalUIData.carLightsImage;
                text.text = additionalUIData.carLightsText;
                name = buttonType.ToString();
                break;
            case ButtonType.czechLanguage:
                image.sprite = additionalUIData.czFlagImage;
                text.text = additionalUIData.czechLanguageName;
                name = buttonType.ToString();
                break;
            case ButtonType.englishLanguage:
                image.sprite = additionalUIData.engFlagImage;
                text.text = additionalUIData.englishLanguageName;
                name = buttonType.ToString();
                break;
        }
    }
}
