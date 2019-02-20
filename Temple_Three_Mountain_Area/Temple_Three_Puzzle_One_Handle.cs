using System.Collections;
using UnityEngine;

public class Temple_Three_Puzzle_One_Handle : MonoBehaviour
{


    public Temple_Three_Puzzle_One local_Temple_Three_Puzzle_One;

    float rot_To_Add_On;
    public AudioSource SFX;

    public IEnumerator Press_Pressure_Plate()
    {
        //StartCoroutine(GameObject.FindWithTag("Player").transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(playerAnimationSpot, "Pull Lever", true));
        yield return new WaitForSeconds(.4f);
        Rotate_Pipes();

    }
    //unity collab

    public void Rotate_Pipes()
    {
        if (!local_Temple_Three_Puzzle_One.puzzle_Is_Solved)
        {
            SFX.Play();
            switch (local_Temple_Three_Puzzle_One.local_Facing_Direction)
            {
                case Temple_Three_Puzzle_One.Facing_Direction.NORTH:
                    rot_To_Add_On = 90f + (local_Temple_Three_Puzzle_One.rotation_Amount);
                    break;

                case Temple_Three_Puzzle_One.Facing_Direction.EAST:
                    rot_To_Add_On = 180f + (local_Temple_Three_Puzzle_One.rotation_Amount);
                    break;

                case Temple_Three_Puzzle_One.Facing_Direction.SOUTH:
                    rot_To_Add_On = 270f + (local_Temple_Three_Puzzle_One.rotation_Amount);
                    break;

                case Temple_Three_Puzzle_One.Facing_Direction.WEST:
                    rot_To_Add_On = 0f + (local_Temple_Three_Puzzle_One.rotation_Amount);
                    break;
            }
            local_Temple_Three_Puzzle_One.destination_Rotation = rot_To_Add_On;
            StartCoroutine(local_Temple_Three_Puzzle_One.Rotate_Pipe(local_Temple_Three_Puzzle_One.pipe_To_Be_Moved, local_Temple_Three_Puzzle_One.destination_Rotation));
        }
    }


}
