using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    [SerializeField] Transform colorElementsTable;
    
    Transform car;

    GameObject body;
    Renderer bodyRenderer;

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

    public void AssignCarModel(Transform car)
    {
        this.car = car;
        InitializeCarParts();
    }

    void InitializeCarParts()
    {
        body = car.Find("body").gameObject;
        bodyRenderer = body.GetComponent<Renderer>();
    }

    void ChangeColor(Color color)
    {
        bodyRenderer.material.color = color;
    }

    void ChangeMaterial(Material material)
    {
        Color colorCache = bodyRenderer.material.color;
        bodyRenderer.material = material;
        bodyRenderer.material.color = colorCache;
    }
}
