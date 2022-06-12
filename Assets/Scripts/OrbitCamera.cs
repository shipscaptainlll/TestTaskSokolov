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
    [Header("Autorotation")]
    [SerializeField] bool autoRotate = true;
    [SerializeField] float rotationSpeed = 0.1f;
    [SerializeField] float autoRotationSpeed = 0.03f;
    [SerializeField] float startRotation = 180;

    static Transform target;
    new static Camera camera;
    static float xRotationAxis;
    static float yRotationAxis;
    static bool followingTarget;

    new Transform transform;

    float xVelocity;
    float yVelocity;

    float cameraFieldOfView;
    float zoomXVelocity;

    Coroutine autorotationCoroutine;
    bool autorotationTurnedOn;
    
    public static Transform Target
    {
        get { return target; }
        set { target = value; }
    }

    private void Awake()
    {
        camera = GetComponent<Camera>();
        transform = GetComponent<Transform>();
    }

    private void Start()
    {
        cameraFieldOfView = camera.fieldOfView;
        xRotationAxis = startRotation / rotationSpeed;
        if (autoRotate)
        {
            autorotationCoroutine = StartCoroutine(AutorotationTimer());
        }
    }

    private void Update()
    {
        Zoom();
    }

    private void LateUpdate()
    {
        
        if (!followingTarget)
        {
            ManualRotation();
        } else { 
            FollowTarget(); 
        }
        if (autorotationTurnedOn)
        {
            AutoRotation();
        }
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

        xRotationAxis += xVelocity * Time.deltaTime * 200;
        yRotationAxis += yVelocity;

        yRotationAxis = ClampAngleBetweenMinAndMax(yRotationAxis, rotationLimit.x, rotationLimit.y);

        rotation = Quaternion.Euler(yRotationAxis, xRotationAxis * rotationSpeed, 0);
        position = rotation * new Vector3(0f, 0f, -zAxisDistance) + target.position;

        transform.rotation = rotation;
        transform.position = position;

        xVelocity = Mathf.Lerp(xVelocity, 0, deltaTime * rotationSmoothing);
        yVelocity = Mathf.Lerp(yVelocity, 0, deltaTime * rotationSmoothing);
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

    void FollowTarget()
    {
        Quaternion rotation;
        rotation = Quaternion.Euler(yRotationAxis, xRotationAxis * rotationSpeed, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 5 * Time.fixedDeltaTime);
        transform.position = Vector3.Lerp(transform.position, rotation * new Vector3(0f, 0f, -zAxisDistance) + target.position, 4 * Time.fixedDeltaTime);


        Vector3 distance = transform.position - (rotation * new Vector3(0f, 0f, -zAxisDistance) + target.position);
        float angleDifference = Quaternion.Angle(transform.rotation, rotation);

        if (distance.magnitude < 0.5f && angleDifference < 0.01f)
        {
            followingTarget = false;
        }
    }

    public static void ChangeTarget(String targetUIGroup)
    {
        switch (targetUIGroup)
        {
            case "wheelsGroup":
                yRotationAxis = 17.21f;
                xRotationAxis = 626.0f;
                target = PartsChanger.Wheel3DAnchor.transform;
                camera.fieldOfView = 30;
                followingTarget = true;
                break;
            case "spoilersGroup":
                yRotationAxis = 19.04f;
                xRotationAxis = 2480.05f;
                target = PartsChanger.Spoiler3DAnchor.transform;
                camera.fieldOfView = 20;
                followingTarget = true;
                break;
            case "exhaustsGroup":
                yRotationAxis = 16.09f;
                xRotationAxis = 3212.9f;
                target = PartsChanger.Exhaust3DAnchor.transform;
                camera.fieldOfView = 20;
                followingTarget = true;
                break;
            case "materialsGroup":
                yRotationAxis = 20.57f;
                xRotationAxis = 2285.57f;
                target = PartsChanger.Car.transform;
                camera.fieldOfView = 60;
                followingTarget = true;
                break;
            case "backButton":
                yRotationAxis = 20.57f;
                xRotationAxis = 2285.57f;
                target = PartsChanger.Car.transform;
                camera.fieldOfView = 60;
                followingTarget = true;
                break;
        }
    }

    public static void ChangeTarget(Transform newTarget)
    {
        yRotationAxis = 20.57f;
        xRotationAxis = 2285.57f;
        target = newTarget;
        camera.fieldOfView = 60;
        followingTarget = true;
    }

    void AutoRotation()
    {
        xVelocity += autoRotationSpeed * 250 * xRotationSensitivity * Time.deltaTime;
    }

    public IEnumerator AutorotationTimer()
    {
        yield return new WaitForSeconds(5);
        autorotationTurnedOn = true;
    }
}
