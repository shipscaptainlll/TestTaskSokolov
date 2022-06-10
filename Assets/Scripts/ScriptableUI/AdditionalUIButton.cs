using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class AdditionalUIButton : FlexibleUI
{
    public enum ButtonType
    {
        backButton
    }

    Image image;
    Button button;


    public ButtonType buttonType;

    public event Action buttonClicked = delegate { };

    private void Start()
    {
        button.onClick.AddListener(NotifyUIOpener);
    }

    void NotifyUIOpener()
    {
        buttonClicked();
    }
    protected override void OnSkinUI()
    {
        base.OnSkinUI();

        image = GetComponent<Image>();
        button = GetComponent<Button>();

        image.type = Image.Type.Sliced;

        switch (buttonType)
        {
            case ButtonType.backButton:
                image.sprite = additionalUIData.backButtonImage;
                image.color = additionalUIData.backButtonColor;
                name = buttonType.ToString();
                break;
        }
    }
}
