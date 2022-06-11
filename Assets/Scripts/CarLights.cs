using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarLights : MonoBehaviour
{
    [SerializeField] Transform groupsHolder;

    Image lightsButtonMaterial;
    Transform car;
    Transform lights;
    Material lightsMaterial;

    bool lightsOn = false;
    Color lightsOnColor;
    Color lightsOffColor;
    public Transform Car {
        set { 
            car = value;
            lights = car.Find("lights");
            lightsMaterial = lights.GetComponent<Renderer>().material;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        lightsButtonMaterial = groupsHolder.Find("carLightsButton").GetComponent<Image>();
        groupsHolder.Find("carLightsButton").GetComponent<AdditionalUIButton>().buttonClicked += ControlLightsState;
        lightsOnColor = new Color(0.890f, 0.890f, 0.890f, 1);
        
        lightsOffColor = Color.HSVToRGB(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TurnOnLights();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            TurnOffLights();
        }
    }

    void ControlLightsState(string buttonType)
    {
        if (buttonType == "carLightsButton")
        {
            if (lightsOn) { TurnOffLights(); } else { TurnOnLights(); }
        }
    }

    void TurnOnLights()
    {
        lightsMaterial.SetColor("_EmissionColor", lightsOnColor);
        lightsButtonMaterial.color = Color.white;
        lightsOn = true;
    }

    void TurnOffLights()
    {
        lightsMaterial.SetColor("_EmissionColor", lightsOffColor);
        lightsButtonMaterial.color = Color.black;
        lightsOn = false;
    }
}
