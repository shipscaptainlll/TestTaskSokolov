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
        carLightsButton
    }

    Image image;
    Button button;
    Text text;


    public ButtonType buttonType;

    public event Action<String> buttonClicked = delegate { };

    private void Start()
    {
        button.onClick.AddListener(NotifyUIOpener);
    }

    void NotifyUIOpener()
    {
        buttonClicked(buttonType.ToString());
    }
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
        }
    }
}
