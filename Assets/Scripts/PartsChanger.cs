using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsChanger : MonoBehaviour
{
    [SerializeField] Transform wheelsElementsTable;
    [SerializeField] Transform spoilersElementsTable;
    [SerializeField] Transform exhaustsElementsTable;
    [SerializeField] OrbitCamera orbitCamera;

    Transform car;
    GameObject wheelBackLeft;
    GameObject wheelBackRight;
    GameObject wheelFrontLeft;
    GameObject wheelFrontRight;
    GameObject wheel3DAnchor;
    GameObject spoiler;
    GameObject spoiler3DAnchor;
    Vector3 spoilerDefaultPosition;
    GameObject exhaust;
    GameObject exhaust3DAnchor;
    Vector3 exhaustDefaultPosition;

    public Transform Car { set { car = value; InitializeCarParts(); } get { return car; } }
    public GameObject WheelBackLeft { get { return wheelBackLeft; } }
    public GameObject WheelBackRight { get { return wheelBackRight; } }
    public GameObject WheelFrontLeft { get { return wheelFrontLeft; } }
    public GameObject WheelFrontRight { get { return wheelFrontRight; } }
    public GameObject Wheel3DAnchor { get { return wheel3DAnchor; } }
    public GameObject Spoiler { get { return spoiler; } }
    public GameObject Spoiler3DAnchor { get { return spoiler3DAnchor; } }
    public GameObject Exhaust { get { return exhaust; } }
    public GameObject Exhaust3DAnchor { get { return exhaust3DAnchor; } }


    // Start is called before the first frame update
    void Start()
    {
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

    public void AssignCarModel(Transform car)
    {
        this.car = car;
        InitializeCarParts();
    }

    void InitializeCarParts()
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

    void ChangeWheels(GameObject wheel)
    {
        wheelBackLeft = ChangeWheel(wheelBackLeft, wheel, new Vector3(0f, -90f, 0f));
        wheelBackRight = ChangeWheel(wheelBackRight, wheel, new Vector3(0f, 90f, 0f));
        wheelFrontLeft = ChangeWheel(wheelFrontLeft, wheel, new Vector3(0f, -90f, 0f));
        wheelFrontRight = ChangeWheel(wheelFrontRight, wheel, new Vector3(0f, 90f, 0f));
    }

    GameObject ChangeWheel(GameObject wheelOld, GameObject wheelNew, Vector3 defaultRotation)
    {
        GameObject wheelNewCache = Instantiate(wheelNew, wheelOld.transform.position, Quaternion.Euler(defaultRotation));
        wheelNewCache.transform.parent = wheelOld.transform.parent;
        wheelNewCache.transform.SetSiblingIndex(wheelOld.transform.GetSiblingIndex());
        Destroy(wheelOld);
        return wheelNewCache;
    }

    void ChangeSpoiler(GameObject spoiler)
    {
        GameObject spoilerNewCache = (GameObject) Instantiate(spoiler, spoiler.transform.position + spoiler3DAnchor.transform.position, this.spoiler.transform.rotation);
        spoilerNewCache.transform.parent = this.spoiler.transform.parent;
        spoilerNewCache.transform.SetSiblingIndex(this.spoiler.transform.GetSiblingIndex());
        Destroy(this.spoiler);
        this.spoiler = spoilerNewCache;
    }
    void ChangeExhaust(GameObject exhaust)
    {
        GameObject exhaustNewCache = (GameObject)Instantiate(exhaust, exhaust.transform.position + exhaust3DAnchor.transform.position, this.exhaust.transform.rotation);
        exhaustNewCache.transform.parent = this.exhaust.transform.parent;
        exhaustNewCache.transform.SetSiblingIndex(this.exhaust.transform.GetSiblingIndex());
        Destroy(this.exhaust);
        this.exhaust = exhaustNewCache;
    }
}
