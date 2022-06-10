using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    [SerializeField] Transform colorElementsTable;

    // Start is called before the first frame update
    void Start()
    {
        Transform colorElementsHolder = colorElementsTable.Find("MainElements");
        foreach(Transform table in colorElementsHolder)
        {
            if (table.GetComponent<ColorButton>() != null)
            {
                table.GetComponent<ColorButton>().colorChanged += ChangeColor;
            }
            if (table.GetComponent<TintButton>() != null)
            {
                table.GetComponent<TintButton>().tintChanged += ChangeMaterial;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeColor(Color color)
    {
        Debug.Log("new color is " + color);
    }

    void ChangeMaterial(Material material)
    {
        Debug.Log("new material is " + material);
    }
}
