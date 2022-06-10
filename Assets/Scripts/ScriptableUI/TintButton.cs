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
    Material material;

    public ButtonType buttonType;

    public event Action<Material> tintChanged = delegate { };

    private void Start()
    {
        button.onClick.AddListener(NotifyMaterialChanger);
    }

    void NotifyMaterialChanger()
    {
        tintChanged(material);
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
                material = tintData.metallicMaterial;
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.Matte:
                image.color = tintData.matteColor;
                material = tintData.matteMaterial;
                gameObject.name = buttonType.ToString();
                break;
        }
    }
}
