using System.Collections;
using UnityEngine;

public class Temple_Three_Puzzle_One : MonoBehaviour
{
    public enum Facing_Direction
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }
    //unity collab
    public Facing_Direction local_Facing_Direction;

    public bool puzzle_Is_Solved = false;
    public float current_Lerp_Time;
    public float rotation_Smoothing = 0.4f;
    public float destination_Rotation;
    public Transform pipe_To_Be_Moved;
    public float rotation_Amount = 90f;
    public GameObject wind;
    // public float turn_Speed = .01f;
    public CameraTransition camTrans;
    public Animator anim;
    private AudioSource audioSource;
    private Player_Interaction playInt;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (GameObject.FindWithTag("Player") != null)
        {
            playInt = GameObject.FindWithTag("Player").GetComponent<Player_Interaction>();
        }
    }

    public void Check_Is_Puzzle_Solved()
    {
        switch (local_Facing_Direction)
        {
            case Facing_Direction.EAST:
                puzzle_Is_Solved = true;
                wind.SetActive(true);
                //turn on air effects at the fan and call the camera transition to show the opening of the door
                StartCoroutine(PlayDoorAnimation());
                anim.SetTrigger("Spin");
                break;

            case Facing_Direction.NORTH:
                break;

            case Facing_Direction.WEST:
                break;

            case Facing_Direction.SOUTH:

                break;
        }
    }

    public IEnumerator Rotate_Pipe(Transform ring_T, float dest_Rotation)
    {

        if (!puzzle_Is_Solved)
        {
            if (local_Facing_Direction != Facing_Direction.WEST)
            {
                local_Facing_Direction++;
            }
            else
            {
                local_Facing_Direction = Facing_Direction.NORTH;
            }
        }

        bool fully_Rotated = false;
        float temp_Num;
        Transform temp_Rot = ring_T;
        current_Lerp_Time = 0f;
        temp_Num = dest_Rotation;
        if (temp_Num < 0)
        {
            temp_Num = 270f;
        }


        while (!fully_Rotated)
        {

            current_Lerp_Time += Time.deltaTime;
            if (current_Lerp_Time > rotation_Smoothing)
            {
                current_Lerp_Time = rotation_Smoothing;
            }

            float t = current_Lerp_Time / rotation_Smoothing;
            t = Mathf.Sin(t * Mathf.PI * 0.5f);


            ring_T.rotation = Quaternion.Lerp(temp_Rot.rotation, Quaternion.Euler(dest_Rotation, 0f, 0f), t);

            if (current_Lerp_Time >= rotation_Smoothing)
            {
                fully_Rotated = true;
            }

            if (current_Lerp_Time >= rotation_Smoothing)
            {

                fully_Rotated = true;

            }

            yield return new WaitForSeconds(.02f);
        }

        Check_Is_Puzzle_Solved();
    }

    IEnumerator PlayDoorAnimation()
    {
        Animator anim = camTrans.transform.parent.GetComponent<Animator>();
        camTrans.enabled = true;
        yield return new WaitForSeconds(2.0f);
        camTrans.MoveToNewPosition();
        yield return new WaitForSeconds(camTrans.smoothTime + 0.6f);
        if (anim != null)
        {
            anim.SetTrigger("Open");
        }
        //door_Opening_Sound.Play();
        audioSource.Play();

        yield return new WaitForSeconds(3.0f);

        //door_Opening_Sound.Stop();
        audioSource.Stop();
        camTrans.MoveToOldPosition();

        yield return new WaitForSeconds(camTrans.smoothTime);

        camTrans.enabled = false;
        playInt.can_Interact = true;
    }
}
