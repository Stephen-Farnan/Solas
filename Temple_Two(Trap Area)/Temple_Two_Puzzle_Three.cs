using System.Collections;
using UnityEngine;

public class Temple_Two_Puzzle_Three : MonoBehaviour
{

    public enum Ring_Direction
    {
        WEST,
        NORTH,
        EAST,
        SOUTH
    }


    public Ring_Direction First_Ring_Direction;
    public Ring_Direction Second_Ring_Direction;
    public Ring_Direction Third_Ring_Direction;
    public Ring_Direction Fourth_Ring_Direction;

    public Transform first_Ring_Transform;
    public Transform second_Ring_Transform;
    public Transform third_Ring_Transform;
    public Transform fourth_Ring_Transform;

    public float rotation_Amount;
    public float destination_Rotation;

    public float rotation_Speed = 5f;

    public float rotation_Smoothing = 2f;
    public float current_Lerp_Time = 0;

    private Player_Interaction playInt;
    public bool has_Been_Solved = false;

    public Animator anim;

    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playInt = GameObject.FindWithTag("Player").GetComponent<Player_Interaction>();
    }


    public void move_Clockwise(Ring_Direction ring_Dir, int ring_Number)
    {
        if ((int)ring_Dir < 3)
        {
            ring_Dir++;
        }

        else
        {
            ring_Dir = Ring_Direction.WEST;
        }

        switch (ring_Number)
        {
            case 1:
                First_Ring_Direction = ring_Dir;
                break;

            case 2:
                Second_Ring_Direction = ring_Dir;
                break;

            case 3:
                Third_Ring_Direction = ring_Dir;
                break;

            case 4:
                Fourth_Ring_Direction = ring_Dir;
                break;
        }

    }

    public void move_Anticlockwise(Ring_Direction ring_Dir, int ring_Number)
    {

        if (ring_Dir > 0)
        {
            ring_Dir--;
        }

        else
        {
            ring_Dir = Ring_Direction.SOUTH;
        }

        switch (ring_Number)
        {
            case 1:
                First_Ring_Direction = ring_Dir;
                break;

            case 2:
                Second_Ring_Direction = ring_Dir;
                break;

            case 3:
                Third_Ring_Direction = ring_Dir;
                break;

            case 4:
                Fourth_Ring_Direction = ring_Dir;
                break;
        }

    }

    public IEnumerator Rotate_Ring(Transform ring_T, float dest_Rotation, bool direction_Is_Clockwise)
    {




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


            ring_T.rotation = Quaternion.Lerp(temp_Rot.rotation, Quaternion.Euler(0f, dest_Rotation, 0f), t);

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
        Check_Puzzle_Is_Solved();




    }


    public void Check_Puzzle_Is_Solved()
    {
        if (First_Ring_Direction == Ring_Direction.WEST && Second_Ring_Direction == Ring_Direction.WEST && Third_Ring_Direction == Ring_Direction.WEST && Fourth_Ring_Direction == Ring_Direction.WEST)
        {
            if (!has_Been_Solved)
            {
                //puzzle has been solved, run animations of the locks opening here and show the finished symbol
                StartCoroutine(PlayDoorAnimation(anim, "Lock1"));
            }
        }

        if (First_Ring_Direction == Ring_Direction.EAST && Second_Ring_Direction == Ring_Direction.EAST && Third_Ring_Direction == Ring_Direction.EAST && Fourth_Ring_Direction == Ring_Direction.EAST)
        {
            if (!has_Been_Solved)
            {
                //puzzle has been solved, run animations of the locks opening here and show the finished symbol
                StartCoroutine(PlayDoorAnimation(anim, "Lock1"));
            }
        }

        if (First_Ring_Direction == Ring_Direction.SOUTH && Second_Ring_Direction == Ring_Direction.SOUTH && Third_Ring_Direction == Ring_Direction.SOUTH && Fourth_Ring_Direction == Ring_Direction.SOUTH)
        {
            if (!has_Been_Solved)
            {
                //puzzle has been solved, run animations of the locks opening here and show the finished symbol
                StartCoroutine(PlayDoorAnimation(anim, "Lock1"));
            }
        }

        if (First_Ring_Direction == Ring_Direction.NORTH && Second_Ring_Direction == Ring_Direction.NORTH && Third_Ring_Direction == Ring_Direction.NORTH && Fourth_Ring_Direction == Ring_Direction.NORTH)
        {
            if (!has_Been_Solved)
            {
                //puzzle has been solved, run animations of the locks opening here and show the finished symbol
                StartCoroutine(PlayDoorAnimation(anim, "Lock1"));
            }
        }
    }

    IEnumerator PlayDoorAnimation(Animator anim, string triggerParameter)
    {
        has_Been_Solved = true;
        CameraTransition camTrans = anim.transform.GetChild(0).GetComponent<CameraTransition>();
        camTrans.enabled = true;
        yield return new WaitForSeconds(1.2f);
        camTrans.MoveToNewPosition();
        yield return new WaitForSeconds(camTrans.smoothTime + 0.6f);
        anim.SetTrigger(triggerParameter);
        //door_Opening_Sound.Play();
        audioSource.Play();

        yield return new WaitForSeconds(3.0f);

        audioSource.Stop();
        camTrans.MoveToOldPosition();

        yield return new WaitForSeconds(camTrans.smoothTime);

        camTrans.enabled = false;
        playInt.can_Interact = true;

        //door_Opening_Sound.Stop();
    }
}
