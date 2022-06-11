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
    GameObject groupFolder;
    Text textUI;

    Texture2D assetPreviewTexture;
    Sprite displaySprite;

    public ButtonType buttonType;

    public event Action<String> buttonClicked = delegate { };
    public void Start()
    {
        button.onClick.AddListener(NotifySubscribers);
    }

    public void NotifySubscribers()
    {
        buttonClicked(buttonType.ToString());
    }


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
                displaySprite = Sprite.Create(assetPreviewTexture, new Rect(0, 0, assetPreviewTexture.width, assetPreviewTexture.height), new Vector2(.5f, .5f));
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
