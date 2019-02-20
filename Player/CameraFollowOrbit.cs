
//This script is to be attached to an empty gameobject that is the parent of a camera
//It will follow a gameobject "target" (set in the inspector) on either the x axis, z axis or all axes (set in inspector)

using UnityEngine;

public class CameraFollowOrbit : MonoBehaviour
{

    #region Variables
    [Header("Camera Follow")]
    [Tooltip("Target for the camera to follow")]
    public Transform target;
    [Tooltip("Time it takes for camera to catch up with target")]
    public float smoothTime = 1.0f;
    private float refFloat;
    private Vector3 refVector;
    private float offsetZ;
    private Vector3 offset;
    private Vector3 orig_Offset;
    private Vector3 temp_Offset;

    public enum fd { x, z, a }
    [Tooltip("The axis/axes on which to follow (X, Z or All)")]
    public fd followDirection;

    [Header("Camera Rotate")]
    [Tooltip("Mouse X Sensitivity")]
    public float turnSpeedX = 0.1f;
    [Tooltip("Mouse Y Sensitivity")]
    public float turnSpeedY = 0.1f;
    [Tooltip("Time it takes for camera to catch up with target")]
    public float smoothRotate = 1.0f;
    public float maxYRotation = 300;
    public float minYRotation = 45;
    [HideInInspector]
    public bool hasCameraControl = true;
    private Transform mainCamera;
    private Transform cameraMoveTarget;
    private Vector3 refRotVector;
    private float refXRot;
    private float refYRot;
    [Tooltip("The layers that the camera can collide with")]
    public LayerMask layerMask;
    private Vector3 refVelocity;

    private Vector3 camRot;
    private float rayLength;
    public float rayExtension;

    #endregion

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined;
        transform.rotation = target.rotation;
        transform.position = target.position + Vector3.up * 0.4f;
        offsetZ = gameObject.transform.position.z - target.position.z;
        offset = gameObject.transform.position - target.position;

        mainCamera = GameObject.FindWithTag("MainCamera").transform;
        cameraMoveTarget = GameObject.Find("Camera Move Target").transform;

        rayLength = (transform.GetChild(0).position - transform.position).magnitude + rayExtension;
    }

    void Update()
    {
        //Setting the camera to smoothly follow the player
        #region CameraFollow
        //Along X-axis
        if (followDirection == fd.x)
        {
            float newPosition = Mathf.SmoothDamp(transform.position.x, target.position.x, ref refFloat, smoothTime);
            transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
        }
        //Along Z-axis
        if (followDirection == fd.z)
        {
            float newPosition = Mathf.SmoothDamp(transform.position.z, target.position.z + offsetZ, ref refFloat, smoothTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, newPosition);
        }
        //Along all axes
        if (followDirection == fd.a)
        {
            Vector3 newPosition = Vector3.SmoothDamp(transform.position, target.position + offset, ref refVector, smoothTime);
            transform.position = newPosition;
        }
        #endregion

        //Rotating the camera based on mouse input
        #region CameraControl
        if (hasCameraControl)
        {
            float h = turnSpeedX * Input.GetAxis("Mouse X") * Time.deltaTime;
            h += Input.GetAxis("Right Stick X") * turnSpeedX * Time.deltaTime;
            float v = turnSpeedY * Input.GetAxis("Mouse Y") * Time.deltaTime;
            v += Input.GetAxis("Right Stick Y") * turnSpeedY * Time.deltaTime;

            transform.Rotate(0, h, 0, Space.World);
            transform.Rotate(v, 0, 0, Space.Self);

            //Clamping the x rotation
            Vector3 rot = transform.localEulerAngles;
            float xRotClamp = rot.x;
            if (xRotClamp > 190)
            {
                xRotClamp -= 360;
            }
            xRotClamp = Mathf.Clamp(xRotClamp, minYRotation, maxYRotation);
            rot.x = xRotClamp;
            rot.z = 0;
            transform.localEulerAngles = rot;

            //Smooth the camera to target position
            SmoothRotate();
        }
        #endregion

        //Preventing the camera from clipping through objects
        #region CameraClipping
        Vector3 dir = transform.GetChild(0).position - transform.position;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, dir, out hit, rayLength, layerMask))
        {
            transform.localScale = Vector3.one * (hit.distance / rayLength);
            if (transform.localScale.z < 0.1f)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 0.1f);
            }
        }
        else
        {
            transform.localScale = Vector3.SmoothDamp(transform.localScale, Vector3.one, ref refVelocity, Time.deltaTime * 10f);
        }
        #endregion
    }

    void SmoothRotate()
    {
        mainCamera.position = Vector3.SmoothDamp(mainCamera.position, cameraMoveTarget.position, ref refRotVector, smoothRotate);
        Vector3 rot = mainCamera.localEulerAngles;
        rot.x = Mathf.SmoothDampAngle(mainCamera.localEulerAngles.x, cameraMoveTarget.eulerAngles.x, ref refXRot, smoothRotate);
        rot.y = Mathf.SmoothDampAngle(mainCamera.localEulerAngles.y, cameraMoveTarget.eulerAngles.y, ref refYRot, smoothRotate);
        rot.z = 0;
        mainCamera.localEulerAngles = rot;
    }
}
