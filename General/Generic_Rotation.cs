//This script should be attached to an empty GameObject with rotation 0,0,0
//The object you want to see rotate should then be made a child of the GameObject with the script attached

using UnityEngine;

public class Generic_Rotation : MonoBehaviour
{

    public enum ax { x, y, z }
    //Which axis to rotate on
    public ax axis;

    //This variable helps decide the axis of rotation
    private Vector3 axisVector3;
    //Keeps track of time passed while lerping
    private float currentLerpTime;
    [Tooltip("The amount of time it will take to do one rotation")]
    public float lerpTime = 3;
    //Value to lerp from
    private Quaternion startRot;
    //Array containing angles to rotate to
    private float[] targetRot;
    //Keeps track of which angle in the targetRot array we are currently at / aiming for
    private int rotationCount = 0;
    [Tooltip("The no. of rotations to make before the object will reach 360 degrees")]
    public int noOfRotationPoints = 4;
    //Used to reverse direction of rotation if necessary
    private int rotationDirectionCorrector;

    private bool isRotating = false;
    public bool clockwise = true;

    void Start()
    {
        //Setting the angle targets
        targetRot = new float[noOfRotationPoints];
        for (int i = 0; i < targetRot.Length; i++)
        {
            targetRot[i] = i * (360 / noOfRotationPoints);
        }

        switch (axis)
        {
            case ax.x:
                axisVector3 = Vector3.right;
                break;
            case ax.y:
                axisVector3 = Vector3.up;
                break;
            case ax.z:
                axisVector3 = Vector3.forward;
                break;
        }

        if (clockwise)
        {
            rotationDirectionCorrector = 1;
        }
        else
        {
            rotationDirectionCorrector = -1;
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            if (!isRotating)
            {
                StartRotating();
            }
        }

        if (isRotating)
        {
            Turn();
        }
    }

    void StartRotating()
    {
        startRot = transform.rotation;

        rotationCount++;
        if (rotationCount > targetRot.Length - 1)
        {
            rotationCount = 0;
        }
        isRotating = true;
    }

    void Turn()
    {
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime)
        {
            currentLerpTime = lerpTime;
        }

        float t = currentLerpTime / lerpTime;
        t = Mathf.Sin(t * Mathf.PI * 0.5f);

        transform.rotation = Quaternion.Lerp(startRot, Quaternion.Euler(axisVector3 * targetRot[rotationCount] * rotationDirectionCorrector), t);

        //Finished Rotating
        if (currentLerpTime >= lerpTime)
        {
            isRotating = false;
            currentLerpTime = 0;
        }
    }
}
