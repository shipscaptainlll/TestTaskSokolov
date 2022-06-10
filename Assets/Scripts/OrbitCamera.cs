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
    [SerializeField] float zoomSoothness = 10f;
    [Header("Aurotation")]
    [SerializeField] bool autoRotate = true;
    [SerializeField] float rotationSpeed = 0.1f;
    [SerializeField] float startRotation = 180;

    Transform target;
    new Camera camera;
    float cameraFieldOfView;
    new Transform transform;
    SurroundingInitializator surroundingInitializator;
    float xVelocity;
    float yVelocity;
    float xRotationAxis;
    float yRotationAxis;
    float zoomVelocity;

    Coroutine autorotationCoroutine;
    bool autorotationTurnedOn;

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
    }

    public void ChangeTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void Update()
    {
        Zoom();
    }

    private void LateUpdate()
    {
        if (autorotationTurnedOn)
        {
            xVelocity += rotationSpeed * xRotationSensitivity;
        }
        if (target)
        {
            
            
            Quaternion rotation;
            Vector3 position;
            float deltaTime = Time.deltaTime;

            if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
            {
                if(autorotationCoroutine != null)
                {
                    StopAllCoroutines();
                    autorotationCoroutine = StartCoroutine(AutorotationTimer());
                }
                if (autorotationTurnedOn)
                {
                    autorotationTurnedOn = false;
                    StartCoroutine(AutorotationTimer());
                }

                xVelocity += Input.GetAxis("Mouse X") * xRotationSensitivity;
                yVelocity -= Input.GetAxis("Mouse Y") * yRotationSensitivity;
            }

            xRotationAxis += xVelocity;
            yRotationAxis += yVelocity;

            yRotationAxis = ClampAngleBetweenMinAndMax(yRotationAxis, rotationLimit.x, rotationLimit.y);

            rotation = Quaternion.Euler(yRotationAxis, xRotationAxis * rotationSpeed, 0);
            position = rotation * new Vector3(0f, 0f, -zAxisDistance) + target.position;

            transform.rotation = rotation;
            transform.position = position;

            xVelocity = Mathf.Lerp(xVelocity, 0, deltaTime * rotationSmoothing);
            yVelocity = Mathf.Lerp(yVelocity, 0, deltaTime * rotationSmoothing);
        }
    }

    private void Zoom()
    {
        float deltaTime = Time.deltaTime;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            cameraFieldOfView = Mathf.SmoothDamp(cameraFieldOfView, cameraZoomRangeFOV.x, ref zoomVelocity, deltaTime * zoomSoothness);
        }
        else
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                cameraFieldOfView = Mathf.SmoothDamp(cameraFieldOfView, cameraZoomRangeFOV.y, ref zoomVelocity, deltaTime * zoomSoothness);
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            camera.fieldOfView = cameraFieldOfView;
        }
    }

    public IEnumerator AutorotationTimer()
    {
        yield return new WaitForSeconds(2);
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
