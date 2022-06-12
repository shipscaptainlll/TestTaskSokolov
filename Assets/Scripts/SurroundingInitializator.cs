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
        startCar = Instantiate(defaultCar);
        PartsChanger.Car = startCar;
        MaterialChanger.Car = startCar;
        CarLightsSwitcher.Car = startCar;
        OrbitCamera.ChangeTarget(startCar);
    }
}
