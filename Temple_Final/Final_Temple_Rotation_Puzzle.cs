using System.Collections;
using UnityEngine;

public class Final_Temple_Rotation_Puzzle : MonoBehaviour
{

    public int rings_Solved = 0;

    bool is_Solved = false;

    public Player_Interaction playInt;
    public CameraTransition camTrans;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Ring_Solved()
    {
        if (!is_Solved)
        {
            rings_Solved++;
            if (rings_Solved >= 3)
            {
                is_Solved = true;
                //do door opeining animations and stuff here COLM
                StartCoroutine(PlayDoorAnimation(camTrans));
            }
        }
    }

    IEnumerator PlayDoorAnimation(CameraTransition cam)
    {
        Animator anim = cam.transform.parent.GetComponent<Animator>();
        cam.enabled = true;
        yield return new WaitForSeconds(2.0f);
        cam.MoveToNewPosition();
        yield return new WaitForSeconds(cam.smoothTime + 0.6f);
        anim.SetTrigger("Open");
        //door_Opening_Sound.Play();
        audioSource.Play();

        yield return new WaitForSeconds(3.0f);

        audioSource.Stop();
        cam.MoveToOldPosition();

        yield return new WaitForSeconds(cam.smoothTime);

        cam.enabled = false;
        playInt.can_Interact = true;

        //door_Opening_Sound.Stop();
    }
}
