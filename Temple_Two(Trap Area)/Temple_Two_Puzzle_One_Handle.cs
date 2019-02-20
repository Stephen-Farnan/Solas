using System.Collections;
using UnityEngine;

public class Temple_Two_Puzzle_One_Handle : MonoBehaviour
{

    public bool affects_First_Ring;
    float rot_To_Add_On;
    public Temple_Two_Puzzle_One local_Temple_Two_Puzzle_One;

    public enum Direction_To_Rotate
    {
        CLOCKWISE,
        ANTI_CLOCKWISE
    }

    public Direction_To_Rotate first_Ring_Direction;


    //   int direction_Modifier = 1;
    public Transform playerAnimationSpot;
    public bool deactivated = false;

    public AudioSource ring_rotation_SFX;
    public AudioSource solas_Grunt_SFX;


    public IEnumerator PullLever()
    {

        local_Temple_Two_Puzzle_One.Check_Puzzle_Is_Solved();
        if (!deactivated)
        {
            StartCoroutine(GameObject.FindWithTag("Player").transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(playerAnimationSpot, "Pull Lever", true));
            yield return new WaitForSeconds(1.8f);
            ring_rotation_SFX.Play();
            solas_Grunt_SFX.Play();
            yield return new WaitForSeconds(.2f);
            Rotate_Rings();
        }


    }

    public void Rotate_Rings()
    {

        // local_Temple_Two_Puzzle_Two.fully_Rotated = false;
        /* if (affects_First_Ring)
         {
             switch (first_Ring_Direction)
             {
                 case Direction_To_Rotate.CLOCKWISE:
                     local_Temple_Two_Puzzle_One.move_Clockwise(local_Temple_Two_Puzzle_One.First_Ring_Direction);
                     direction_Modifier = 1;
                     clockwise = true;
                     break;

                 case Direction_To_Rotate.ANTI_CLOCKWISE:
                     local_Temple_Two_Puzzle_One.move_Anticlockwise(local_Temple_Two_Puzzle_One.First_Ring_Direction);
                     direction_Modifier = -1;
                     clockwise = false;
                     break;
             }

             local_Temple_Two_Puzzle_One.destination_Rotation = local_Temple_Two_Puzzle_One.first_Ring_Transform.eulerAngles.x + (local_Temple_Two_Puzzle_One.rotation_Amount * direction_Modifier);



             StartCoroutine(local_Temple_Two_Puzzle_One.Rotate_Ring(local_Temple_Two_Puzzle_One.first_Ring_Transform, local_Temple_Two_Puzzle_One.destination_Rotation, clockwise));

             ;
         }
         */



        switch (local_Temple_Two_Puzzle_One.First_Ring_Direction)
        {
            case Temple_Two_Puzzle_One.Ring_Direction.NORTH:
                rot_To_Add_On = 90f + (local_Temple_Two_Puzzle_One.rotation_Amount);
                break;

            case Temple_Two_Puzzle_One.Ring_Direction.EAST:
                rot_To_Add_On = 180f + (local_Temple_Two_Puzzle_One.rotation_Amount);
                break;

            case Temple_Two_Puzzle_One.Ring_Direction.SOUTH:
                rot_To_Add_On = 270f + (local_Temple_Two_Puzzle_One.rotation_Amount);
                break;

            case Temple_Two_Puzzle_One.Ring_Direction.WEST:
                rot_To_Add_On = 0f + (local_Temple_Two_Puzzle_One.rotation_Amount);
                break;
        }

        local_Temple_Two_Puzzle_One.destination_Rotation = rot_To_Add_On;
        StartCoroutine(local_Temple_Two_Puzzle_One.Rotate_Ring(local_Temple_Two_Puzzle_One.first_Ring_Transform, local_Temple_Two_Puzzle_One.destination_Rotation, true));

        switch (first_Ring_Direction)
        {
            case Direction_To_Rotate.CLOCKWISE:
                local_Temple_Two_Puzzle_One.move_Clockwise(local_Temple_Two_Puzzle_One.First_Ring_Direction);
                // direction_Modifier = 1;
                break;

            case Direction_To_Rotate.ANTI_CLOCKWISE:
                local_Temple_Two_Puzzle_One.move_Anticlockwise(local_Temple_Two_Puzzle_One.First_Ring_Direction);
                //  direction_Modifier = -1;
                break;
        }





    }
}
