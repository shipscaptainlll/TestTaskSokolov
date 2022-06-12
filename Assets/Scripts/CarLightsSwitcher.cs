using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarLightsSwitcher : MonoBehaviour
{

    public static Image lightsButtonMaterial;
    public static Transform car;
    public static Transform lights;
    public static Material lightsMaterial;

    static bool lightsOn = false;
    static Color lightsOnColor;
    static Color lightsOffColor;
    public static Transform Car {
        set { 
            car = value;
            lights = car.Find("lights");
            lightsMaterial = lights.GetComponent<Renderer>().material;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        lightsOnColor = new Color(0.890f, 0.890f, 0.890f, 1);
        lightsOffColor = Color.HSVToRGB(0, 0, 0);
    }

    public static void ControlLightsState(string buttonType)
    {
        if (buttonType == "carLightsButton")
        {
            if (lightsOn) { TurnOffLights(); } else { TurnOnLights(); }
        }
    }

    static void TurnOnLights()
    {
        Debug.Log("Lights turned on");
        lightsMaterial.SetColor("_EmissionColor", lightsOnColor);
        lightsButtonMaterial.color = Color.white;
        lightsOn = true;
    }

    static void TurnOffLights()
    {
        Debug.Log("Lights turned off");
        lightsMaterial.SetColor("_EmissionColor", lightsOffColor);
        lightsButtonMaterial.color = Color.black;
        lightsOn = false;
    }
}
