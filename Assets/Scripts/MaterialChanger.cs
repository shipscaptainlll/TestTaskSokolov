using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    static Transform car;

    static GameObject body;
    static Renderer bodyRenderer;

    public static Transform Car
    {
        set
        {
            car = value;
            InitializeCarParts();
        }
    }

    static void InitializeCarParts()
    {
        body = car.Find("body").gameObject;
        bodyRenderer = body.GetComponent<Renderer>();
    }

    public static void ChangeColor(Color color)
    {
        bodyRenderer.material.SetInt("_isBITint", 0);
        bodyRenderer.material.SetColor("_MainColor", color);
    }

    public static void ChangeBIColor(Color colorMain, Color colorFresnel)
    {
        bodyRenderer.material.SetInt("_isBITint", 1);
        bodyRenderer.material.SetColor("_MainColor", colorMain);
        bodyRenderer.material.SetColor("_FresnelColor", colorFresnel);
    }

    public static void ChangeTint(float metallicValue)
    {
        bodyRenderer.material.SetFloat("_Metallic", metallicValue); 
    }
}
