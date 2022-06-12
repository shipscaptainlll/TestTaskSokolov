using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class UITintButton : FlexibleUI
{
    /*
    public enum ButtonType
    {
        Metallic,
        Matte
    }

    Image image;
    Button button;

    public ButtonType buttonType;

    protected override void OnSkinUI()
    {
        base.OnSkinUI();

        image = GetComponent<Image>();
        button = GetComponent<Button>();

        button.transition = Selectable.Transition.SpriteSwap;
        button.targetGraphic = image;

        image.type = Image.Type.Sliced;

        switch (buttonType)
        {
            case ButtonType.Metallic:
                image.sprite = tintData.metallicIcon;
                break;
            case ButtonType.Matte:
                image.sprite = tintData.matteIcon;
                break;
        }
    }
    */
}
