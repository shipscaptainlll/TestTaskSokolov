using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class WheelsButton : FlexibleUI
{
    public enum ButtonType
    {
        wheels1,
        wheels2,
        wheels3
    }

    Image image;
    Button button;
    GameObject wheel;

    Texture2D assetPreviewTexture;
    Sprite displaySprite;

    public ButtonType buttonType;

    public event Action<GameObject> wheelsChanged = delegate { };

    private void Start()
    {
        button.onClick.AddListener(NotifyPartsChanger);
    }

    void NotifyPartsChanger()
    {
        wheelsChanged(wheel);
    }

    protected override void OnSkinUI()
    {
        base.OnSkinUI();

        image = GetComponent<Image>();
        button = GetComponent<Button>();

        image.type = Image.Type.Sliced;

        switch (buttonType)
        {
            case ButtonType.wheels1:
                assetPreviewTexture = AssetPreview.GetAssetPreview(wheelsData.wheels1);
                displaySprite = Sprite.Create(assetPreviewTexture, new Rect(0, 0, assetPreviewTexture.width, assetPreviewTexture.height), new Vector2(.5f, .5f));
                image.sprite = displaySprite;
                wheel = wheelsData.wheels1;
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.wheels2:
                assetPreviewTexture = AssetPreview.GetAssetPreview(wheelsData.wheels2);
                displaySprite = Sprite.Create(assetPreviewTexture, new Rect(0, 0, assetPreviewTexture.width, assetPreviewTexture.height), new Vector2(.5f, .5f));
                image.sprite = displaySprite;
                wheel = wheelsData.wheels2;
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.wheels3:
                assetPreviewTexture = AssetPreview.GetAssetPreview(wheelsData.wheels3);
                displaySprite = Sprite.Create(assetPreviewTexture, new Rect(0, 0, assetPreviewTexture.width, assetPreviewTexture.height), new Vector2(.5f, .5f));
                image.sprite = displaySprite;
                wheel = wheelsData.wheels3;
                gameObject.name = buttonType.ToString();
                break;
        }
    }
}
