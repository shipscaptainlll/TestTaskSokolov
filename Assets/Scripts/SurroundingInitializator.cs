using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurroundingInitializator : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] Transform defaultCar;
    Transform startCar;

    void Start()
    {
        if (defaultCar == null)
        {
            defaultCar = (Resources.Load("Prefabs/car 1203 black") as GameObject).transform;
        }
        startCar = Instantiate(defaultCar);
        PartsChanger.Car = startCar;
        MaterialChanger.Car = startCar;
        CarLightsSwitcher.Car = startCar;
        OrbitCamera.ChangeTarget(startCar);
    }
}
