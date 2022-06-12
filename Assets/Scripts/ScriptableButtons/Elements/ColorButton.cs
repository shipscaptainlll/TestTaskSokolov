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
        Black,
        redBlueBI,
        orangeDarkBI
    }

    Image image;
    Button button;
    Color colorMain;
    Color colorFresnel;
    bool colorBI;

    public ButtonType buttonType;

    //public event Action<Color> colorChanged = delegate { };
    //public event Action<Color, Color> colorBIChanged = delegate { };

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChangeColor);
        UIInitialisation();
    }
    /*
    void NotifyMaterialChanger()
    {
        if (!colorBI)
        {
            colorChanged(colorMain);
        } else
        {
            colorBIChanged(colorMain, colorFresnel);
        }
        
    }
    */

    void ChangeColor()
    {
        if (!colorBI)
        {
            MaterialChanger.ChangeColor(colorMain);
        }
        else
        {
            MaterialChanger.ChangeBIColor(colorMain, colorFresnel);
        }
    }

    void UIInitialisation()
    {
        image = GetComponent<Image>();

        image.type = Image.Type.Sliced;

        switch (buttonType)
        {
            case ButtonType.Red:
                image.color = colorData.redColorImage;
                colorMain = colorData.redColorMain;
                gameObject.name = buttonType.ToString();
                colorBI = false;
                break;
            case ButtonType.Blue:
                image.color = colorData.blueColorImage;
                colorMain = colorData.blueColorMain;
                gameObject.name = buttonType.ToString();
                colorBI = false;
                break;
            case ButtonType.Green:
                image.color = colorData.greenColorImage;
                colorMain = colorData.greenColorMain;
                gameObject.name = buttonType.ToString();
                colorBI = false;
                break;
            case ButtonType.Violet:
                image.color = colorData.violetColorImage;
                colorMain = colorData.violetColorMain;
                gameObject.name = buttonType.ToString();
                colorBI = false;
                break;
            case ButtonType.White:
                image.color = colorData.whiteColorImage;
                colorMain = colorData.whiteColorMain;
                gameObject.name = buttonType.ToString();
                colorBI = false;
                break;
            case ButtonType.Black:
                image.color = colorData.blackColorImage;
                colorMain = colorData.blackColorMain;
                gameObject.name = buttonType.ToString();
                colorBI = false;
                break;
            case ButtonType.redBlueBI:
                image.color = colorData.redblueBIImage;
                colorMain = colorData.redblueBIColorMain;
                colorFresnel = colorData.redblueBIColorFresnel;
                gameObject.name = buttonType.ToString();
                colorBI = true;
                break;
            case ButtonType.orangeDarkBI:
                image.color = colorData.greenorangeBIImage;
                colorMain = colorData.greenorangeBIColorMain;
                colorFresnel = colorData.greenorangeBIColorFresnel;
                gameObject.name = buttonType.ToString();
                colorBI = true;
                break;
        }
    }

    //UI update in Editor mode
    protected override void OnSkinUI()
    {
        base.OnSkinUI();

        image = GetComponent<Image>();

        image.type = Image.Type.Sliced;

        switch (buttonType)
        {
            case ButtonType.Red:
                image.color = colorData.redColorImage;
                colorMain = colorData.redColorMain;
                gameObject.name = buttonType.ToString();
                colorBI = false;
                break;
            case ButtonType.Blue:
                image.color = colorData.blueColorImage;
                colorMain = colorData.blueColorMain;
                gameObject.name = buttonType.ToString();
                colorBI = false;
                break;
            case ButtonType.Green:
                image.color = colorData.greenColorImage;
                colorMain = colorData.greenColorMain;
                gameObject.name = buttonType.ToString();
                colorBI = false;
                break;
            case ButtonType.Violet:
                image.color = colorData.violetColorImage;
                colorMain = colorData.violetColorMain;
                gameObject.name = buttonType.ToString();
                colorBI = false;
                break;
            case ButtonType.White:
                image.color = colorData.whiteColorImage;
                colorMain = colorData.whiteColorMain;
                gameObject.name = buttonType.ToString();
                colorBI = false;
                break;
            case ButtonType.Black:
                image.color = colorData.blackColorImage;
                colorMain = colorData.blackColorMain;
                gameObject.name = buttonType.ToString();
                colorBI = false;
                break;
            case ButtonType.redBlueBI:
                image.color = colorData.redblueBIImage;
                colorMain = colorData.redblueBIColorMain;
                colorFresnel = colorData.redblueBIColorFresnel;
                gameObject.name = buttonType.ToString();
                colorBI = true;
                break;
            case ButtonType.orangeDarkBI:
                image.color = colorData.greenorangeBIImage;
                colorMain = colorData.greenorangeBIColorMain;
                colorFresnel = colorData.greenorangeBIColorFresnel;
                gameObject.name = buttonType.ToString();
                colorBI = true;
                break;
        }
    }
}
