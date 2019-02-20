using UnityEngine;

public class CameraTransition : MonoBehaviour
{

    [HideInInspector]
    public ThirdPerson3D charController;
    private Player_Interaction playInt;
    //	private NavMeshAgent navAgent;
    private CameraFollowOrbit cfo;
    private CharacterAnimationController animController;
    private GameObject mainCamera;
    private Transform destination;
    public Transform target;
    private Transform origin;
    [Space]
    public float smoothTime = 0.1f;
    private Vector3 refVector;
    private Quaternion lerpStartRotation;
    private Vector3 lerpStartPosition;

    private float currentLerpTime;
    private float refVelocity;

    private bool rotatingToNewPosition = false;
    private bool rotatingToOldPosition = false;
    private bool repositionControls = false;

    public bool stopCharacterOnActivation = false;
    private bool buttonPressReady = true;
    private bool cameraIsInNewPosition = false;
    [Space]
    public bool hasAnimation = false;
    public Animator anim;
    [Tooltip("The position the character needs to be in so the animation lines up with the scene")]
    public Transform playerAnimationSpot;
    public string animatorParameter;

    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        if (GameObject.FindWithTag("Player") != null)
        {
            charController = GameObject.FindWithTag("Player").GetComponent<ThirdPerson3D>();
            playInt = charController.transform.GetComponent<Player_Interaction>();
            //		navAgent = charController.transform.GetComponent<NavMeshAgent>();
            cfo = GameObject.Find("Camera Look Target").GetComponent<CameraFollowOrbit>();
            animController = anim.transform.GetComponent<CharacterAnimationController>();
            origin = GameObject.Find("Camera Move Target").transform;
            destination = origin;
        }
        this.enabled = false;
    }

    /*
	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player")
		{
			if (!stopCharacterOnActivation)
			{
				MoveToNewPosition();
			}
			else
			{
				buttonPressReady = true;
			}
		}
	}
	void OnTriggerExit(Collider col){
		if (col.tag == "Player")
		{
			if (!stopCharacterOnActivation)
			{
				MoveToOldPosition();
			}
			else
			{
				buttonPressReady = false;
			}
		}
	}*/

    void Update()
    {
        //The player continues to move in the same direction as before the camera moved
        //until the player stops moving; then controls are changed to suit new camera angle
        if (repositionControls)
        {
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                cfo.transform.eulerAngles = new Vector3(cfo.transform.eulerAngles.x, target.eulerAngles.y, cfo.transform.eulerAngles.z);
                repositionControls = false;
            }
        }

        if (buttonPressReady && playInt.can_Highlight)
        {
            if (Input.GetButtonDown("Interact"))
            {
                buttonPressReady = false;

                if (cameraIsInNewPosition)
                {
                    MoveToOldPosition();
                }
                else if (charController.canMove)
                {
                    MoveToNewPosition();
                }
            }
        }

        if (rotatingToNewPosition)
        {
            Rotate();
        }
        if (rotatingToOldPosition)
        {
            Rotate();
        }
    }

    void Rotate()
    {
        //Rotating
        if (rotatingToOldPosition)
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > (smoothTime / 2))
            {
                currentLerpTime = smoothTime / 2;
            }

            float t = currentLerpTime / (smoothTime / 2);
            t = Mathf.Sin(t * Mathf.PI * 0.5f);
            mainCamera.transform.rotation = Quaternion.Lerp(lerpStartRotation, destination.rotation, t);
            mainCamera.transform.position = Vector3.Lerp(lerpStartPosition, destination.position, t);

            //Finished Rotating
            if (currentLerpTime >= smoothTime / 2)
            {
                rotatingToNewPosition = false;
                rotatingToOldPosition = false;
                currentLerpTime = 0;

                charController.canMove = true;
                anim.GetComponent<CharacterAnimationController>().canAnimate = true;
                cameraIsInNewPosition = false;

                buttonPressReady = true;
            }
        }
        else
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > smoothTime)
            {
                currentLerpTime = smoothTime;
            }

            float t = currentLerpTime / smoothTime;
            t = Mathf.Sin(t * Mathf.PI * 0.5f);
            mainCamera.transform.rotation = Quaternion.Lerp(lerpStartRotation, destination.rotation, t);
            mainCamera.transform.position = Vector3.Lerp(lerpStartPosition, destination.position, t);

            //Finished Rotating
            if (currentLerpTime >= smoothTime)
            {
                rotatingToNewPosition = false;
                rotatingToOldPosition = false;
                currentLerpTime = 0;

                cameraIsInNewPosition = true;

                buttonPressReady = true;
            }
        }
    }

    public void MoveToNewPosition()
    {
        lerpStartRotation = mainCamera.transform.rotation;
        lerpStartPosition = mainCamera.transform.position;
        cfo.hasCameraControl = false;
        //		repositionControls = true;

        if (stopCharacterOnActivation)
        {
            animController.canAnimate = false;
            animController.StopAllAnimations();
            charController.canMove = false;
            playInt.can_Interact = false;
        }

        TransitionTo();

        if (hasAnimation)
        {
            //Wait til character is in position
            StartCoroutine(animController.MoveToPosition(playerAnimationSpot, animatorParameter, false));
        }
    }

    private void TransitionTo()
    {
        destination = target;

        rotatingToOldPosition = false;
        //		movingToOldPosition = false;

        rotatingToNewPosition = true;
        //		movingToNewPosition = true;
    }

    public void MoveToOldPosition()
    {
        lerpStartRotation = mainCamera.transform.rotation;
        lerpStartPosition = mainCamera.transform.position;
        repositionControls = false;

        destination = origin;

        rotatingToNewPosition = false;
        //		movingToNewPosition = false;

        rotatingToOldPosition = true;
        //		movingToOldPosition = true;

        cfo.hasCameraControl = true;

        if (hasAnimation)
        {
            anim.SetTrigger("Interact");
        }
    }
}