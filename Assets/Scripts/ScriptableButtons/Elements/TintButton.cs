using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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

    Texture2D assetPreviewTexture;
    Sprite displaySprite;

    public ButtonType buttonType;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChangeTint);
        UIInitialisation();
    }

    void ChangeTint()
    {
        MaterialChanger.ChangeTint(metallicValue);
    }

    void UIInitialisation()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();

        image.type = Image.Type.Sliced;

        switch (buttonType)
        {
            case ButtonType.Metallic:
                StartCoroutine(UploadGraphicsElements(tintData.metallImage));
                image.color = Color.white;
                metallicValue = tintData.metallicMaterial;
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.Matte:
                StartCoroutine(UploadGraphicsElements(tintData.matteImage));
                image.color = Color.white;
                metallicValue = tintData.matteMaterial;
                gameObject.name = buttonType.ToString();
                break;
        }
    }

    IEnumerator UploadGraphicsElements(Material assetMaterial)
    {
        yield return new WaitUntil(() => (AssetPreview.GetAssetPreview(assetMaterial) != null));
        Texture2D assetPreviewTexture = AssetPreview.GetAssetPreview(assetMaterial);
        Sprite displaySprite = Sprite.Create(assetPreviewTexture, new Rect(0, 0, assetPreviewTexture.width, assetPreviewTexture.height), new Vector2(.5f, .5f));
        image.sprite = displaySprite;
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
            case ButtonType.Metallic:
                assetPreviewTexture = AssetPreview.GetAssetPreview(tintData.metallImage);
                displaySprite = Sprite.Create(assetPreviewTexture, new Rect(0, 0, assetPreviewTexture.width, assetPreviewTexture.height), new Vector2(.5f, .5f));
                image.sprite = displaySprite;
                metallicValue = tintData.metallicMaterial;
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.Matte:
                assetPreviewTexture = AssetPreview.GetAssetPreview(tintData.matteImage);
                displaySprite = Sprite.Create(assetPreviewTexture, new Rect(0, 0, assetPreviewTexture.width, assetPreviewTexture.height), new Vector2(.5f, .5f));
                image.sprite = displaySprite;
                metallicValue = tintData.matteMaterial;
                gameObject.name = buttonType.ToString();
                break;
        }
    }
}
