using System.Collections;
using UnityEngine;

public class Ice_Temple_Block_Script : MonoBehaviour
{

    [HideInInspector]
    public Ice_Temple_Puzzle_One puzzleOne;
    [HideInInspector]
    public Ice_Temple_Puzzle_Two puzzleTwo;
    [HideInInspector]
    public Ice_Temple_Puzzle_Three puzzleThree;
    [HideInInspector]
    public Ice_Temple_Puzzle_Four puzzleFour;
    [HideInInspector]
    public Ice_Temple_Puzzle_Five puzzleFive;

    public AudioSource solas_Grunt;

    void Start()
    {

    }

    void Update()
    {

    }

    public void PushBlock(string direction)
    {

        //Puzzle One needs to be coded, then this can be uncommented


        if (puzzleOne != null)
        {
            switch (direction)
            {
                case "North":
                    puzzleOne.Move_South(puzzleOne.local_Current_Tile_Number);
                    break;
                case "West":
                    puzzleOne.Move_East(puzzleOne.local_Current_Tile_Number);
                    break;
                case "South":
                    puzzleOne.Move_North(puzzleOne.local_Current_Tile_Number);
                    break;
                case "East":
                    puzzleOne.Move_West(puzzleOne.local_Current_Tile_Number);
                    break;
                default:
                    break;
            }
        }

        if (puzzleTwo != null)
        {
            switch (direction)
            {
                case "North":
                    puzzleTwo.Move_South(puzzleTwo.local_Current_Tile_Number);
                    break;
                case "West":
                    puzzleTwo.Move_East(puzzleTwo.local_Current_Tile_Number);
                    break;
                case "South":
                    puzzleTwo.Move_North(puzzleTwo.local_Current_Tile_Number);
                    break;
                case "East":
                    puzzleTwo.Move_West(puzzleTwo.local_Current_Tile_Number);
                    break;
                default:
                    break;
            }
        }
        if (puzzleThree != null)
        {
            switch (direction)
            {
                case "North":
                    puzzleThree.Move_South(puzzleThree.local_Current_Tile_Number);
                    break;
                case "West":
                    puzzleThree.Move_East(puzzleThree.local_Current_Tile_Number);
                    break;
                case "South":
                    puzzleThree.Move_North(puzzleThree.local_Current_Tile_Number);
                    break;
                case "East":
                    puzzleThree.Move_West(puzzleThree.local_Current_Tile_Number);
                    break;
                default:
                    break;
            }
        }
        if (puzzleFour != null)
        {
            switch (direction)
            {
                case "North":
                    puzzleFour.Move_South(puzzleFour.local_Current_Tile_Number);
                    break;
                case "West":
                    puzzleFour.Move_East(puzzleFour.local_Current_Tile_Number);
                    break;
                case "South":
                    puzzleFour.Move_North(puzzleFour.local_Current_Tile_Number);
                    break;
                case "East":
                    puzzleFour.Move_West(puzzleFour.local_Current_Tile_Number);
                    break;
                default:
                    break;
            }
        }
        if (puzzleFive != null)
        {
            switch (direction)
            {
                case "North":
                    puzzleFive.Move_South(puzzleFive.local_Current_Tile_Number);
                    break;
                case "West":
                    puzzleFive.Move_East(puzzleFive.local_Current_Tile_Number);
                    break;
                case "South":
                    puzzleFive.Move_North(puzzleFive.local_Current_Tile_Number);
                    break;
                case "East":
                    puzzleFive.Move_West(puzzleFive.local_Current_Tile_Number);
                    break;
                default:
                    break;
            }
        }

        StartCoroutine("Solas_Grunt");
        //
    }

    IEnumerator Solas_Grunt()
    {
        yield return new WaitForSeconds(0.0001f);
        solas_Grunt.Play();
    }
}
