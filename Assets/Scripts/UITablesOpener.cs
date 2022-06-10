using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITablesOpener : MonoBehaviour
{
    [SerializeField] Transform groupsHolder;
    [SerializeField] GameObject mainTable;
    [SerializeField] Transform elementsHolder;
    [SerializeField] GameObject materialsTable;
    [SerializeField] GameObject wheelsTable;
    [SerializeField] GameObject spoilersTable;
    [SerializeField] GameObject exhaustsTable;

    GameObject currentTable;

    // Start is called before the first frame update
    void Start()
    {
        currentTable = mainTable;

        foreach (Transform table in groupsHolder)
        {
            table.GetComponent<UIGroupButton>().buttonClicked += ShowTable;
        }

        foreach (Transform table in elementsHolder)
        {
            table.Find("AdditionalUI").Find("backButton").GetComponent<AdditionalUIButton>().buttonClicked += ShowMainTable;
        }
    }

    void ShowTable(string tableName)
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
        }
    }

    void ShowMainTable()
    {
        currentTable.SetActive(false);
        mainTable.SetActive(true);
        currentTable = mainTable;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
