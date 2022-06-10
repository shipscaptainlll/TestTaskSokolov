using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZoomMode
{
    CameraFieldOfView,
    ZAxisDistance
}

public class OrbitCamera : MonoBehaviour
{
    [Header("Automatic Rotation")]
    [Tooltip("Toggles whether the camera will automatically rotate around it's target")]
    [SerializeField] bool autoRotate = true;
    [Tooltip("The speed at which the camera will auto-pan.")]
    [SerializeField] float rotationSpeed = 0.1f;
    [Tooltip("The rotation along the y-axis the camera will have at start.")]
    [SerializeField] float startRotation = 180;
    [Header("Manual Rotation")]
    [Tooltip("The smoothness coming to a stop of the camera afer the uses pans the camera and releases. Lower values result in significantly smoother results. This means the camera will take longer to stop rotating")]
    [SerializeField] float rotationSmoothing = 2f;
    [Tooltip("The object the camera will focus on.")]
    [SerializeField] Transform target;
    [Tooltip("How sensative the camera-panning is when the user pans -- the speed of panning.")]
    [SerializeField] float yRotationSensitivity = 1f;
    [SerializeField] float xRotationSensitivity = 1f;
    [Tooltip("The min and max distance along the Y-axis the camera is allowed to move when panning.")]
    [SerializeField] Vector2 rotationLimit = new Vector2(5, 80);
    [Tooltip("The position along the Z-axis the camera game object is.")]
    [SerializeField] float zAxisDistance = 0.45f;
    [Header("Zooming")]
    [Tooltip("Whether the camera should zoom by adjusting it's FOV or by moving it closer/further along the z-axis")]
    [SerializeField] ZoomMode zoomMode = ZoomMode.CameraFieldOfView;
    [Tooltip("The minimum and maximum range the camera can zoon using the camera's FOV.")]
    [SerializeField] Vector2 cameraZoomRangeFOV = new Vector2(10, 60);
    [Tooltip("The minimum and maximum range the camera can zoon using the camera's z-axis position.")]
    [SerializeField] Vector2 cameraZoomRangeZAxis = new Vector2(10, 60);
    [SerializeField] float zoomSoothness = 10f;
    [Tooltip("How sensative the camera zooming is -- the speed of the zooming.")]
    [SerializeField] float zoomSensitivity = 2;

    new private Camera camera;
    private float cameraFieldOfView;
    new private Transform transform;
    private SurroundingInitializator surroundingInitializator;
    private float xVelocity;
    private float yVelocity;
    private float xRotationAxis;
    private float yRotationAxis;
    private float zoomVelocity;
    private float zoomVelocityZAxis;

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
        //Sets the camera's rotation along the y axis.
        //The reason we're dividing by rotationSpeed is because we'll be multiplying by rotationSpeed in LateUpdate.
        //So we're just accouinting for that at start.
        xRotationAxis = startRotation / rotationSpeed;
        
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
        //If auto rotation is enabled, just increment the xVelocity value by the rotationSensitivity.
        //As that value's tied to the camera's rotation, it'll rotate automatically.
        if (autoRotate)
        {
            xVelocity += xRotationSensitivity * Time.deltaTime;
        }
        if (target)
        {
            Quaternion rotation;
            Vector3 position;
            float deltaTime = Time.deltaTime;

            //We only really want to capture the position of the cursor when the screen when the user is holding down left click/touching the screen
            //That's why we're checking for that before campturing the mouse/finger position.
            //Otherwise, on a computer, the camera would move whenever the cursor moves. 
            if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
            {
                xVelocity += Input.GetAxis("Mouse X") * xRotationSensitivity;
                yVelocity -= Input.GetAxis("Mouse Y") * yRotationSensitivity;
            }

            xRotationAxis += xVelocity;
            yRotationAxis += yVelocity;

            //Clamp the rotation along the y-axis between the limits we set. 
            //Limits of 360 or -360 on any axis will allow the camera to rotate unrestricted
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


        //Zooms the camera in using the mouse scroll wheel
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (zoomMode == ZoomMode.CameraFieldOfView)
            {
                //cameraFieldOfView -= (zoomSoothness * zoomVelocity * Time.deltaTime);
                cameraFieldOfView = Mathf.SmoothDamp(cameraFieldOfView, cameraZoomRangeFOV.x, ref zoomVelocity, deltaTime * zoomSoothness);

                /*
                //prevents the field of view from going below the minimum value
                if (cameraFieldOfView <= cameraZoomRangeFOV.x)
                {
                    cameraFieldOfView = cameraZoomRangeFOV.x;
                }
                */
            }
            else
            {
                if (zoomMode == ZoomMode.ZAxisDistance)
                {
                    zAxisDistance = Mathf.SmoothDamp(zAxisDistance, cameraZoomRangeZAxis.x, ref zoomVelocityZAxis, deltaTime * zoomSoothness);

                    /*
                    //prevents the z axis distance from going below the minimum value
                    if (zAxisDistance <= cameraZoomRangeZAxis.x)
                    {
                        zAxisDistance = cameraZoomRangeZAxis.x;
                    }
                    */
                }
            }
        }
        else
        {
            //Zooms the camera out using the mouse scroll wheel
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (zoomMode == ZoomMode.CameraFieldOfView)
                {
                    //cameraFieldOfView += (zoomSoothness * zoomVelocity * Time.deltaTime);
                    cameraFieldOfView = Mathf.SmoothDamp(cameraFieldOfView, cameraZoomRangeFOV.y, ref zoomVelocity, deltaTime * zoomSoothness);

                    /*
                    //prevents the field of view from exceeding the max value
                    if (cameraFieldOfView >= cameraZoomRangeFOV.y)
                    {
                        cameraFieldOfView = cameraZoomRangeFOV.y;
                    }
                    */
                }
                else
                {
                    if (zoomMode == ZoomMode.ZAxisDistance)
                    {
                        zAxisDistance = Mathf.SmoothDamp(zAxisDistance, cameraZoomRangeZAxis.y, ref zoomVelocityZAxis, deltaTime * zoomSoothness);

                        /*
                        //prevents the z axis distance from exceeding the max value
                        if (zAxisDistance >= cameraZoomRangeZAxis.y)
                        {
                            zAxisDistance = cameraZoomRangeZAxis.y;
                        }
                        */
                    }
                }

            }
        }

        //We're just ensuring that when we're zooming using the camera's FOV, that the FOV will be updated to match the value we got when we scrolled.
        if (Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            camera.fieldOfView = cameraFieldOfView;
        }
    }

    //Prevents the camera from locking after rotating a certain amount if the rotation limits are set to 360 degrees.
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
