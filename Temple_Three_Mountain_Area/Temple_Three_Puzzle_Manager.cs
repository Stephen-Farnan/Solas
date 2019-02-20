using System.Collections;
using UnityEngine;

public class Temple_Three_Puzzle_Manager : MonoBehaviour
{
    public Player_Interaction playInt;
    public CameraTransition[] camTrans;
    public Animator[] spinnerAnims;

    public bool puzzle_Two_Is_Solved = false;
    public bool puzzle_Three_Is_Solved = false;
    public bool puzzle_Four_Is_Solved = false;
    public bool puzzle_Five_Is_Solved = false;

    public Temple_Three_Puzzle Puzzle_Two_Key_Pipe;
    public Temple_Three_Puzzle Puzzle_Three_Key_Pipe;
    public Temple_Three_Puzzle Puzzle_Four_Key_Pipe;
    public Temple_Three_Puzzle Puzzle_Five_Key_Pipe_1;
    public Temple_Three_Puzzle Puzzle_Five_Key_Pipe_2;
    public Temple_Three_Puzzle Puzzle_Five_Key_Pipe_3;

    public AudioSource pipe_SFX;
    public AudioSource horn_SFX;
    private AudioSource audioSource;
    private GameObject sceneMan;

    public bool is_Final_Temple = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sceneMan = GameObject.FindWithTag("Scene_Manager");
    }

    public void Check_Puzzle_Two_is_Solved()
    {
        if (!puzzle_Two_Is_Solved)
        {
            if (Puzzle_Two_Key_Pipe.is_Powered)
            {
                puzzle_Two_Is_Solved = true;
                //do something
                //COLM
                StartCoroutine(PlayDoorAnimation(camTrans[0]));
                if (!is_Final_Temple)
                {
                    spinnerAnims[0].SetTrigger("Spin");
                }
                else
                {
                    horn_SFX.Play();
                }

            }
        }
    }

    public void Check_Puzzle_Three_is_Solved()
    {
        if (!puzzle_Three_Is_Solved)
        {
            if (Puzzle_Three_Key_Pipe.is_Powered)
            {
                puzzle_Three_Is_Solved = true;
                //do something
                if (puzzle_Four_Is_Solved)
                {
                    StartCoroutine(PlayDoorAnimation(camTrans[1]));
                }
                spinnerAnims[1].SetTrigger("Spin");
            }
        }
    }
    public void Check_Puzzle_Four_is_Solved()
    {
        if (!puzzle_Four_Is_Solved)
        {
            if (Puzzle_Four_Key_Pipe.is_Powered)
            {
                puzzle_Four_Is_Solved = true;
                //do something
                if (puzzle_Three_Is_Solved)
                {
                    StartCoroutine(PlayDoorAnimation(camTrans[1]));
                }
                spinnerAnims[2].SetTrigger("Spin");
            }
        }
    }

    public void Check_Puzzle_Five_is_Solved()
    {
        if (!puzzle_Five_Is_Solved)
        {
            if (Puzzle_Five_Key_Pipe_1.is_Powered && Puzzle_Five_Key_Pipe_2.is_Powered && Puzzle_Five_Key_Pipe_3.is_Powered)
            {
                puzzle_Five_Is_Solved = true;
                //do something
                StartCoroutine(PlayDoorAnimation(camTrans[2]));
                //spinnerAnims[3].SetTrigger("Spin");
                sceneMan.GetComponent<ProgressManager>().TempleCompleted(2);
            }
        }
    }

    IEnumerator PlayDoorAnimation(CameraTransition cam)
    {
        //Debug.Log(System.Array.IndexOf(camTrans, cam));

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
        if (System.Array.IndexOf(camTrans, cam) != camTrans.Length - 1)
        {
            audioSource.Play();
        }

        yield return new WaitForSeconds(1.0f);

        if (System.Array.IndexOf(camTrans, cam) == camTrans.Length - 1)
        {
            if (!is_Final_Temple)
            {
                StartCoroutine(GetComponent<Change_Scene_Trigger>().LoadNewScene());
            }

        }

        yield return new WaitForSeconds(2.0f);

        //door_Opening_Sound.Stop();
        audioSource.Stop();
        cam.MoveToOldPosition();

        yield return new WaitForSeconds(cam.smoothTime);

        cam.enabled = false;
        playInt.can_Interact = true;
    }


}
