using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class ColorButton : FlexibleUI
{
    public enum ButtonType
    {
        Red,
        Blue,
        Green,
        Violet,
        White,
        Black
    }

    Image image;
    Button button;
    Color color;

    public ButtonType buttonType;

    public event Action<Color> colorChanged = delegate { };

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(NotifyMaterialChanger);
    }

    void NotifyMaterialChanger()
    {
        colorChanged(image.color);
    }

    protected override void OnSkinUI()
    {
        base.OnSkinUI();

        image = GetComponent<Image>();

        image.type = Image.Type.Sliced;

        switch (buttonType)
        {
            case ButtonType.Red:
                image.color = colorData.redColor;
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.Blue:
                image.color = colorData.blueColor;
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.Green:
                image.color = colorData.greenColor;
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.Violet:
                image.color = colorData.violetColor;
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.White:
                image.color = colorData.whiteColor;
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.Black:
                image.color = colorData.blackColor;
                gameObject.name = buttonType.ToString();
                break;
                
        }
    }
}
