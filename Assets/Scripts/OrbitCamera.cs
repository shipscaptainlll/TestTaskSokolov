using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float zAxisDistance = 0.45f;
    [SerializeField] float yRotationSensitivity = 1f;
    [SerializeField] float xRotationSensitivity = 1f;
    [SerializeField] float rotationSmoothing = 2f;
    [SerializeField] Vector2 rotationLimit = new Vector2(5, 80);
    [Header("Zoom")]
    [SerializeField] Vector2 cameraZoomRangeFOV = new Vector2(10, 60);
    [SerializeField] float zoomSoothness = 4.5f;
    [SerializeField] float zoomVelocity = 1;
    [Header("Aurotation")]
    [SerializeField] bool autoRotate = true;
    [SerializeField] float rotationSpeed = 0.1f;
    [SerializeField] float startRotation = 180;

    [SerializeField] Transform target;
    [SerializeField] Transform groupsHolder;
    [SerializeField] PartsChanger partsChanger;
    [SerializeField] Transform elementsHolder;
    new Camera camera;
    float cameraFieldOfView;
    new Transform transform;
    SurroundingInitializator surroundingInitializator;
    float xVelocity;
    float yVelocity;
    float xRotationAxis;
    float yRotationAxis;
    
    bool followingTarget;

    Coroutine autorotationCoroutine;
    bool autorotationTurnedOn;



    float zoomXVelocity;
    float zoomXVar;
    public Transform Target
    {
        set { target = value; }
    }

    private void Awake()
    {
        camera = GetComponent<Camera>();
        transform = GetComponent<Transform>();
        surroundingInitializator = transform.parent.Find("Scripts").Find("SurroundingInitializator").GetComponent<SurroundingInitializator>();
        surroundingInitializator.carInstantiated += ChangeTarget;
    }

    private void Start()
    {
        cameraFieldOfView = camera.fieldOfView;
        xRotationAxis = startRotation / rotationSpeed;
        if (autoRotate)
        {
            autorotationCoroutine = StartCoroutine(AutorotationTimer());
            Debug.Log(autorotationCoroutine);
        }

        foreach (Transform table in groupsHolder)
        {
            table.GetComponent<UIGroupButton>().buttonClicked += ChangeTarget;
        }

        foreach (Transform table in elementsHolder)
        {
            table.Find("AdditionalUI").Find("backButton").GetComponent<AdditionalUIButton>().buttonClicked += ChangeTarget;
        }
    }

    public void ChangeTarget(String targetUIGroup)
    {
        switch (targetUIGroup)
        {
            case "wheelsGroup":
                yRotationAxis = 17.21f;
                xRotationAxis = 626.0f;
                target = partsChanger.Wheel3DAnchor.transform;
                camera.fieldOfView = 30;
                followingTarget = true;
                break;
            case "spoilersGroup":
                yRotationAxis = 19.04f;
                xRotationAxis = 2480.05f;
                target = partsChanger.Spoiler3DAnchor.transform;
                camera.fieldOfView = 20;
                followingTarget = true;
                break;
            case "exhaustsGroup":
                yRotationAxis = 16.09f;
                xRotationAxis = 3212.9f;
                target = partsChanger.Exhaust3DAnchor.transform;
                camera.fieldOfView = 20;
                followingTarget = true;
                break;
            case "materialsGroup":
                yRotationAxis = 20.57f;
                xRotationAxis = 2285.57f;
                target = partsChanger.Car.transform;
                camera.fieldOfView  = 60;
                followingTarget = true;
                break;
        }
    }

    public void ChangeTarget(Transform target)
    {
        yRotationAxis = 20.57f;
        xRotationAxis = 2285.57f;
        this.target = target;
        camera.fieldOfView = 60;
        followingTarget = true;
    }

    public void ChangeTarget()
    {
        yRotationAxis = 20.57f;
        xRotationAxis = 2285.57f;
        this.target = partsChanger.Car;
        camera.fieldOfView = 60;
        followingTarget = true;
    }

    private void Update()
    {
        Zoom();
    }

    private void LateUpdate()
    {
        if (autorotationTurnedOn)
        {
            AutoRotation();
        }
        if (!followingTarget)
        {
            ManualRotation();
        } else { 
            FollowTarget(); 
        }
    }

    void AutoRotation()
    {
        xVelocity += rotationSpeed * xRotationSensitivity;
    }

    void ManualRotation()
    {
        Quaternion rotation;
        Vector3 position;
        float deltaTime = Time.deltaTime;

        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            if (autorotationCoroutine != null)
            {
                StopAllCoroutines();
                autorotationCoroutine = StartCoroutine(AutorotationTimer());
            }
            if (autorotationTurnedOn)
            {
                autorotationTurnedOn = false;
                StartCoroutine(AutorotationTimer());
            }

            xVelocity += Input.GetAxis("Mouse X") * xRotationSensitivity * Time.deltaTime * 250;
            yVelocity -= Input.GetAxis("Mouse Y") * yRotationSensitivity * Time.deltaTime * 25;
        }

        xRotationAxis += xVelocity;
        yRotationAxis += yVelocity;

        yRotationAxis = ClampAngleBetweenMinAndMax(yRotationAxis, rotationLimit.x, rotationLimit.y);

        rotation = Quaternion.Euler(yRotationAxis, xRotationAxis * rotationSpeed, 0);
        position = rotation * new Vector3(0f, 0f, -zAxisDistance) + target.position;
        //position = Vector3.Lerp(transform.position, rotation * new Vector3(0f, 0f, -zAxisDistance) + target.position, 4 * Time.fixedDeltaTime);

        transform.rotation = rotation;
        transform.position = position;

        xVelocity = Mathf.Lerp(xVelocity, 0, deltaTime * rotationSmoothing);
        yVelocity = Mathf.Lerp(yVelocity, 0, deltaTime * rotationSmoothing);
    }

    void FollowTarget()
    {
        Quaternion rotation;
        rotation = Quaternion.Euler(yRotationAxis, xRotationAxis * rotationSpeed, 0);
        Debug.Log(target.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 5 * Time.fixedDeltaTime);
        transform.position = Vector3.Lerp(transform.position, rotation * new Vector3(0f, 0f, -zAxisDistance) + target.position, 4 * Time.fixedDeltaTime);


        Vector3 distance = transform.position - (rotation * new Vector3(0f, 0f, -zAxisDistance) + target.position);
        float angleDifference = Quaternion.Angle(transform.rotation, rotation);

        if (distance.magnitude < 0.5f && angleDifference < 0.01f)
        {
            followingTarget = false;
        }
    }

    private void Zoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            zoomXVelocity -= Input.GetAxis("Mouse ScrollWheel") * zoomVelocity;
        }
        else
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                zoomXVelocity -= Input.GetAxis("Mouse ScrollWheel") * zoomVelocity;
            }
        }
        if (zoomXVelocity > 0.0016f || zoomXVelocity < -0.0016f)
        {
            if (camera.fieldOfView < cameraZoomRangeFOV.x)
            {
                camera.fieldOfView = cameraZoomRangeFOV.x;
                zoomXVelocity = 0;
            }
            else if (camera.fieldOfView > cameraZoomRangeFOV.y)
            {
                camera.fieldOfView = cameraZoomRangeFOV.y;
                zoomXVelocity = 0;
            }
            else
            {
                camera.fieldOfView += zoomXVelocity;
                zoomXVelocity = Mathf.Lerp(zoomXVelocity, 0, Time.deltaTime * zoomSoothness);
            }
            
        }

        
    }

    public IEnumerator AutorotationTimer()
    {
        yield return new WaitForSeconds(5);
        autorotationTurnedOn = true;
        Debug.Log("Timer had worked");
    }

    private float ClampAngleBetweenMinAndMax(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }
}
