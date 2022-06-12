using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsChanger : MonoBehaviour
{
    static Transform car;
    static GameObject wheelBackLeft;
    static GameObject wheelBackRight;
    static GameObject wheelFrontLeft;
    static GameObject wheelFrontRight;
    static GameObject wheel3DAnchor;
    static GameObject spoiler;
    static GameObject spoiler3DAnchor;
    //Vector3 spoilerDefaultPosition;
    static GameObject exhaust;
    static GameObject exhaust3DAnchor;
    //Vector3 exhaustDefaultPosition;

    public static Transform Car { set { car = value; InitializeCarParts(); } get { return car; } }
    public GameObject WheelBackLeft { get { return wheelBackLeft; } }
    public GameObject WheelBackRight { get { return wheelBackRight; } }
    public GameObject WheelFrontLeft { get { return wheelFrontLeft; } }
    public GameObject WheelFrontRight { get { return wheelFrontRight; } }
    public static GameObject Wheel3DAnchor { get { return wheel3DAnchor; } }
    public GameObject Spoiler { get { return spoiler; } }
    public static GameObject Spoiler3DAnchor { get { return spoiler3DAnchor; } }
    public GameObject Exhaust { get { return exhaust; } }
    public static GameObject Exhaust3DAnchor { get { return exhaust3DAnchor; } }

    public void AssignCarModel(Transform newCar)
    {
        car = newCar;
        InitializeCarParts();
    }

    static void InitializeCarParts()
    {
        wheelBackLeft = car.Find("wheel_back_left").gameObject;
        wheelBackRight = car.Find("wheel_back_right").gameObject;
        wheelFrontLeft = car.Find("wheel_front_left").gameObject;
        wheelFrontRight = car.Find("wheel_front_right").gameObject;
        wheel3DAnchor = car.Find("wheel3DAnchor").gameObject;
        spoiler = car.Find("spoiler").gameObject;
        spoiler3DAnchor = car.Find("spoiler3DAnchor").gameObject;
        exhaust = car.Find("exhaust").gameObject;
        exhaust3DAnchor = car.Find("exhaust3DAnchor").gameObject;
    }

    public static void ChangeWheels(GameObject wheel)
    {
        wheelBackLeft = ChangeWheel(wheelBackLeft, wheel, new Vector3(0f, -90f, 0f));
        wheelBackRight = ChangeWheel(wheelBackRight, wheel, new Vector3(0f, 90f, 0f));
        wheelFrontLeft = ChangeWheel(wheelFrontLeft, wheel, new Vector3(0f, -90f, 0f));
        wheelFrontRight = ChangeWheel(wheelFrontRight, wheel, new Vector3(0f, 90f, 0f));
    }

    static GameObject ChangeWheel(GameObject wheelOld, GameObject wheelNew, Vector3 defaultRotation)
    {
        GameObject wheelNewCache = Instantiate(wheelNew, wheelOld.transform.position, Quaternion.Euler(defaultRotation));
        wheelNewCache.transform.parent = wheelOld.transform.parent;
        wheelNewCache.transform.SetSiblingIndex(wheelOld.transform.GetSiblingIndex());
        Destroy(wheelOld);
        return wheelNewCache;
    }

    public static void ChangeSpoiler(GameObject newSpoiler)
    {
        GameObject spoilerNewCache = (GameObject) Instantiate(newSpoiler, newSpoiler.transform.position + spoiler3DAnchor.transform.position, spoiler.transform.rotation);
        spoilerNewCache.transform.parent = spoiler.transform.parent;
        spoilerNewCache.transform.SetSiblingIndex(spoiler.transform.GetSiblingIndex());
        Destroy(spoiler);
        spoiler = spoilerNewCache;
    }
    public static void ChangeExhaust(GameObject newExhaust)
    {
        GameObject exhaustNewCache = (GameObject)Instantiate(newExhaust, newExhaust.transform.position + exhaust3DAnchor.transform.position, exhaust.transform.rotation);
        exhaustNewCache.transform.parent = exhaust.transform.parent;
        exhaustNewCache.transform.SetSiblingIndex(exhaust.transform.GetSiblingIndex());
        Destroy(exhaust);
        exhaust = exhaustNewCache;
    }
}
