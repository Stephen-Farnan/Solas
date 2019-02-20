using System.Collections;
using UnityEngine;

public class Temple_Two_Puzzle_Two_Handle : MonoBehaviour
{

    public bool affects_First_Ring;
    public bool affects_Second_Ring;
    public bool affects_Third_Ring;

    public Temple_Two_Puzzle_Two local_Temple_Two_Puzzle_Two;

    public enum Direction_To_Rotate
    {
        CLOCKWISE,
        ANTI_CLOCKWISE
    }

    public Direction_To_Rotate first_Ring_Direction;
    public Direction_To_Rotate second_Ring_Direction;
    public Direction_To_Rotate third_Ring_Direction;

    public AudioSource ring_rotation_SFX;
    public AudioSource solas_Grunt_SFX;

    int direction_Modifier = 1;
    bool clockwise;
    public Transform playerAnimationSpot;


    public IEnumerator PullLever()
    {
        StartCoroutine(GameObject.FindWithTag("Player").transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(playerAnimationSpot, "Pull Lever", true));
        yield return new WaitForSeconds(.7f);
        if (!local_Temple_Two_Puzzle_Two.is_Solved)
        {
            solas_Grunt_SFX.Play();
        }
        yield return new WaitForSeconds(1.1f);

        if (!local_Temple_Two_Puzzle_Two.is_Solved)
        {
            ring_rotation_SFX.Play();
        }
        yield return new WaitForSeconds(.2f);
        Rotate_Rings();

    }

    public void Rotate_Rings()
    {

        // local_Temple_Two_Puzzle_Two.fully_Rotated = false;
        if (affects_First_Ring)
        {
            switch (first_Ring_Direction)
            {
                case Direction_To_Rotate.CLOCKWISE:
                    local_Temple_Two_Puzzle_Two.move_Clockwise(local_Temple_Two_Puzzle_Two.First_Ring_Direction, 1);
                    direction_Modifier = 1;
                    clockwise = true;
                    break;

                case Direction_To_Rotate.ANTI_CLOCKWISE:
                    local_Temple_Two_Puzzle_Two.move_Anticlockwise(local_Temple_Two_Puzzle_Two.First_Ring_Direction, 1);
                    direction_Modifier = -1;
                    clockwise = false;
                    break;
            }

            local_Temple_Two_Puzzle_Two.destination_Rotation = local_Temple_Two_Puzzle_Two.first_Ring_Transform.eulerAngles.y + (local_Temple_Two_Puzzle_Two.rotation_Amount * direction_Modifier);



            StartCoroutine(local_Temple_Two_Puzzle_Two.Rotate_Ring(local_Temple_Two_Puzzle_Two.first_Ring_Transform, local_Temple_Two_Puzzle_Two.destination_Rotation, clockwise));

            ;
        }

        if (affects_Second_Ring)
        {
            switch (second_Ring_Direction)
            {
                case Direction_To_Rotate.CLOCKWISE:
                    local_Temple_Two_Puzzle_Two.move_Clockwise(local_Temple_Two_Puzzle_Two.Second_Ring_Direction, 2);
                    direction_Modifier = 1;
                    clockwise = true;
                    break;

                case Direction_To_Rotate.ANTI_CLOCKWISE:
                    local_Temple_Two_Puzzle_Two.move_Anticlockwise(local_Temple_Two_Puzzle_Two.Second_Ring_Direction, 2);
                    direction_Modifier = -1;
                    clockwise = false;
                    break;
            }
            local_Temple_Two_Puzzle_Two.destination_Rotation = local_Temple_Two_Puzzle_Two.second_Ring_Transform.eulerAngles.y + (local_Temple_Two_Puzzle_Two.rotation_Amount * direction_Modifier);

            StartCoroutine(local_Temple_Two_Puzzle_Two.Rotate_Ring(local_Temple_Two_Puzzle_Two.second_Ring_Transform, local_Temple_Two_Puzzle_Two.destination_Rotation, clockwise));
        }

        if (affects_Third_Ring)
        {
            switch (third_Ring_Direction)
            {
                case Direction_To_Rotate.CLOCKWISE:
                    local_Temple_Two_Puzzle_Two.move_Clockwise(local_Temple_Two_Puzzle_Two.Third_Ring_Direction, 3);
                    direction_Modifier = 1;
                    clockwise = true;
                    break;

                case Direction_To_Rotate.ANTI_CLOCKWISE:
                    local_Temple_Two_Puzzle_Two.move_Anticlockwise(local_Temple_Two_Puzzle_Two.Third_Ring_Direction, 3);
                    direction_Modifier = -1;
                    clockwise = false;
                    break;
            }
            local_Temple_Two_Puzzle_Two.destination_Rotation = local_Temple_Two_Puzzle_Two.third_Ring_Transform.eulerAngles.y + (local_Temple_Two_Puzzle_Two.rotation_Amount * direction_Modifier);

            StartCoroutine(local_Temple_Two_Puzzle_Two.Rotate_Ring(local_Temple_Two_Puzzle_Two.third_Ring_Transform, local_Temple_Two_Puzzle_Two.destination_Rotation, clockwise));
        }
    }
}
