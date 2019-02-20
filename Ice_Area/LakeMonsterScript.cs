using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class LakeMonsterScript : MonoBehaviour
{

    public IceBreaker iceBreaker;
    public Transform navTarget;
    private Transform projector;
    private float navTimer = 0;
    private float wanderDistance = 75;
    public float timeUntilMove = 4.0f;
    private NavMeshAgent navAgent;
    private float moveSpeed;
    private float attackTimer;
    [Tooltip("How much time the player has on the ice before the monster attacks")]
    public float timeUntilAttack = 7;
    private bool timerOn = false;
    private bool attacking = false;
    private bool visible = false;
    [Space]
    public Transform[] raycasters;
    public GameObject[] splashFX;
    public AudioSource attackAudioSource;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        moveSpeed = navAgent.speed;
        projector = transform.GetChild(0);
        navTimer = timeUntilMove;
        navAgent.SetDestination(navTarget.position);
        StartCoroutine(NavTargetTimer());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            //InitiateTimer();
            if (visible)
            {
                StartCoroutine(Dive());
            }
            else
            {
                StartCoroutine(Surface());
            }
        }
    }

    public void InitiateTimer()
    {
        attackTimer = timeUntilAttack;
        if (!timerOn)
        {
            StartCoroutine(AttackTimer());
            StartCoroutine(Surface());
            timerOn = true;
        }
    }

    IEnumerator AttackTimer()
    {
        while (attackTimer > 0)
        {
            yield return new WaitForSeconds(0.1f);
            attackTimer -= 0.1f;
        }
        Attack();
        timerOn = false;
    }

    void Attack()
    {
        if (iceBreaker.playerOn)
        {
            StopCoroutine(NavTargetTimer());
            attacking = true;
            navAgent.speed = moveSpeed * 1.5f;
            StartCoroutine(Attacking());
        }
    }

    IEnumerator Attacking()
    {
        while (Vector3.Distance(transform.position, iceBreaker.player.transform.position) >= 5)
        {
            if (!attacking)
            {
                yield break;
            }
            yield return new WaitForSeconds(0.2f);
            navAgent.SetDestination(iceBreaker.player.transform.position);
        }
        SmashIce();
        for (int i = 0; i < splashFX.Length; i++)
        {
            Instantiate(splashFX[i], iceBreaker.player.transform.position, Quaternion.Euler(Vector3.zero));
        }
        attackAudioSource.Play();
    }

    public void CancelAttack()
    {
        if (attacking)
        {
            attacking = false;
            navAgent.speed = moveSpeed;
            MoveNavTarget();
        }
        StartCoroutine(Dive());
    }

    IEnumerator NavTargetTimer()
    {
        while (navTimer > 0)
        {
            yield return new WaitForSeconds(0.1f);
            if (Vector3.Distance(transform.position, navTarget.position) < 10)
            {
                break;
            }
            navTimer -= 0.1f;
        }
        if (!attacking)
        {
            MoveNavTarget();
        }
    }

    void MoveNavTarget()
    {
        if (iceBreaker.playerOn)
        {
            navTarget.position = RandomNavSphere(iceBreaker.player.transform.position, wanderDistance / 3, -1);
        }
        else
        {
            navTarget.position = RandomNavSphere(navTarget.parent.position, wanderDistance, -1);
        }
        navTimer = timeUntilMove;
        navAgent.SetDestination(navTarget.position);
        StartCoroutine(NavTargetTimer());
    }

    IEnumerator Surface()
    {
        while (projector.position.y > 1.0f)
        {
            yield return new WaitForSeconds(0.03f);
            projector.position += Vector3.down * 0.6f;
        }
        visible = true;
    }

    IEnumerator Dive()
    {
        while (projector.position.y < 10.0f)
        {
            yield return new WaitForSeconds(0.05f);
            projector.position += Vector3.up * 0.2f;
        }
        visible = false;
    }

    void SmashIce()
    {
        //iceBreaker.SmashIce(raycasters);
        iceBreaker.FallThroughIce();
        CancelAttack();
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;

        randomDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

        return navHit.position;
    }
}
