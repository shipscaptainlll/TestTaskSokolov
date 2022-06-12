using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class UITable : FlexibleUI
{
    [SerializeField] GameObject tableBorders;
    public enum ButtonType
    {
        wheelsTable,
        spoilersTable,
        exhaustsTable,
        materialsTable,
        mainTable,
        languagesTable,
        screenshotTable
    }

    public ButtonType buttonType;

    public void Start()
    {
        UIInitialisation();
    }

    void UIInitialisation()
    {

        switch (buttonType)
        {
            case ButtonType.spoilersTable:
                gameObject.name = buttonType.ToString();
                UITablesOpener.spoilersTable = tableBorders;
                break;
            case ButtonType.wheelsTable:
                gameObject.name = buttonType.ToString();
                UITablesOpener.wheelsTable = tableBorders;
                break;
            case ButtonType.exhaustsTable:
                gameObject.name = buttonType.ToString();
                UITablesOpener.exhaustsTable = tableBorders;
                break;
            case ButtonType.materialsTable:
                gameObject.name = buttonType.ToString();
                UITablesOpener.materialsTable = tableBorders;
                break;
            case ButtonType.mainTable:
                gameObject.name = buttonType.ToString();
                UITablesOpener.mainTable = tableBorders;
                UITablesOpener.currentTable = tableBorders;
                break;
            case ButtonType.languagesTable:
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.screenshotTable:
                gameObject.name = buttonType.ToString();
                break;
        }
    }

    //UI update in Editor mode
    protected override void OnSkinUI()
    {
        base.OnSkinUI();

        switch (buttonType)
        {
            case ButtonType.spoilersTable:
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.wheelsTable:
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.exhaustsTable:
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.materialsTable:
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.mainTable:
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.languagesTable:
                gameObject.name = buttonType.ToString();
                break;
            case ButtonType.screenshotTable:
                gameObject.name = buttonType.ToString();
                break;
        }
    }
}
