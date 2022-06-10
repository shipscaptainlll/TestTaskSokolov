using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsChanger : MonoBehaviour
{
    [SerializeField] SurroundingInitializator surroundingInitializator;
    [SerializeField] Transform wheelsElementsTable;
    [SerializeField] Transform spoilersElementsTable;
    [SerializeField] Transform exhaustsElementsTable;

    Transform car;
    // Start is called before the first frame update
    void Start()
    {
        surroundingInitializator.carInstantiated += 
        Transform wheelsElementsHolder = wheelsElementsTable.Find("MainElements");
        Transform spoilersElementsHolder = spoilersElementsTable.Find("MainElements");
        Transform exhaustsElementsHolder = exhaustsElementsTable.Find("MainElements");
        foreach (Transform table in wheelsElementsHolder)
        {
            if (table.GetComponent<WheelsButton>() != null)
            {
                table.GetComponent<WheelsButton>().wheelsChanged += ChangeWheels;
            }
        }
        foreach (Transform table in spoilersElementsHolder)
        {
            if (table.GetComponent<SpoilerButton>() != null)
            {
                table.GetComponent<SpoilerButton>().spoilerChanged += ChangeSpoiler;
            }
        }
        foreach (Transform table in exhaustsElementsHolder)
        {
            if (table.GetComponent<ExhaustButton>() != null)
            {
                table.GetComponent<ExhaustButton>().exhaustChanged += ChangeExhaust;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AssignCarModel()
    {

    }

    void ChangeWheels(GameObject wheel)
    {
        Debug.Log("new wheels are " + wheel);
    }

    void ChangeSpoiler(GameObject spoiler)
    {
        Debug.Log("new spoiler is " + spoiler);
    }
    void ChangeExhaust(GameObject exhaust)
    {
        Debug.Log("new exhaust is " + exhaust);
    }
}
