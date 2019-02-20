using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class StartAnimation : MonoBehaviour
{

    public GameObject player;
    public CameraFollowOrbit cameraScript;
    //public bool playAnimation = true;
    public float animationLength;
    private ProgressManager progMan;

    void Start()
    {
        progMan = GameObject.FindWithTag("Scene_Manager").GetComponent<ProgressManager>();

        if (progMan.activateStandingStone)
        {
            StartCoroutine(PlayAnimation());
            progMan.activateStandingStone = false;
        }
    }

    public IEnumerator PlayAnimation()
    {
        player.GetComponent<NavMeshAgent>().enabled = false;
        player.GetComponent<ThirdPerson3D>().enabled = false;
        player.GetComponent<Rigidbody>().isKinematic = true;
        cameraScript.enabled = false;

        player.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Wake Up");

        yield return new WaitForSeconds(animationLength);

        player.GetComponent<NavMeshAgent>().enabled = true;
        player.GetComponent<ThirdPerson3D>().enabled = true;
        player.GetComponent<Rigidbody>().isKinematic = false;
        cameraScript.enabled = true;
    }
}
