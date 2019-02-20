using System.Collections;
using UnityEngine;

public class Ice_Block_Puzzle_Manager : MonoBehaviour
{

    bool puzzle_One_Is_Solved = false;
    bool puzzle_Two_Is_Solved = false;
    bool puzzle_Three_Is_Solved = false;
    bool puzzle_Four_Is_Solved = false;
    bool puzzle_Five_Is_Solved = false;

    public CameraTransition[] camTrans;
    public Player_Interaction playInt;

    private AudioSource audioSource;

    GameObject sceneMan;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sceneMan = GameObject.FindWithTag("Scene_Manager");
    }

    public void Check_Puzzle_One_Is_Solved()
    {
        if (!puzzle_One_Is_Solved)
        {
            puzzle_One_Is_Solved = true;
            //open doors and such
            StartCoroutine(PlayDoorAnimation(camTrans[0]));

        }
    }

    public void Check_Puzzle_Two_Is_Solved()
    {
        if (!puzzle_Two_Is_Solved)
        {
            puzzle_Two_Is_Solved = true;
            //open doors and such
            StartCoroutine(PlayDoorAnimation(camTrans[0]));


        }
    }

    public void Check_Puzzle_Three_Is_Solved()
    {
        if (!puzzle_Three_Is_Solved)
        {
            puzzle_Three_Is_Solved = true;
            //open doors and such
            StartCoroutine(PlayDoorAnimation(camTrans[1]));


        }
    }

    public void Check_Puzzle_Four_Is_Solved()
    {
        if (!puzzle_Four_Is_Solved)
        {
            puzzle_Four_Is_Solved = true;
            //open doors and such
            StartCoroutine(PlayDoorAnimation(camTrans[2]));


        }
    }

    public void Check_Puzzle_Five_Is_Solved()
    {
        if (!puzzle_Five_Is_Solved)
        {
            puzzle_Five_Is_Solved = true;
            //open doors and such
            StartCoroutine(PlayDoorAnimation(camTrans[3]));
            sceneMan.GetComponent<ProgressManager>().TempleCompleted(3);


        }
    }

    public void Final_Temple_Puzzle_Solved()
    {
        puzzle_Five_Is_Solved = true;
        //open doors and such
        StartCoroutine(PlayDoorAnimation(camTrans[0]));


    }

    IEnumerator PlayDoorAnimation(CameraTransition cam)
    {
        Animator anim = null;
        if (cam.transform.parent.GetComponent<Animator>() != null)
        {
            anim = cam.transform.parent.GetComponent<Animator>();
        }
        cam.enabled = true;
        yield return new WaitForSeconds(2.0f);
        cam.MoveToNewPosition();
        yield return new WaitForSeconds(cam.smoothTime + 0.6f);
        if (anim != null)
        {
            anim.SetTrigger("Open");
        }
        //door_Opening_Sound.Play();
        audioSource.Play();

        if (cam == camTrans[camTrans.Length - 1])
        {
            StartCoroutine(GetComponent<Change_Scene_Trigger>().LoadNewScene());
        }

        yield return new WaitForSeconds(3.0f);

        audioSource.Stop();
        cam.MoveToOldPosition();

        yield return new WaitForSeconds(cam.smoothTime);

        cam.enabled = false;
        playInt.can_Interact = true;

        //door_Opening_Sound.Stop();
    }

}
