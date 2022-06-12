using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class TintButton : FlexibleUI
{
    public enum ButtonType
    {
        Metallic,
        Matte
    }

    Image image;
    Button button;
    float metallicValue;

    public ButtonType buttonType;

    public event Action<float> tintChanged = delegate { };

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(NotifyMaterialChanger);
    }

    void NotifyMaterialChanger()
    {
        tintChanged(metallicValue);
    }

    protected override void OnSkinUI()
    {
        base.OnSkinUI();

        image = GetComponent<Image>();
        button = GetComponent<Button>();
        

        //button.transition = Selectable.Transition.SpriteSwap;
        //button.targetGraphic = image;

        image.type = Image.Type.Sliced;

        switch (buttonType)
        {
            case ButtonType.Metallic:
                image.color = tintData.metallColor;
                metallicValue = tintData.metallicMaterial;
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.Matte:
                image.color = tintData.matteColor;
                metallicValue = tintData.matteMaterial;
                gameObject.name = buttonType.ToString();
                break;
        }
    }
}
