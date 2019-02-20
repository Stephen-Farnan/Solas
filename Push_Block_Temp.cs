using System.Collections;
using UnityEngine;

public class Push_Block_Temp : MonoBehaviour
{

    public CharacterAnimationController charAnim;
    private Transform animationPoint;
    private bool isInTriggerBox = false;
    private bool isMoving = false;
    public Transform targetPos;
    private Vector3 startPos;
    private float currentLerp = 0;
    public float totalLerp = 2;
    //Temporary variable to ensure only one interaction at a time
    private bool hasInteracted = false;

    void Start()
    {
        animationPoint = transform.GetChild(0);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            isInTriggerBox = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            isInTriggerBox = false;
        }
    }

    void Update()
    {
        if (isInTriggerBox)
        {
            if (Input.GetButtonDown("Interact"))
            {
                if (!hasInteracted)
                {
                    charAnim.sender = gameObject;
                    StartCoroutine(charAnim.MoveToPosition(animationPoint, "Push Block", true));
                    hasInteracted = true;
                }
            }
        }

        if (isMoving)
        {
            Move();
        }
    }

    public void Interact()
    {
        StartCoroutine(WaitToPushBlock());
    }

    IEnumerator WaitToPushBlock()
    {
        yield return new WaitForSeconds(0.75f);

        startPos = transform.position;

        isMoving = true;
    }

    void Move()
    {
        currentLerp += Time.deltaTime;
        if (currentLerp > totalLerp)
        {
            currentLerp = totalLerp;
        }

        float t = currentLerp / totalLerp;

        transform.position = Vector3.Lerp(startPos, targetPos.position, t);

        //Finished Rotating
        if (currentLerp >= totalLerp)
        {
            isMoving = false;
            hasInteracted = false;
            currentLerp = 0;
            targetPos.position = startPos;
        }
    }
}
