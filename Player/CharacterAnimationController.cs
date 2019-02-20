using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimationController : MonoBehaviour
{

    public Animator anim;
    /*
	public ParticleSystem psRight;
	public ParticleSystem psLeft;
	private bool footstepParticlesPlaying = false;
	*/
    public NavMeshAgent navAgent;

    private Player_Interaction playInt;
    public ThirdPerson3D charController;
    [HideInInspector]
    public bool canAnimate = true;
    [Space]
    //public bool snowFootsteps = true;
    public bool isIndoors = false;

    private float overrideTimer = 0;

    private float refVelocity;

    [HideInInspector]
    public GameObject sender;

    void Start()
    {
        playInt = charController.transform.GetComponent<Player_Interaction>();
    }

    void Update()
    {
        if (charController.canMove)
        {
            if (!canAnimate)
            {
                canAnimate = true;
            }

            if (!isIndoors)
            {
                if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                {
                    if (Input.GetKey(KeyCode.LeftShift) || (Input.GetAxis("Walk") > .2))
                    {
                        anim.SetBool("Run", false);
                        anim.SetBool("Walk", transform);
                    }
                    else
                    {
                        anim.SetBool("Walk", false);
                        anim.SetBool("Run", true);
                    }
                }
                else
                {
                    anim.SetBool("Run", false);
                    anim.SetBool("Walk", false);
                }

                /*if (Input.GetButtonDown("Jump"))
				{
					if (charController.dodge_Available)
					{
						anim.SetTrigger("Dive");
					}
				}*/
            }
            else
            {
                if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                {
                    anim.SetBool("Walk", true);
                }
                else
                {
                    anim.SetBool("Walk", false);
                }
            }
        }
        else if (canAnimate)
        {
            StopAllAnimations();
            canAnimate = false;
        }

        //Play death animation code here
    }

    public void StopAllAnimations()
    {
        foreach (AnimatorControllerParameter parameter in anim.parameters)
        {
            anim.SetBool(parameter.name, false);
        }
    }

    public IEnumerator MoveToPosition(Transform playerAnimationSpot, string animatorParameter, bool oneShotAnimation)
    {
        canAnimate = false;
        StopAllAnimations();
        charController.canMove = false;
        //playInt.can_Interact = false;
        navAgent.SetDestination(playerAnimationSpot.position);
        anim.SetBool("Walk", true);
        navAgent.isStopped = false;

        while (Vector2.Distance(new Vector2(navAgent.transform.position.x, navAgent.transform.position.z), new Vector2(playerAnimationSpot.position.x, playerAnimationSpot.position.z)) > navAgent.stoppingDistance * 1.1f)
        {
            yield return new WaitForSeconds(0.1f);
            overrideTimer += 0.1f;
            if (overrideTimer >= 1.5f)
            {
                //Debug.Log("Time Limit Reached");
                break;
            }
        }
        navAgent.isStopped = true;
        navAgent.transform.position = new Vector3(playerAnimationSpot.position.x, navAgent.transform.position.y, playerAnimationSpot.position.z);
        overrideTimer = 0;
        StartCoroutine(RotateToPosition(playerAnimationSpot, animatorParameter, oneShotAnimation));
    }
    IEnumerator RotateToPosition(Transform playerAnimationSpot, string animatorParameter, bool oneShotAnimation)
    {
        //while (Vector2.Angle(new Vector2 (charController.transform.eulerAngles.x, charController.transform.eulerAngles.z), new Vector2 (playerAnimationSpot.eulerAngles.x, playerAnimationSpot.eulerAngles.z)) > 10.0f)
        while (Mathf.DeltaAngle(charController.transform.eulerAngles.y, playerAnimationSpot.eulerAngles.y) > 10.0f)
        {
            charController.transform.rotation = Quaternion.Lerp(charController.transform.rotation, playerAnimationSpot.rotation, overrideTimer);
            /*
			Vector3 rot = charController.transform.eulerAngles;
			rot.y = Mathf.SmoothDampAngle(charController.transform.eulerAngles.y, playerAnimationSpot.eulerAngles.y, ref refVelocity, 0.3f);
			charController.transform.eulerAngles = rot;*/

            overrideTimer += Time.deltaTime;
            if (overrideTimer > 1.2f)
            {
                break;
            }
            yield return null;
        }
        overrideTimer = 0;
        charController.transform.rotation = playerAnimationSpot.rotation;
        anim.SetBool("Walk", false);
        StartCoroutine(PlayAnimation(animatorParameter, oneShotAnimation));

        //Temporary code to get the push block script going
        if (sender != null)
        {
            sender.SendMessage("Interact");
        }
    }

    private IEnumerator PlayAnimation(string animatorParameter, bool oneShotAnimation)
    {
        anim.SetTrigger(animatorParameter);

        yield return new WaitForSeconds(0.9f);

        AnimatorClipInfo[] currentClipInfo = anim.GetCurrentAnimatorClipInfo(0);
        //Access the length of the current animation
        float currentClipLength = currentClipInfo[0].clip.length;

        if (playInt.interactionGameObject != null)
        {
            if (playInt.interactionGameObject.transform.parent.tag == "Block")
            {
                PushBlock();
            }
        }
        yield return new WaitForSeconds(currentClipLength);

        //playInt.can_Interact = true;
        playInt.can_Highlight = true;
        sender = null;

        if (oneShotAnimation)
        {
            charController.canMove = true;
        }
    }

    public void PullLever()
    {
        playInt.interactionGameObject.transform.parent.GetComponent<Animator>().SetTrigger("Pull Lever");
    }

    void PushBlock()
    {
        playInt.interactionGameObject.transform.parent.GetComponent<Ice_Temple_Block_Script>().PushBlock(playInt.interactionGameObject.name);
    }
}
