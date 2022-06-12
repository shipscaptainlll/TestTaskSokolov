using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITablesOpener : MonoBehaviour
{
    public static GameObject mainTable;
    public static GameObject materialsTable;
    public static GameObject wheelsTable;
    public static GameObject spoilersTable;
    public static GameObject exhaustsTable;
    public static GameObject currentTable;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void ShowTable(string tableName)
    {
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
}
