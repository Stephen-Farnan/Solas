using System.Collections;
using UnityEngine;

public class Temple_Two_Puzzle_Two : MonoBehaviour
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

    public Transform first_Ring_Transform;
    public Transform second_Ring_Transform;
    public Transform third_Ring_Transform;

    public GameObject floor_Light_Left;
    public GameObject floor_Light_Right;
    public GameObject floor_Light_Central;

    public Animator doorLeftAnimator;
    public Animator doorRightAnimator;
    public Animator doorCentreAnimator;

    public Final_Temple_Rotation_Puzzle local_Final_Temple_Rotation_Puzzle;

    public bool is_Final_Room = false;
    public bool is_Solved = false;

    public Temple_Two_Puzzle_Three local_Temple_Two_Puzzle_Three;
    public Temple_Two_Puzzle_Four local_Temple_Two_Puzzle_Four;
    //public CameraTransition camTrans;

    public float rotation_Amount;
    public float destination_Rotation;

    public float rotation_Speed = 5f;
    // public bool fully_Rotated = false;

    public float rotation_Smoothing = 2f;
    public float current_Lerp_Time = 0;

    private Player_Interaction playInt;
    private int openDoor = 0;

    [Space]
    public ParticleSystem[] dustParticles;

    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playInt = GameObject.FindWithTag("Player").GetComponent<Player_Interaction>();
    }


    public void move_Clockwise(Ring_Direction ring_Dir, int ring_Number)
    {
        if (!is_Solved)
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
            }
        }

    }

    public void move_Anticlockwise(Ring_Direction ring_Dir, int ring_Number)
    {
        if (!is_Solved)
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
            }
        }

    }

    public IEnumerator Rotate_Ring(Transform ring_T, float dest_Rotation, bool direction_Is_Clockwise)
    {
        if (!is_Solved)
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



        //check its in the right rotation, if not keep lerping towards it and loop again, if it is, then end the loop. DO not let the player interact until the rotating is complete


    }


    public void Check_Puzzle_Is_Solved()
    {


        if (First_Ring_Direction == Ring_Direction.SOUTH && Second_Ring_Direction == Ring_Direction.SOUTH && Third_Ring_Direction == Ring_Direction.SOUTH)
        {
            //open the right door and close the other doors
            if (!is_Final_Room)
            {
                StartCoroutine(PlayDoorAnimation(doorRightAnimator, "Open"));
                floor_Light_Left.SetActive(false);
                floor_Light_Right.SetActive(true);
                floor_Light_Central.SetActive(false);
                openDoor = 2;
            }

        }

        else if (First_Ring_Direction == Ring_Direction.EAST && Second_Ring_Direction == Ring_Direction.EAST && Third_Ring_Direction == Ring_Direction.EAST)
        {
            //open the central door and close the other doors
            //
            if (local_Temple_Two_Puzzle_Four.has_Been_Solved && local_Temple_Two_Puzzle_Three.has_Been_Solved)
            {
                StartCoroutine(PlayDoorAnimation(doorCentreAnimator, "Open"));

                openDoor = 3;
            }
            else
            {
                StartCoroutine(PlayDoorAnimation(doorCentreAnimator, "Shudder"));
            }
            if (!is_Final_Room)
            {
                floor_Light_Left.SetActive(false);
                floor_Light_Right.SetActive(false);
                floor_Light_Central.SetActive(true);
            }


        }

        else if (First_Ring_Direction == Ring_Direction.NORTH && Second_Ring_Direction == Ring_Direction.NORTH && Third_Ring_Direction == Ring_Direction.NORTH)
        {
            //open the left door to the left area and close the other doors
            if (!is_Final_Room)
            {
                StartCoroutine(PlayDoorAnimation(doorLeftAnimator, "Open"));
                floor_Light_Left.SetActive(true);
                floor_Light_Right.SetActive(false);
                floor_Light_Central.SetActive(false);
                openDoor = 1;
            }



        }

        else
        {
            if (!is_Final_Room)
            {
                floor_Light_Left.SetActive(false);
                floor_Light_Right.SetActive(false);
                floor_Light_Central.SetActive(false);

                if (openDoor == 1)
                {
                    doorLeftAnimator.SetTrigger("Close");
                }
                if (openDoor == 2)
                {
                    doorRightAnimator.SetTrigger("Close");
                }
                if (openDoor == 3)
                {
                    doorCentreAnimator.SetTrigger("Close");
                }

                openDoor = 0;
            }

        }

        if (is_Final_Room && !is_Solved)
        {
            if (First_Ring_Direction == Ring_Direction.NORTH && Second_Ring_Direction == Ring_Direction.SOUTH && Third_Ring_Direction == Ring_Direction.WEST)
            {
                local_Final_Temple_Rotation_Puzzle.Ring_Solved();
                is_Solved = true;
            }

        }
    }
    IEnumerator PlayDoorAnimation(Animator anim, string triggerParameter)
    {
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
