using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    [SerializeField] Transform colorElementsTable;
    
    Transform car;

    GameObject body;
    Renderer bodyRenderer;

    public Transform Car
    {
        set
        {
            car = value;
            InitializeCarParts();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Transform colorElementsHolder = colorElementsTable.Find("MainElements");
        foreach(Transform table in colorElementsHolder)
        {
            if (table.GetComponent<ColorButton>() != null)
            {
                table.GetComponent<ColorButton>().colorChanged += ChangeColor;
                table.GetComponent<ColorButton>().colorBIChanged += ChangeBIColor;
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

    void InitializeCarParts()
    {
        body = car.Find("body").gameObject;
        bodyRenderer = body.GetComponent<Renderer>();
    }

    void ChangeColor(Color color)
    {
        bodyRenderer.material.SetInt("_isBITint", 0);
        bodyRenderer.material.SetColor("_MainColor", color);
    }

    void ChangeBIColor(Color colorMain, Color colorFresnel)
    {
        bodyRenderer.material.SetInt("_isBITint", 1);
        bodyRenderer.material.SetColor("_MainColor", colorMain);
        bodyRenderer.material.SetColor("_FresnelColor", colorFresnel);
    }

    void ChangeMaterial(float metallicValue)
    {
        bodyRenderer.material.SetFloat("_Metallic", metallicValue); 
    }
}
