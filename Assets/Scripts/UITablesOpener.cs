using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITablesOpener : MonoBehaviour
{
    //static Transform groupsHolder;
    public static GameObject mainTable;
    //static Transform elementsHolder;
    public static GameObject materialsTable;
    public static GameObject wheelsTable;
    public static GameObject spoilersTable;
    public static GameObject exhaustsTable;
    public static GameObject currentTable;
    
    // Start is called before the first frame update
    void Start()
    {
        InitializeUITables();
    }

    void InitializeUITables()
    {

    }

    public static void ShowTable(string tableName)
    {
        Debug.Log(tableName);
        currentTable.SetActive(false);
        switch (tableName)
        {
            case "wheelsGroup":
                wheelsTable.SetActive(true);
                currentTable = wheelsTable;
                break;
            case "spoilersGroup":
                spoilersTable.SetActive(true);
                currentTable = spoilersTable;
                break;
            case "exhaustsGroup":
                exhaustsTable.SetActive(true);
                currentTable = exhaustsTable;
                break;
            case "materialsGroup":
                materialsTable.SetActive(true);
                currentTable = materialsTable;
                break;
            case "backButton":
                currentTable.SetActive(false);
                mainTable.SetActive(true);
                currentTable = mainTable;
                break;
        }
    }

    void ShowMainTable(string buttonType)
    {
        if (buttonType == "backButton")
        {
            currentTable.SetActive(false);
            mainTable.SetActive(true);
            currentTable = mainTable;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
