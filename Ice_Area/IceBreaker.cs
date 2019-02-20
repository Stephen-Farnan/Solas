using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class IceBreaker : MonoBehaviour
{
    public GameObject player;
    public float rayLength = 0.24f;
    //Vertices that are to be affected by the script
    private int[] targetVertices = new int[33];
    //Triangles that are to be affected by the script
    private int[] storedTriangles = new int[10];
    //Triangles that have been "broken"
    private int[] invisibleTriangles;
    //The positions of target triangles (for spawning effects)
    private Vector3[] trianglePositions = new Vector3[10];
    private int[] crackedVertices;
    private int[] brokenVertices;
    //The number of vertices that have had their UVs switched to cracking ice
    private int crackedIndex = 0;
    //The number of UVs that have had their UVs switched to broken
    //	private int brokenIndex = 0;

    private Vector2[] originalUVs;

    private MeshCollider meshCollider;
    private Mesh mesh;
    private int storedTriangleCount = 0;
    private int storedUVs = 0;
    private int storedPositions = 0;
    private int invisTriangleCount = 0;

    [HideInInspector]
    public bool playerOn = false;
    private bool iceCracking = false;
    private bool playerIsDead = false;

    public GameObject camera_Target;
    public FootprintSpawnScript footprintScript;

    public float iceBreakDelay;
    public LayerMask layerMask;
    [Space]
    public GameObject[] iceBreakFX;
    public GameObject waterRippleFX;
    public GameObject[] blizzardFX;
    [Space]
    public LakeMonsterScript lakeMonster;
    public Transform[] raycasters;
    private AudioSource audioSource;
    public IceBreaker otherIceScript;

    void Start()
    {
        meshCollider = GetComponent<MeshCollider>();
        mesh = meshCollider.sharedMesh;
        //mesh = GetComponent<MeshFilter>().sharedMesh;

        //crackedVertices = new int[mesh.vertices.Length];
        //brokenVertices = new int[mesh.vertices.Length];

        //All triangles in the mesh could potentially become broken
        invisibleTriangles = new int[mesh.triangles.Length];

        //Storing the original UV values so they can be reset later
        originalUVs = mesh.uv;

        audioSource = GetComponent<AudioSource>();
    }


    void OnCollisionEnter(Collision col)
    {
        PlayerOn(col);
    }

    void OnCollisionExit(Collision col)
    {
        PlayerOff(col);
    }

    void Update()
    {
        //For Testing
        /*
		if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.RightShift) && Input.GetKeyDown(KeyCode.J))
		{
			FixUVs();
		}
		*/

        if (playerOn)
        {
            if (player.GetComponent<ThirdPerson3D>().isRunning && !playerIsDead)
            {
                RaycastCheck(player.transform.GetChild(1).position + Vector3.up * 0.2f);
            }
        }

        Debug.DrawRay(player.transform.GetChild(1).position + Vector3.up * 0.2f, Vector3.down * rayLength, Color.red);
    }

    void PlayerOn(Collision col)
    {
        if (!playerOn)
        {
            if (col.transform.tag == "Player" && !playerIsDead)
            {
                //Debug.Log("PLayer ON");
                playerOn = true;
                footprintScript.snowFootprints = false;
                footprintScript.ChangeFootprintSound(FootprintSpawnScript.FootPrintSound.ice);
                if (lakeMonster != null)
                {
                    lakeMonster.InitiateTimer();
                }
            }
        }
    }

    void PlayerOff(Collision col)
    {
        if (playerOn)
        {
            if (col.transform.tag == "Player" && !playerIsDead)
            {
                //Debug.Log("PLayer OFF");
                playerOn = false;
                footprintScript.snowFootprints = true;
                footprintScript.ChangeFootprintSound(FootprintSpawnScript.FootPrintSound.snow);
                if (lakeMonster != null)
                {
                    lakeMonster.CancelAttack();
                }
            }
        }
    }

    void RaycastCheck(Vector3 rayOrigin)
    {
        RaycastHit hit;
        float finalRayLength;
        if (!playerIsDead)
        {
            finalRayLength = rayLength;
        }
        else
        {
            finalRayLength = rayLength * 7;
        }

        if (Physics.Raycast(rayOrigin, Vector3.down * finalRayLength, out hit, finalRayLength, layerMask))
        {
            //Debug.DrawRay(rayOrigin, Vector3.down * finalRayLength, Color.red);

            for (int i = 0; i < invisibleTriangles.Length; i++)
            {
                //If the triangle has already disappeared, fall through
                if (hit.triangleIndex == invisibleTriangles[i] && hit.triangleIndex != 0)
                {
                    if (!playerIsDead)
                    {
                        FallThroughIce();
                        audioSource.Play();
                    }
                    return;
                }
            }

            if (hit.transform.gameObject.layer == 0)
            {
                //Debug.Log("Hit Default");
                //playerOn = false;
                return;
            }
            else
            {
                if (!playerIsDead)
                {
                    playerOn = true;
                    if (!iceCracking)
                    {
                        StartCoroutine(IceBreakCountdown());
                    }
                }
            }

            for (int i = 0; i < storedTriangles.Length; i++)
            {
                //If the triangle is one we've already stored (is about to break), end function
                if (hit.triangleIndex == storedTriangles[i])
                {
                    return;
                }
            }
            //If the triangle is not already stored, store it
            storedTriangles[storedTriangleCount] = hit.triangleIndex;
            storedTriangleCount++;

            //Store the positions of cracking triangles for fx spawning
            trianglePositions[storedPositions] = hit.point;
            storedPositions++;

            //Storing UVs of stored triangles
            StoreUVs(hit.triangleIndex);
        }
    }

    void StoreUVs(int triangle)
    {
        //Debug.Log("Store UVs");
        Vector3[] vertices = mesh.vertices;
        int[] triangles = mesh.triangles;

        for (int i = storedUVs; i < (storedUVs + 3); i++)
        {
            targetVertices[i] = triangles[triangle * 3 + (i - storedUVs)];
        }
        storedUVs += 3;

        CrackIce();
    }

    void CrackIce()
    {
        //Debug.Log("Crack Ice");
        Vector2[] uvs = mesh.uv;

        for (int i = crackedIndex; i < targetVertices.Length; i++)
        {
            uvs[targetVertices[i]] += new Vector2(0, 0.5f);
        }
        mesh.uv = uvs;
        crackedIndex += 3;
    }

    void BreakIce()
    {
        if (!playerIsDead)
        {
            Vector2[] uvs = mesh.uv;

            for (int i = 0; i < targetVertices.Length; i++)
            {
                uvs[targetVertices[i]] += new Vector2(-0.5f, 0);
            }

            mesh.uv = uvs;

            PlayIceBreakEffect();
            audioSource.Play();

            for (int i = 0; i < storedTriangles.Length; i++)
            {
                if (storedTriangles[i] == 0)
                {
                    break;
                }
                else
                {
                    invisibleTriangles[invisTriangleCount] = storedTriangles[i];
                    invisTriangleCount++;
                }
            }

            if (playerOn)
            {
                FallThroughIce();
            }
            else
            {
                iceCracking = false;
            }
        }
    }

    public void SmashIce(Transform[] raycasters)
    {
        ResetVariables();

        for (int i = 0; i < raycasters.Length; i++)
        {
            RaycastCheck(raycasters[i].position);
        }

        RaycastCheck(player.transform.position);

        Vector2[] uvs = mesh.uv;

        for (int i = 0; i < targetVertices.Length; i++)
        {
            uvs[targetVertices[i]] += new Vector2(-0.5f, 0);
        }

        mesh.uv = uvs;

        PlayIceBreakEffect();
    }

    void FixUVs()
    {
        //Debug.Log("Fix UVs");
        mesh.uv = originalUVs;
        otherIceScript.mesh.uv = otherIceScript.originalUVs;
    }

    IEnumerator IceBreakCountdown()
    {
        //Debug.Log("Ice Break Countdown");
        iceCracking = true;

        yield return new WaitForSeconds(iceBreakDelay);

        BreakIce();

        //Moved to BreakIce()
        /*
		for (int i = 0; i < storedTriangles.Length; i++)
		{
			if (storedTriangles[i] == 0)
			{
				break;
			}
			else {
				invisibleTriangles[invisTriangleCount] = storedTriangles[i];
				invisTriangleCount++;
			}
		}
		*/

        //Resetting variables/arrays
        ResetVariables();
    }

    void ResetVariables()
    {
        storedTriangles = new int[10];
        targetVertices = new int[33];
        trianglePositions = new Vector3[10];
        storedTriangleCount = 0;
        storedUVs = 0;
        storedPositions = 0;
        crackedIndex = 0;
    }

    public void FallThroughIce()
    {
        if (!playerIsDead)
        {
            playerIsDead = true;
            playerOn = false;
            SmashIce(raycasters);
            meshCollider.enabled = false;
            camera_Target.SetActive(false);
            //local_NavMeshAgent.enabled = false;
            player.GetComponent<NavMeshAgent>().enabled = false;
            player.GetComponent<CapsuleCollider>().enabled = false;
            player.GetComponent<Player_Manager>().Kill_Player();
            player.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Pit Trap");

            //Unparent blizzard fx
            for (int i = 0; i < blizzardFX.Length; i++)
            {
                blizzardFX[i].transform.parent = null;
            }

            //Spawn water ripple effect
            Instantiate(waterRippleFX, player.transform.position - Vector3.up * 0.5f, Quaternion.Euler(Vector3.zero));

            StartCoroutine(WaitToResetUVs());
        }
    }

    void PlayIceBreakEffect()
    {
        for (int i = 0; i < storedPositions; i++)
        {
            for (int j = 0; j < iceBreakFX.Length; j++)
            {
                Instantiate(iceBreakFX[j], trianglePositions[i], Quaternion.Euler(Vector3.zero));
            }
        }
    }

    IEnumerator WaitToResetUVs()
    {
        yield return new WaitForSeconds(5);
        FixUVs();
    }
}
