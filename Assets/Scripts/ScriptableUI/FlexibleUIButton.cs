using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class FlexibleUIButton : FlexibleUI
{
    /*
    public enum ButtonType
    {
        Default,
        Confirm,
        Decline,
        Warning
    }

    

    Image image;
    Image icon;
    Button button;

    public ButtonType buttonType;

    protected override void OnSkinUI()
    {
        base.OnSkinUI();

        image = GetComponent<Image>();
        button = GetComponent<Button>();

        button.transition = Selectable.Transition.SpriteSwap;
        button.targetGraphic = image;

        image.sprite = skinData.buttonSprite;
        image.type = Image.Type.Sliced;
        button.spriteState = skinData.buttonSpriteState;

        switch (buttonType)
        {
            case ButtonType.Confirm:
                image.color = skinData.confirmColor;
                //icon.sprite = skinData.confirmIcon;
                break;
            case ButtonType.Decline:
                image.color = skinData.declineColor;
                //icon.sprite = skinData.declineIcon;
                break;
            case ButtonType.Warning:
                image.color = skinData.warningColor;
                //icon.sprite = skinData.warningIcon;
                break;
            case ButtonType.Default:
                image.color = skinData.defaultColor;
                //icon.sprite = skinData.defaultIcon;
                break;
        }
    }
    */
}
