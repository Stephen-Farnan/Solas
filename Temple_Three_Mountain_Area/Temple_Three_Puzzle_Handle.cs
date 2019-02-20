using System.Collections;
using UnityEngine;

public class Temple_Three_Puzzle_Handle : MonoBehaviour
{


    public Temple_Three_Puzzle local_Temple_Three_Puzzle;
    Temple_Three_Puzzle_Manager local_Temple_Three_Puzzle_Manager;
    Player_Interaction local_Player_Interaction;
    float rot_To_Add_On;
    bool puzzle_Is_Solved = false;

    public int box_NUmber = 0;

    private void Start()
    {
        local_Temple_Three_Puzzle_Manager = GameObject.Find("Puzzle_Manager").GetComponent<Temple_Three_Puzzle_Manager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log(other.gameObject);
            //some other change to make sure mine is the final version
        }
    }

    public IEnumerator Press_Pressure_Plate()
    {

        //StartCoroutine(GameObject.FindWithTag("Player").transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(playerAnimationSpot, "Pull Lever", true));
        gameObject.GetComponentInParent<Animator>().SetTrigger("Press");
        yield return new WaitForSeconds(.4f);
        Rotate_Pipes();
    }


    public void Rotate_Pipes()
    {
        switch (local_Temple_Three_Puzzle.local_Puzzle_Number)
        {
            case Temple_Three_Puzzle.Puzzle_Number.TWO:
                puzzle_Is_Solved = local_Temple_Three_Puzzle_Manager.puzzle_Two_Is_Solved;
                break;

            case Temple_Three_Puzzle.Puzzle_Number.THREE:
                puzzle_Is_Solved = local_Temple_Three_Puzzle_Manager.puzzle_Three_Is_Solved;
                break;

            case Temple_Three_Puzzle.Puzzle_Number.FOUR:
                puzzle_Is_Solved = local_Temple_Three_Puzzle_Manager.puzzle_Four_Is_Solved;
                break;

            case Temple_Three_Puzzle.Puzzle_Number.FIVE:
                puzzle_Is_Solved = local_Temple_Three_Puzzle_Manager.puzzle_Five_Is_Solved;
                break;
        }

        if (!puzzle_Is_Solved)
        {
            switch (local_Temple_Three_Puzzle.local_Facing_Direction)
            {
                case Temple_Three_Puzzle.Facing_Direction.NORTH:
                    rot_To_Add_On = 90f + (local_Temple_Three_Puzzle.rotation_Amount);
                    break;

                case Temple_Three_Puzzle.Facing_Direction.EAST:
                    rot_To_Add_On = 180f + (local_Temple_Three_Puzzle.rotation_Amount);
                    break;

                case Temple_Three_Puzzle.Facing_Direction.SOUTH:
                    rot_To_Add_On = 270f + (local_Temple_Three_Puzzle.rotation_Amount);
                    break;

                case Temple_Three_Puzzle.Facing_Direction.WEST:
                    rot_To_Add_On = 0f + (local_Temple_Three_Puzzle.rotation_Amount);
                    break;
            }
            local_Temple_Three_Puzzle.destination_Rotation = rot_To_Add_On;
            StartCoroutine(local_Temple_Three_Puzzle.Rotate_Pipe(local_Temple_Three_Puzzle.pipe_To_Be_Moved, local_Temple_Three_Puzzle.destination_Rotation));
        }


    }
}
