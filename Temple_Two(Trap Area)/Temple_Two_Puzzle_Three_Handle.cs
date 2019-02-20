using System.Collections;
using UnityEngine;

public class Temple_Two_Puzzle_Three_Handle : MonoBehaviour
{

    public bool affects_First_Ring;
    public bool affects_Second_Ring;
    public bool affects_Third_Ring;
    public bool affects_Fourth_Ring;

    public Temple_Two_Puzzle_Three local_Temple_Two_Puzzle_Three;

    public enum Direction_To_Rotate
    {
        CLOCKWISE,
        ANTI_CLOCKWISE
    }

    public Direction_To_Rotate first_Ring_Direction;
    public Direction_To_Rotate second_Ring_Direction;
    public Direction_To_Rotate third_Ring_Direction;
    public Direction_To_Rotate fourth_Ring_Direction;

    int direction_Modifier = 1;
    bool clockwise;
    public Transform playerAnimationSpot;

    public AudioSource ring_rotation_SFX;
    public AudioSource solas_Grunt_SFX;


    public IEnumerator PullLever()
    {
        StartCoroutine(GameObject.FindWithTag("Player").transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(playerAnimationSpot, "Pull Lever", true));
        yield return new WaitForSeconds(1.8f);
        ring_rotation_SFX.Play();
        solas_Grunt_SFX.Play();
        yield return new WaitForSeconds(.2f);
        Rotate_Rings();
    }

    public void Rotate_Rings()
    {
        if (!local_Temple_Two_Puzzle_Three.has_Been_Solved)
        {
            // local_Temple_Two_Puzzle_Two.fully_Rotated = false;
            if (affects_First_Ring)
            {
                switch (first_Ring_Direction)
                {
                    case Direction_To_Rotate.CLOCKWISE:
                        local_Temple_Two_Puzzle_Three.move_Clockwise(local_Temple_Two_Puzzle_Three.First_Ring_Direction, 1);
                        direction_Modifier = 1;
                        clockwise = true;
                        break;

                    case Direction_To_Rotate.ANTI_CLOCKWISE:
                        local_Temple_Two_Puzzle_Three.move_Anticlockwise(local_Temple_Two_Puzzle_Three.First_Ring_Direction, 1);
                        direction_Modifier = -1;
                        clockwise = false;
                        break;
                }

                local_Temple_Two_Puzzle_Three.destination_Rotation = local_Temple_Two_Puzzle_Three.first_Ring_Transform.eulerAngles.y + (local_Temple_Two_Puzzle_Three.rotation_Amount * direction_Modifier);



                StartCoroutine(local_Temple_Two_Puzzle_Three.Rotate_Ring(local_Temple_Two_Puzzle_Three.first_Ring_Transform, local_Temple_Two_Puzzle_Three.destination_Rotation, clockwise));

                ;
            }

            if (affects_Second_Ring)
            {
                switch (second_Ring_Direction)
                {
                    case Direction_To_Rotate.CLOCKWISE:
                        local_Temple_Two_Puzzle_Three.move_Clockwise(local_Temple_Two_Puzzle_Three.Second_Ring_Direction, 2);
                        direction_Modifier = 1;
                        clockwise = true;
                        break;

                    case Direction_To_Rotate.ANTI_CLOCKWISE:
                        local_Temple_Two_Puzzle_Three.move_Anticlockwise(local_Temple_Two_Puzzle_Three.Second_Ring_Direction, 2);
                        direction_Modifier = -1;
                        clockwise = false;
                        break;
                }
                local_Temple_Two_Puzzle_Three.destination_Rotation = local_Temple_Two_Puzzle_Three.second_Ring_Transform.eulerAngles.y + (local_Temple_Two_Puzzle_Three.rotation_Amount * direction_Modifier);

                StartCoroutine(local_Temple_Two_Puzzle_Three.Rotate_Ring(local_Temple_Two_Puzzle_Three.second_Ring_Transform, local_Temple_Two_Puzzle_Three.destination_Rotation, clockwise));
            }

            if (affects_Third_Ring)
            {
                switch (third_Ring_Direction)
                {
                    case Direction_To_Rotate.CLOCKWISE:
                        local_Temple_Two_Puzzle_Three.move_Clockwise(local_Temple_Two_Puzzle_Three.Third_Ring_Direction, 3);
                        direction_Modifier = 1;
                        clockwise = true;
                        break;

                    case Direction_To_Rotate.ANTI_CLOCKWISE:
                        local_Temple_Two_Puzzle_Three.move_Anticlockwise(local_Temple_Two_Puzzle_Three.Third_Ring_Direction, 3);
                        direction_Modifier = -1;
                        clockwise = false;
                        break;
                }
                local_Temple_Two_Puzzle_Three.destination_Rotation = local_Temple_Two_Puzzle_Three.third_Ring_Transform.eulerAngles.y + (local_Temple_Two_Puzzle_Three.rotation_Amount * direction_Modifier);

                StartCoroutine(local_Temple_Two_Puzzle_Three.Rotate_Ring(local_Temple_Two_Puzzle_Three.third_Ring_Transform, local_Temple_Two_Puzzle_Three.destination_Rotation, clockwise));
            }

            if (affects_Fourth_Ring)
            {
                switch (fourth_Ring_Direction)
                {
                    case Direction_To_Rotate.CLOCKWISE:
                        local_Temple_Two_Puzzle_Three.move_Clockwise(local_Temple_Two_Puzzle_Three.Fourth_Ring_Direction, 4);
                        direction_Modifier = 1;
                        clockwise = true;
                        break;

                    case Direction_To_Rotate.ANTI_CLOCKWISE:
                        local_Temple_Two_Puzzle_Three.move_Anticlockwise(local_Temple_Two_Puzzle_Three.Fourth_Ring_Direction, 4);
                        direction_Modifier = -1;
                        clockwise = false;
                        break;
                }
                local_Temple_Two_Puzzle_Three.destination_Rotation = local_Temple_Two_Puzzle_Three.fourth_Ring_Transform.eulerAngles.y + (local_Temple_Two_Puzzle_Three.rotation_Amount * direction_Modifier);

                StartCoroutine(local_Temple_Two_Puzzle_Three.Rotate_Ring(local_Temple_Two_Puzzle_Three.fourth_Ring_Transform, local_Temple_Two_Puzzle_Three.destination_Rotation, clockwise));
            }
        }

    }
}
