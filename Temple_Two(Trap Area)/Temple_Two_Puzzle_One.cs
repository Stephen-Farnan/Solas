using System.Collections;
using UnityEngine;

public class Temple_Two_Puzzle_One : MonoBehaviour
{

    public enum Ring_Direction
    {
        WEST,
        NORTH,
        EAST,
        SOUTH
    }


    public Ring_Direction First_Ring_Direction;

    public Transform first_Ring_Transform;



    public float rotation_Amount;
    public float destination_Rotation;
    public float rotation_Smoothing = 2f;
    public float current_Lerp_Time = 0;

    private Player_Interaction playInt;

    public Temple_Two_Puzzle_One_Handle local_Temple_Two_Puzzle_One_Handle;
    public CameraTransition camTrans;

    public void Start()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            playInt = GameObject.FindWithTag("Player").GetComponent<Player_Interaction>();
        }
    }


    public void move_Clockwise(Ring_Direction ring_Dir)
    {
        if ((int)ring_Dir < 3)
        {
            ring_Dir++;
        }

        else
        {
            ring_Dir = Ring_Direction.WEST;
        }

        First_Ring_Direction = ring_Dir;

    }

    public void move_Anticlockwise(Ring_Direction ring_Dir)
    {

        if (ring_Dir > 0)
        {
            ring_Dir--;
        }

        else
        {
            ring_Dir = Ring_Direction.SOUTH;
        }

        First_Ring_Direction = ring_Dir;

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

        /*
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

            // float angle = Mathf.LerpAngle(ring_T.eulerAngles.x, dest_Rotation, t);
            // ring_T.eulerAngles = new Vector3(angle, 0f, 0f);

            ring_T.rotation = Quaternion.Lerp(temp_Rot.rotation, Quaternion.Euler(dest_Rotation, 0f, 0f), t);


			//Instead of checking the rotation here, I'm checking the Lerp time

			
            if (clockwise)
            {
 
                if (ring_T.eulerAngles.x >= dest_Rotation || ring_T.eulerAngles.x > 359.8f)
                //if(t >= 1)
                {
                    
                    fully_Rotated = true;

                    if (ring_T.eulerAngles.x > 359.8f)
                    {
                        ring_T.eulerAngles = new Vector3(0f, ring_T.eulerAngles.y, ring_T.eulerAngles.z);
                    }
                }
            }
            else
            {

                if (ring_T.eulerAngles.x <= temp_Num)
                {

                    fully_Rotated = true;
                }
            }
			

			if (current_Lerp_Time >= rotation_Smoothing)
			{
				fully_Rotated = true;
                if(ring_T.transform.eulerAngles.x < 0)
                {
                    ring_T.transform.eulerAngles = new Vector3(ring_T.transform.eulerAngles.x * -1, 0, 0);
                }

                if(ring_T.transform.eulerAngles.x > 178 && ring_T.transform.eulerAngles.x < 182)
                {
                    ring_T.transform.eulerAngles = new Vector3(180, 0, 0);
                }

                if(ring_T.transform.eulerAngles.x > 92 && ring_T.transform.eulerAngles.x < 88)
                {
                    ring_T.transform.eulerAngles = new Vector3(90, 0, 0);
                }

                if(ring_T.transform.eulerAngles.x < 2 && ring_T.transform.eulerAngles.x > -2)
                {
                    ring_T.transform.eulerAngles = new Vector3(0, 0, 0);
                }

                if(ring_T.transform.eulerAngles.x < 362 && ring_T.transform.eulerAngles.x > 358)
                {
                    ring_T.transform.eulerAngles = new Vector3(0, 0, 0);
                }

                if(ring_T.transform.eulerAngles.x > 268 && ring_T.transform.eulerAngles.x < 272)
                {
                    ring_T.transform.eulerAngles = new Vector3(270, 0, 0);
                }

            }

    */




        Check_Puzzle_Is_Solved();

        //check its in the right rotation, if not keep lerping towards it and loop again, if it is, then end the loop. DO not let the player interact until the rotating is complete
    }


    public void Check_Puzzle_Is_Solved()
    {

        if (First_Ring_Direction == Ring_Direction.NORTH)
        {
            //stop the door from moving anymore
            local_Temple_Two_Puzzle_One_Handle.deactivated = true;
            //StartCoroutine(PlayDoorAnimation());
        }


    }
    IEnumerator PlayDoorAnimation()
    {
        camTrans.enabled = true;
        yield return new WaitForSeconds(2.0f);
        camTrans.MoveToNewPosition();
        yield return new WaitForSeconds(camTrans.smoothTime + 0.6f);

        yield return new WaitForSeconds(1.2f);

        camTrans.MoveToOldPosition();

        yield return new WaitForSeconds(camTrans.smoothTime);

        camTrans.enabled = false;
        playInt.can_Interact = true;
    }

}
