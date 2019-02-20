using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ThirdPerson3D : MonoBehaviour
{

    #region Variables
    [Header("Movement")]
    public float walkSpeed;
    public float runSpeed;
    public float turnSpeed;
    public float acc = 0.2f;
    public float decc = 0.1f;
    public float run_Threshold = .75f;
    public float dodge_Distance = 1f;
    public float dodge_Cooldown = 3f;
    public float dodge_Duration = 1.1f;
    [HideInInspector]
    public bool canMove = true;
    public bool is_Dead = false;
    private float targetSpeed;
    public LayerMask collisionMask;
    [HideInInspector]
    public bool dodge_Available = true;
    //private bool isObstructed = false;
    private NavMeshAgent navMeshAgent;
    public bool player_Is_In_Control = true;
    [HideInInspector]
    public bool isRunning = false;


    private float speed;
    private float velocitySmoothing;

    //The camera relative to which the player will be moving
    public Transform cameraTarget;

    [Tooltip("Is this scene an indoor scene?")]
    public bool isIndoors = false;
    #endregion

    void Start()
    {
        //Resetting mesh rotation
        transform.GetChild(0).rotation = transform.rotation;

        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {


        if (!is_Dead)
        {
            //Creating a reference to axis inputs and normalizing to prevent faster diagonal motion
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            //This variable will be equal to either acceleration or decceleration depending on input
            float moveRate = decc;
            if (canMove && !is_Dead && player_Is_In_Control)
            {
                if (input.x != 0 || input.y != 0)
                {
                    if (!isIndoors)
                    {
                        //If left shift, run
                        if (Input.GetKey(KeyCode.LeftShift) || input.x > run_Threshold || input.x < -run_Threshold || input.y > run_Threshold || input.y < -run_Threshold || Input.GetAxis("Walk") > .2)
                        {
                            if (Input.GetKey(KeyCode.LeftShift) || Input.GetAxis("Walk") > .2)
                            {
                                targetSpeed = walkSpeed;
                                isRunning = false;
                            }
                            else
                            {
                                targetSpeed = runSpeed;
                                isRunning = true;
                            }
                        }
                        else
                        {
                            targetSpeed = walkSpeed;
                            isRunning = false;
                        }
                    }
                    else
                    {
                        targetSpeed = walkSpeed;
                        isRunning = false;
                    }

                    moveRate = acc;

                    //Rotating the player to face direction of input
                    float newYRotation = cameraTarget.eulerAngles.y + Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, newYRotation, 0), turnSpeed);
                }
                else
                {
                    targetSpeed = 0;
                    moveRate = decc;
                    isRunning = false;
                }

                //Move
                speed = Mathf.SmoothDamp(speed, targetSpeed, ref velocitySmoothing, moveRate);
                //transform.Translate(Vector3.forward * speed * Time.deltaTime);
                //GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
                navMeshAgent.Move(transform.forward * speed * Time.deltaTime);
            }
        }
    }

    IEnumerator Player_Dodge()
    {
        Dodge();
        yield return new WaitForSeconds(dodge_Duration);
        canMove = true;
        decc = 0.1f;
        yield return new WaitForSeconds(dodge_Cooldown);
        dodge_Available = true;
    }

    void Dodge()
    {
        speed = 0f;
        targetSpeed = 0f;
        decc = 0f;
        gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * dodge_Distance, ForceMode.VelocityChange);
        canMove = false;
        dodge_Available = false;
    }
}

