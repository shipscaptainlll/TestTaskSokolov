using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class ExhaustButton : FlexibleUI
{
    public enum ButtonType
    {
        exhaust1,
        exhaust2,
        exhaust3,
        exhaust4,
        exhaust5,
        exhaust6
    }

    Image image;
    Button button;
    GameObject exhaust;

    Texture2D assetPreviewTexture;
    Sprite displaySprite;

    public ButtonType buttonType;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChangeParts);
        UIInitialisation();
    }

    void ChangeParts()
    {
        PartsChanger.ChangeExhaust(exhaust);
    }

    void UIInitialisation()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();

        image.type = Image.Type.Sliced;

        switch (buttonType)
        {
            case ButtonType.exhaust1:
                assetPreviewTexture = AssetPreview.GetAssetPreview(exhaustData.exhaust1);
                displaySprite = Sprite.Create(assetPreviewTexture, new Rect(0, 0, assetPreviewTexture.width, assetPreviewTexture.height), new Vector2(.5f, .5f));
                image.sprite = displaySprite;
                exhaust = exhaustData.exhaust1;
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.exhaust2:
                assetPreviewTexture = AssetPreview.GetAssetPreview(exhaustData.exhaust2);
                displaySprite = Sprite.Create(assetPreviewTexture, new Rect(0, 0, assetPreviewTexture.width, assetPreviewTexture.height), new Vector2(.5f, .5f));
                image.sprite = displaySprite;
                exhaust = exhaustData.exhaust2;
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.exhaust3:
                assetPreviewTexture = AssetPreview.GetAssetPreview(exhaustData.exhaust3);
                displaySprite = Sprite.Create(assetPreviewTexture, new Rect(0, 0, assetPreviewTexture.width, assetPreviewTexture.height), new Vector2(.5f, .5f));
                image.sprite = displaySprite;
                exhaust = exhaustData.exhaust3;
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.exhaust4:
                assetPreviewTexture = AssetPreview.GetAssetPreview(exhaustData.exhaust4);
                displaySprite = Sprite.Create(assetPreviewTexture, new Rect(0, 0, assetPreviewTexture.width, assetPreviewTexture.height), new Vector2(.5f, .5f));
                image.sprite = displaySprite;
                exhaust = exhaustData.exhaust4;
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.exhaust5:
                assetPreviewTexture = AssetPreview.GetAssetPreview(exhaustData.exhaust5);
                displaySprite = Sprite.Create(assetPreviewTexture, new Rect(0, 0, assetPreviewTexture.width, assetPreviewTexture.height), new Vector2(.5f, .5f));
                image.sprite = displaySprite;
                exhaust = exhaustData.exhaust5;
                gameObject.name = buttonType.ToString();
                break;
        }
    }

    //UI update in Editor mode
    protected override void OnSkinUI()
    {
        base.OnSkinUI();

        image = GetComponent<Image>();
        button = GetComponent<Button>();

        image.type = Image.Type.Sliced;

        switch (buttonType)
        {
            case ButtonType.exhaust1:
                assetPreviewTexture = AssetPreview.GetAssetPreview(exhaustData.exhaust1);
                displaySprite = Sprite.Create(assetPreviewTexture, new Rect(0, 0, assetPreviewTexture.width, assetPreviewTexture.height), new Vector2(.5f, .5f));
                image.sprite = displaySprite;
                exhaust = exhaustData.exhaust1;
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.exhaust2:
                assetPreviewTexture = AssetPreview.GetAssetPreview(exhaustData.exhaust2);
                displaySprite = Sprite.Create(assetPreviewTexture, new Rect(0, 0, assetPreviewTexture.width, assetPreviewTexture.height), new Vector2(.5f, .5f));
                image.sprite = displaySprite;
                exhaust = exhaustData.exhaust2;
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.exhaust3:
                assetPreviewTexture = AssetPreview.GetAssetPreview(exhaustData.exhaust3);
                displaySprite = Sprite.Create(assetPreviewTexture, new Rect(0, 0, assetPreviewTexture.width, assetPreviewTexture.height), new Vector2(.5f, .5f));
                image.sprite = displaySprite;
                exhaust = exhaustData.exhaust3;
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.exhaust4:
                assetPreviewTexture = AssetPreview.GetAssetPreview(exhaustData.exhaust4);
                displaySprite = Sprite.Create(assetPreviewTexture, new Rect(0, 0, assetPreviewTexture.width, assetPreviewTexture.height), new Vector2(.5f, .5f));
                image.sprite = displaySprite;
                exhaust = exhaustData.exhaust4;
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.exhaust5:
                assetPreviewTexture = AssetPreview.GetAssetPreview(exhaustData.exhaust5);
                displaySprite = Sprite.Create(assetPreviewTexture, new Rect(0, 0, assetPreviewTexture.width, assetPreviewTexture.height), new Vector2(.5f, .5f));
                image.sprite = displaySprite;
                exhaust = exhaustData.exhaust5;
                gameObject.name = buttonType.ToString();
                break;
        }
    }
}
