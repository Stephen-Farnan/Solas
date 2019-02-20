using UnityEngine;

public class StandingStoneAnimationHandler : MonoBehaviour
{

    public Animator[] stoneAnims;
    public Animator cameraAnim;
    public Animator doorAnim;

    private ProgressManager progMan;

    void Start()
    {
        progMan = GameObject.FindWithTag("Scene_Manager").GetComponent<ProgressManager>();

        int orbs;
        if (progMan.activateStandingStone)
        {
            orbs = progMan.noOfTemplesCompleted - 1;
        }
        else
        {
            orbs = progMan.noOfTemplesCompleted;
            if (orbs > 4)
            {
                orbs = 4;
            }
        }

        if (progMan.noOfTemplesCompleted == 4)
        {
            doorAnim.speed = 100;
            doorAnim.SetTrigger("Open");
        }

        for (int i = 0; i < orbs; i++)
        {
            stoneAnims[i].SetTrigger("Idle");
        }

        if (progMan.activateStandingStone)
        {
            if (progMan.noOfTemplesCompleted != 0)
            {
                GameObject.FindWithTag("MainCamera").SetActive(false);
                cameraAnim.GetComponent<Camera>().enabled = true;
                cameraAnim.GetComponent<AudioListener>().enabled = true;
                PlayCameraAnimation();
                //progMan.activateStandingStone = false;
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void PlayCameraAnimation()
    {
        cameraAnim.SetTrigger((progMan.noOfTemplesCompleted - 1).ToString());
        if (progMan.noOfTemplesCompleted == 4)
        {
            cameraAnim.SetTrigger("Final");
        }
    }

    void PlayStoneAnimation()
    {
        stoneAnims[progMan.noOfTemplesCompleted - 1].SetTrigger("Orb");
    }

    void PlayDoorAnimation()
    {
        doorAnim.SetTrigger("Open");
    }
}
