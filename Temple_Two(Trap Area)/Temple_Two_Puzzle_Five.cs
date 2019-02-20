using System.Collections;
using UnityEngine;

public class Temple_Two_Puzzle_Five : MonoBehaviour
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
    public Ring_Direction Fifth_Ring_Direction;

    public Transform first_Ring_Transform;
    public Transform second_Ring_Transform;
    public Transform third_Ring_Transform;
    public Transform fourth_Ring_Transform;
    public Transform fifth_Ring_Transform;

    public float rotation_Amount;
    public float destination_Rotation;

    public float rotation_Speed = 5f;

    public float rotation_Smoothing = 2f;
    public float current_Lerp_Time = 0;

    public bool has_Been_Solved;

    private Animator anim;
    [Space]
    public CameraTransition camTrans;

    public void Start()
    {
        anim = GameObject.FindWithTag("MainCamera").GetComponent<Animator>();
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

            case 5:
                Fifth_Ring_Direction = ring_Dir;
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

            case 5:
                Fifth_Ring_Direction = ring_Dir;
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








        //check its in the right rotation, if not keep lerping towards it and loop again, if it is, then end the loop. DO not let the player interact until the rotating is complete


    }


    public void Check_Puzzle_Is_Solved()
    {

        if (First_Ring_Direction == Ring_Direction.NORTH && Second_Ring_Direction == Ring_Direction.NORTH && Third_Ring_Direction == Ring_Direction.NORTH && Fourth_Ring_Direction == Ring_Direction.NORTH)
        {
            if (!has_Been_Solved)
            {
                //puzzle has been solved, run animations of the locks opening here and show the finished symbol
                StartCoroutine(PlayFinalAnimation());
            }
        }
    }

    IEnumerator PlayFinalAnimation()
    {
        camTrans.enabled = true;
        yield return new WaitForSeconds(1.2f);
        camTrans.MoveToNewPosition();
        yield return new WaitForSeconds(camTrans.smoothTime + 0.6f);
        anim.enabled = true;
        anim.SetTrigger("Temple_Trap_Finish");
        GameObject.FindWithTag("Scene_Manager").GetComponent<ProgressManager>().TempleCompleted(1);
    }

    /*
	void Update() {
		if (Input.GetKeyDown(KeyCode.M))
		{
			StartCoroutine(PlayFinalAnimation());
		}
	}
	*/
}
