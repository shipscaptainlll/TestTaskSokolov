using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class SpoilerButton : FlexibleUI
{
    public enum ButtonType
    {
        spoiler1,
        spoiler2,
        spoiler3
    }

    Image image;
    Button button;
    GameObject spoiler;

    Texture2D assetPreviewTexture;
    Sprite displaySprite;

    public ButtonType buttonType;

    public event Action<GameObject> spoilerChanged = delegate { };

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(NotifyPartsChanger);
    }

    void NotifyPartsChanger()
    {
        spoilerChanged(spoiler);
    }

    protected override void OnSkinUI()
    {
        base.OnSkinUI();

        image = GetComponent<Image>();
        button = GetComponent<Button>();

        image.type = Image.Type.Sliced;

        switch (buttonType)
        {
            case ButtonType.spoiler1:
                assetPreviewTexture = AssetPreview.GetAssetPreview(spoilerData.spoiler1);
                displaySprite = Sprite.Create(assetPreviewTexture, new Rect(0, 0, assetPreviewTexture.width, assetPreviewTexture.height), new Vector2(.5f, .5f));
                image.sprite = displaySprite;
                spoiler = spoilerData.spoiler1;
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.spoiler2:
                assetPreviewTexture = AssetPreview.GetAssetPreview(spoilerData.spoiler2);
                displaySprite = Sprite.Create(assetPreviewTexture, new Rect(0, 0, assetPreviewTexture.width, assetPreviewTexture.height), new Vector2(.5f, .5f));
                image.sprite = displaySprite;
                spoiler = spoilerData.spoiler2;
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.spoiler3:
                assetPreviewTexture = AssetPreview.GetAssetPreview(spoilerData.spoiler3);
                displaySprite = Sprite.Create(assetPreviewTexture, new Rect(0, 0, assetPreviewTexture.width, assetPreviewTexture.height), new Vector2(.5f, .5f));
                image.sprite = displaySprite;
                spoiler = spoilerData.spoiler3;
                gameObject.name = buttonType.ToString();
                break;
        }
    }
}
