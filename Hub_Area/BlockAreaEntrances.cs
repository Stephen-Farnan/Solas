using UnityEngine;
using UnityEngine.AI;

public class BlockAreaEntrances : MonoBehaviour
{

    public BoxCollider trapAreaTrigger;
    public BoxCollider iceAreaTrigger;
    public BoxCollider mountainAreaTrigger;

    public GameObject[] fogWalls;
    private ProgressManager progMan;

    void Start()
    {
        progMan = GameObject.FindWithTag("Scene_Manager").GetComponent<ProgressManager>();

        if (progMan.templesCompleted[1])
        {
            BlockTrapArea();
        }
        if (progMan.templesCompleted[2])
        {
            BlockMountainArea();
        }
        if (progMan.templesCompleted[3])
        {
            BlockIceArea();
        }

        if (progMan.noOfTemplesCompleted == 0)
        {
            BlockTrapArea();
            BlockMountainArea();
            BlockIceArea();
        }
    }

    void BlockTrapArea()
    {
        trapAreaTrigger.isTrigger = false;
        trapAreaTrigger.GetComponent<NavMeshObstacle>().enabled = true;
        fogWalls[0].SetActive(true);
    }

    void BlockMountainArea()
    {
        mountainAreaTrigger.isTrigger = false;
        mountainAreaTrigger.GetComponent<NavMeshObstacle>().enabled = true;
        fogWalls[1].SetActive(true);
    }

    void BlockIceArea()
    {
        iceAreaTrigger.isTrigger = false;
        iceAreaTrigger.GetComponent<NavMeshObstacle>().enabled = true;
        fogWalls[2].SetActive(true);
    }
}
