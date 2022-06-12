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
        englishLanguage,
        screenShotButton
    }

    Image image;
    Button button;
    Text text;


    public ButtonType buttonType;

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
                button.onClick.AddListener(OpenMainTable);
                button.onClick.AddListener(OpenMainTable);
                break;
            case ButtonType.carLightsButton:
                image.sprite = additionalUIData.carLightsImage;
                CarLightsSwitcher.lightsButtonMaterial = image;
                image.color = Color.black;
                text.text = additionalUIData.carLightsText;
                name = buttonType.ToString();
                button.onClick.AddListener(SwitchLights);
                break;
            case ButtonType.czechLanguage:
                image.sprite = additionalUIData.czFlagImage;
                image.color = Color.white;
                text.text = additionalUIData.czechLanguageName;
                name = buttonType.ToString();
                button.onClick.AddListener(ChangeLanguage);
                break;
            case ButtonType.englishLanguage:
                image.sprite = additionalUIData.engFlagImage;
                image.color = Color.white;
                text.text = additionalUIData.englishLanguageName;
                name = buttonType.ToString();
                button.onClick.AddListener(ChangeLanguage);
                break;
            case ButtonType.screenShotButton:
                image.sprite = additionalUIData.screenShotImage;
                image.color = Color.white;
                text.text = additionalUIData.screenShotName;
                name = buttonType.ToString();
                button.onClick.AddListener(TakeScreenShot);
                break;
        }
    }

    void OpenMainTable()
    {
        UITablesOpener.ShowTable(buttonType.ToString());
        OrbitCamera.ChangeTarget(buttonType.ToString());
    }

    void SwitchLights()
    {
        CarLightsSwitcher.ControlLightsState(buttonType.ToString());
    }

    void ChangeLanguage()
    {
        LocaleSelector.ChangeLocale(buttonType.ToString());
    }
    void TakeScreenShot()
    {
        ScreenShot.TakeScreenshot();
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
                image.color = Color.white;
                text.text = additionalUIData.czechLanguageName;
                name = buttonType.ToString();
                break;
            case ButtonType.englishLanguage:
                image.sprite = additionalUIData.engFlagImage;
                image.color = Color.white;
                text.text = additionalUIData.englishLanguageName;
                name = buttonType.ToString();
                break;
            case ButtonType.screenShotButton:
                image.sprite = additionalUIData.screenShotImage;
                image.color = Color.white;
                text.text = additionalUIData.screenShotName;
                name = buttonType.ToString();
                break;
        }
    }
}
