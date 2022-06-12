using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class UIGroupButton : FlexibleUI
{
    public enum ButtonType
    {
        wheelsGroup,
        spoilersGroup,
        exhaustsGroup,
        materialsGroup
    }

    Image image;
    Button button;
    Text textUI;

    Texture2D assetPreviewTexture;
    Sprite displaySprite;

    public ButtonType buttonType;

    public void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ShowUITable);
        button.onClick.AddListener(ChangeCameraTarget);
        UIInitialisation();
    }

    public void ChangeCameraTarget()
    {
        OrbitCamera.ChangeTarget(buttonType.ToString());
    }

    void ShowUITable()
    {
        UITablesOpener.ShowTable(buttonType.ToString());
    }

    void UIInitialisation()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        textUI = transform.Find("Text").GetComponent<Text>();

        image.type = Image.Type.Sliced;

        switch (buttonType)
        {
            case ButtonType.spoilersGroup:
                StartCoroutine(UploadGraphicsElements(uiGroupsData.spoilersGroupImage));
                textUI.text = uiGroupsData.spoilersGroupName;
                gameObject.name = buttonType.ToString();

                break;
            case ButtonType.wheelsGroup:
                StartCoroutine(UploadGraphicsElements(uiGroupsData.wheelsGroupImage));
                textUI.text = uiGroupsData.wheelsGroupName;
                gameObject.name = buttonType.ToString();

                break;
            case ButtonType.exhaustsGroup:
                StartCoroutine(UploadGraphicsElements(uiGroupsData.exhaustsGroupImage));
                textUI.text = uiGroupsData.exhaustsGroupName;
                gameObject.name = buttonType.ToString();

                break;
            case ButtonType.materialsGroup:
                StartCoroutine(UploadGraphicsElements(uiGroupsData.materialsGroupImage));
                textUI.text = uiGroupsData.materialsGroupName;
                gameObject.name = buttonType.ToString();

                break;
        }
    }

    IEnumerator UploadGraphicsElements(GameObject assetGameobject)
    {
        yield return new WaitUntil(() => (AssetPreview.GetAssetPreview(assetGameobject) != null));
        Texture2D assetPreviewTexture = AssetPreview.GetAssetPreview(assetGameobject);
        Sprite displaySprite = Sprite.Create(assetPreviewTexture, new Rect(0, 0, assetPreviewTexture.width, assetPreviewTexture.height), new Vector2(.5f, .5f));
        image.sprite = displaySprite;
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
        textUI = transform.Find("Text").GetComponent<Text>();

        image.type = Image.Type.Sliced;
        
        switch (buttonType)
        {
            case ButtonType.spoilersGroup:
                assetPreviewTexture = AssetPreview.GetAssetPreview(uiGroupsData.spoilersGroupImage);
                displaySprite = Sprite.Create(assetPreviewTexture, new Rect(0, 0, assetPreviewTexture.width, assetPreviewTexture.height), new Vector2(0.5f, 0.5f));
                image.sprite = displaySprite;
                textUI.text = uiGroupsData.spoilersGroupName;
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.wheelsGroup:

                assetPreviewTexture = AssetPreview.GetAssetPreview(uiGroupsData.wheelsGroupImage);
                displaySprite = Sprite.Create(assetPreviewTexture, new Rect(0, 0, assetPreviewTexture.width, assetPreviewTexture.height), new Vector2(.5f, .5f));
                image.sprite = displaySprite;
                textUI.text = uiGroupsData.wheelsGroupName;
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.exhaustsGroup:
                assetPreviewTexture = AssetPreview.GetAssetPreview(uiGroupsData.exhaustsGroupImage);
                displaySprite = Sprite.Create(assetPreviewTexture, new Rect(0, 0, assetPreviewTexture.width, assetPreviewTexture.height), new Vector2(.5f, .5f));
                image.sprite = displaySprite;
                textUI.text = uiGroupsData.exhaustsGroupName;
                gameObject.name = buttonType.ToString(); 
                break;
            case ButtonType.materialsGroup:
                assetPreviewTexture = AssetPreview.GetAssetPreview(uiGroupsData.materialsGroupImage);
                displaySprite = Sprite.Create(assetPreviewTexture, new Rect(0, 0, assetPreviewTexture.width, assetPreviewTexture.height), new Vector2(.5f, .5f));
                image.sprite = displaySprite; 
                textUI.text = uiGroupsData.materialsGroupName;
                gameObject.name = buttonType.ToString();
                break;
        }
    }
}
