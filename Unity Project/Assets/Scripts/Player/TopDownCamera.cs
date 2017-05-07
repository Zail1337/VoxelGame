using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour {

    public Transform target; //The Target, that the Camera is fallowing

    public static float currentRotationAngle;//Angle to check camera rotation


    //Used to set an max angle for the camera to look up or down
    public float minRotationX = -10;

    [System.Serializable]
    public class PositionSettings
    {
        //distance from Target
        //bools for zooming and Smooth following
        //min and max settings

        public float distanceFromTarget = -50;
        public bool allowZoom = true;
        public float zoomSmooth = 100;
        public float zoomStep = 2;
        public float maxZoom = -30;
        public float minZoom = -60;
        public bool smothFollow = true;
        public float smooth = 0.05f;

        [HideInInspector]
        public float newDistance = -50; //used for smooth zooming - gives us a "destination" zoom
    }

    [System.Serializable]
    public class OrbitSettings
    {
        //holding our current x and y rotation for our camera
        //bool for allowing orbit
        public float xRotation = -65;
        public float yRotation = -180;
        public bool allowOrbit = true;
        public float yOrbitSmooth = 0.5f;
    }

    [System.Serializable]
    public class InputSettings
    {
        public string MOUSE_ORBIT = "MouseOrbit";
        public string ZOOM = "Mouse ScrollWheel";
    }

    public PositionSettings position = new PositionSettings();
    public OrbitSettings orbit = new OrbitSettings();
    public InputSettings input = new InputSettings();

    Vector3 destination = Vector3.zero;
    Vector3 camVelocity = Vector3.zero;
    Vector3 currentMousePosition = Vector3.zero;
    Vector3 previousMousePosition = Vector3.zero;
    float mouseOrbitInput, zoomInput;

    void Start()
    {
        //setting camera Target
        SetCameraTarget(target);

        if (target)
        {
            MoveToTarget();
        }
    }

    public void SetCameraTarget(Transform t)
    {
        //if we want to set a new target while game is running
        target = t;

        if (target == null)
        {
            //Debug.LogError("Your Camera needs a Target!");
        }
    }

    void GetInput()
    {
        //filling the values for our input variables
        mouseOrbitInput = Input.GetAxisRaw(input.MOUSE_ORBIT);
        zoomInput = Input.GetAxisRaw(input.ZOOM);
    }

    void Update()
    {
        //Debug.Log(orbit.xRotation);

        //getting input
        //zooming
        GetInput();
        if (position.allowZoom)
        {
            ZoomInOnTarget();
        }
    }

    void FixedUpdate()                                          //-------------------------------------Fixed Update------------------------------//
    {

        //get Y Angle; used in PlayerMove
        currentRotationAngle = transform.eulerAngles.x;


        //move to target
        //look at tartget
        //orbit
        if (target)
        {
            MoveToTarget();
            LookAtTarget();
            MouseOrbitTarget();
            MouseOrbirUpDown();
        }



    }

    void MoveToTarget()
    {
        //handling getting our camera to its destination position
        destination = target.position;
        destination += Quaternion.Euler(orbit.xRotation, orbit.yRotation, 0) * -Vector3.forward * position.distanceFromTarget;

        if (position.smothFollow)
        {
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref camVelocity, position.smooth);
        }
        else
            transform.position = destination;
    }

    void LookAtTarget()
    {
        //handling getting our camera to look at the target at all time
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = targetRotation;
    }

    void MouseOrbitTarget()
    {
        //getting the camera to orbit around our character
        previousMousePosition = currentMousePosition;
        currentMousePosition = Input.mousePosition;

        if (mouseOrbitInput > 0)
        {
            orbit.yRotation += (currentMousePosition.x - previousMousePosition.x) * orbit.yOrbitSmooth;
        }
    }

    void MouseOrbirUpDown()
    {
        if (mouseOrbitInput > 0)
        {
            if (orbit.xRotation < minRotationX)
            {
                orbit.xRotation += ((currentMousePosition.y - previousMousePosition.y) * orbit.yOrbitSmooth) / 2;
            } else orbit.xRotation = -10.5f;


            if (orbit.xRotation > -60)
            {
                orbit.xRotation += ((currentMousePosition.y - previousMousePosition.y) * orbit.yOrbitSmooth) / 2;
            } else orbit.xRotation = -59;
        }
    }


    void ZoomInOnTarget()
    {
        //modifing the distancefromtarget to be closer or further away from our target
        position.newDistance += position.zoomStep * zoomInput;

        position.distanceFromTarget = Mathf.Lerp(position.distanceFromTarget, position.newDistance, position.zoomSmooth * Time.deltaTime);

        if (position.distanceFromTarget > position.maxZoom)
        {
            position.distanceFromTarget = position.maxZoom;
            position.newDistance = position.maxZoom;
        }
        if (position.distanceFromTarget < position.minZoom)
        {
            position.distanceFromTarget = position.minZoom;
            position.newDistance = position.minZoom;
        }
    }
 }
