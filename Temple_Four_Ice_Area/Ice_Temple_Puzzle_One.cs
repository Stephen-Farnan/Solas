using System.Collections;
using UnityEngine;

public class Ice_Temple_Puzzle_One : MonoBehaviour
{


    public Ice_Block_Puzzle_Manager local_Ice_Block_Puzzle_Manager;

    public Tile_Space local_Current_Tile_Number;

    public Tile_Space A1;
    public Tile_Space A2;
    public Tile_Space B1;
    public Tile_Space B2;

    public AudioSource ice_drag_SFX;


    public Tile_Space[] Column_1;
    public Tile_Space[] Column_2;

    public Tile_Space[] Row_A;
    public Tile_Space[] Row_B;


    public GameObject block_To_Move;

    public bool is_Moving = false;

    public float totalLerp = 2;

    public float speed = 1f;

    private void Start()
    {
        local_Current_Tile_Number = A1;
        block_To_Move.GetComponent<Ice_Temple_Block_Script>().puzzleOne = this;
    }

    GameObject Check_Tiles_North(int start_Point, int column)
    {

        Tile_Space[] temp_Array;

        switch (column)
        {
            case 0:
                temp_Array = Column_1;
                break;

            case 1:
                temp_Array = Column_2;
                break;



            default:
                temp_Array = Column_1;
                break;
        }
        GameObject target = null;
        bool found_Target = false;
        for (int i = start_Point + 1; i <= temp_Array.Length - 1; i++)
        {
            if (!temp_Array[i].available)
            {
                target = temp_Array[i - 1].gameObject;
                found_Target = true;
            }


            if ((found_Target))
            {

                break;
            }
        }

        if (!found_Target)
        {
            target = temp_Array[temp_Array.Length - 1].gameObject;
        }


        // return Column_1[Column_1.Length -1].gameObject;
        return target;
    }

    GameObject Check_Tiles_East(int start_Point, int row)
    {

        Tile_Space[] temp_Array;

        switch (row)
        {
            case 0:
                temp_Array = Row_A;
                break;

            case 1:
                temp_Array = Row_B;
                break;


            default:
                temp_Array = Row_A;
                break;
        }
        GameObject target = null;
        bool found_Target = false;
        for (int i = start_Point + 1; i <= temp_Array.Length - 1; i++)
        {
            if (!temp_Array[i].available)
            {
                target = temp_Array[i - 1].gameObject;
                found_Target = true;
            }


            if ((found_Target))
            {
                break;
            }
        }

        if (!found_Target)
        {
            target = temp_Array[temp_Array.Length - 1].gameObject;
        }


        // return Column_1[Column_1.Length -1].gameObject;
        return target;
    }

    GameObject Check_Tiles_South(int start_Point, int column)
    {

        Tile_Space[] temp_Array;

        switch (column)
        {
            case 0:
                temp_Array = Column_1;
                break;

            case 1:
                temp_Array = Column_2;
                break;

            default:
                temp_Array = Column_1;
                break;
        }



        GameObject target = null;
        bool found_Target = false;
        for (int i = start_Point - 1; i >= 0; i--)
        {
            if (!temp_Array[i].available)
            {
                target = temp_Array[i + 1].gameObject;
                found_Target = true;
            }


            if ((found_Target))
            {
                break;
            }
        }

        if (!found_Target)
        {
            target = temp_Array[0].gameObject;
        }


        // return Column_1[Column_1.Length -1].gameObject;
        return target;
    }

    GameObject Check_Tiles_West(int start_Point, int row)
    {

        Tile_Space[] temp_Array;

        switch (row)
        {
            case 0:
                temp_Array = Row_A;
                break;

            case 1:
                temp_Array = Row_B;
                break;

            default:
                temp_Array = Row_A;
                break;
        }



        GameObject target = null;
        bool found_Target = false;
        for (int i = start_Point - 1; i >= 0; i--)
        {
            if (!temp_Array[i].available)
            {
                target = temp_Array[i + 1].gameObject;
                found_Target = true;
            }


            if ((found_Target))
            {
                break;
            }
        }

        if (!found_Target)
        {
            target = temp_Array[0].gameObject;
        }


        // return Column_1[Column_1.Length -1].gameObject;
        return target;
    }

    public void Move_North(Tile_Space curr_Tile)
    {
        GameObject target = Check_Tiles_North((int)local_Current_Tile_Number.local_Row_Letter, (int)local_Current_Tile_Number.local_Colum_Number);

        local_Current_Tile_Number.available = true;
        StartCoroutine(Move_Block_To_Destination(block_To_Move, target));
        local_Current_Tile_Number = target.GetComponent<Tile_Space>();
        local_Current_Tile_Number.available = false;
        if (local_Current_Tile_Number.is_Puzzle_Goal)
        {
            Check_Is_Solved();
        }
    }

    public void Move_South(Tile_Space curr_Tile)
    {
        GameObject target = Check_Tiles_South((int)local_Current_Tile_Number.local_Row_Letter, (int)local_Current_Tile_Number.local_Colum_Number);

        local_Current_Tile_Number.available = true;
        StartCoroutine(Move_Block_To_Destination(block_To_Move, target));
        local_Current_Tile_Number = target.GetComponent<Tile_Space>();
        local_Current_Tile_Number.available = false;
        if (local_Current_Tile_Number.is_Puzzle_Goal)
        {
            Check_Is_Solved();
        }
    }

    public void Move_East(Tile_Space curr_Tile)
    {
        GameObject target = Check_Tiles_East((int)local_Current_Tile_Number.local_Colum_Number, (int)local_Current_Tile_Number.local_Row_Letter);

        local_Current_Tile_Number.available = true;
        StartCoroutine(Move_Block_To_Destination(block_To_Move, target));
        local_Current_Tile_Number = target.GetComponent<Tile_Space>();
        local_Current_Tile_Number.available = false;
        if (local_Current_Tile_Number.is_Puzzle_Goal)
        {
            Check_Is_Solved();
        }
    }

    public void Move_West(Tile_Space curr_Tile)
    {
        GameObject target = Check_Tiles_West((int)local_Current_Tile_Number.local_Colum_Number, (int)local_Current_Tile_Number.local_Row_Letter);

        local_Current_Tile_Number.available = true;
        StartCoroutine(Move_Block_To_Destination(block_To_Move, target));
        local_Current_Tile_Number = target.GetComponent<Tile_Space>();
        local_Current_Tile_Number.available = false;
        if (local_Current_Tile_Number.is_Puzzle_Goal)
        {
            Check_Is_Solved();
        }
    }


    IEnumerator Move_Block_To_Destination(GameObject origin, GameObject destination)
    {
        is_Moving = true;
        float distance_To_Cover = Vector3.Distance(origin.transform.position, destination.transform.position);
        float start_Time = Time.time;
        float dist_Covered_So_Far = 0;
        float dist_Covered_Per_Tick = 0;

        if (distance_To_Cover > .5f)
        {
            ice_drag_SFX.Play();
        }
        while (dist_Covered_So_Far < 1.6f)
        {
            if (dist_Covered_So_Far > distance_To_Cover)
            {
                dist_Covered_So_Far = distance_To_Cover;
            }

            dist_Covered_Per_Tick += speed;
            dist_Covered_So_Far = dist_Covered_Per_Tick / (distance_To_Cover / 3);
            origin.transform.position = Vector3.Lerp(origin.transform.position, destination.transform.position, dist_Covered_So_Far / 3);
            yield return new WaitForSeconds(.02f);
        }

        is_Moving = false;








    }

    void Check_Is_Solved()
    {
        local_Ice_Block_Puzzle_Manager.Check_Puzzle_One_Is_Solved();
    }
}
