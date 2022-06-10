using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsChanger : MonoBehaviour
{
    [SerializeField] Transform wheelsElementsTable;
    [SerializeField] Transform spoilersElementsTable;
    [SerializeField] Transform exhaustsElementsTable;

    Transform car;
    GameObject wheelBackLeft;
    GameObject wheelBackRight;
    GameObject wheelFrontLeft;
    GameObject wheelFrontRight;
    GameObject spoiler;
    Vector3 spoilerDefaultPosition;
    GameObject exhaust;
    Vector3 exhaustDefaultPosition;


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
        Debug.Log(car + " " + wheelBackLeft);
    }

    void InitializeCarParts()
    {
        wheelBackLeft = car.Find("wheel_back_left").gameObject;
        wheelBackRight = car.Find("wheel_back_right").gameObject;
        wheelFrontLeft = car.Find("wheel_front_left").gameObject;
        wheelFrontRight = car.Find("wheel_front_right").gameObject;
        spoiler = car.Find("spoiler").gameObject;
        spoilerDefaultPosition = spoiler.transform.position;
        exhaust = car.Find("exhaust").gameObject;
        exhaustDefaultPosition = exhaust.transform.position;
        Debug.Log(exhaustDefaultPosition);

        //Destroy(spoiler);
        //Destroy(exhaust);
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
        //wheelNewCache.transform.localPosition = wheelOld.transform.localPosition;
        wheelNewCache.transform.SetSiblingIndex(wheelOld.transform.GetSiblingIndex());
        Destroy(wheelOld);
        return wheelNewCache;
    }

    void ChangeSpoiler(GameObject spoiler)
    {
        GameObject spoilerNewCache = (GameObject) Instantiate(spoiler, spoiler.transform.position + spoilerDefaultPosition, this.spoiler.transform.rotation);
        spoilerNewCache.transform.parent = this.spoiler.transform.parent;
        spoilerNewCache.transform.SetSiblingIndex(this.spoiler.transform.GetSiblingIndex());
        Destroy(this.spoiler);
        this.spoiler = spoilerNewCache;
    }
    void ChangeExhaust(GameObject exhaust)
    {
        GameObject exhaustNewCache = (GameObject)Instantiate(exhaust, exhaust.transform.position + exhaustDefaultPosition, this.exhaust.transform.rotation);
        exhaustNewCache.transform.parent = this.exhaust.transform.parent;
        exhaustNewCache.transform.SetSiblingIndex(this.exhaust.transform.GetSiblingIndex());
        Destroy(this.exhaust);
        this.exhaust = exhaustNewCache;
    }
}
