using System.Collections;
using UnityEngine;

public class Temple_Three_Puzzle : MonoBehaviour
{

    public enum Shape
    {
        STRAIGHT,
        BEND,
        CROSS,
        TJUNCTION,
    }



    public Shape local_Shape;



    public enum Facing_Direction
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }

    public enum Puzzle_Number
    {
        TWO,
        THREE,
        FOUR,
        FIVE
    }

    public Puzzle_Number local_Puzzle_Number;

    public GameObject north_Wind_Trail;
    public GameObject south_Wind_Trail;
    public GameObject east_Wind_Trail;
    public GameObject west_Wind_Trail;

    public bool self_North_Connection_Is_Available;
    public bool self_East_Connection_Is_Available;
    public bool self_South_Connection_Is_Available;
    public bool self_West_Connection_Is_Available;

    public bool incoming_Power_From_North_Side;
    public bool incoming_Power_From_East_Side;
    public bool incoming_Power_From_South_Side;
    public bool incoming_Power_From_West_Side;

    public bool powered_By_North_Side;
    public bool powered_By_East_Side;
    public bool powered_By_South_Side;
    public bool powered_By_West_Side;

    public bool is_Powered;

    public bool is_On_Back_Wall = false;



    //unity collab

    public Facing_Direction local_Facing_Direction;
    Temple_Three_Puzzle_Manager local_Temple_Three_Puzzle_Manager;

    public Temple_Three_Puzzle north_Temple_Three_Puzzle;
    public Temple_Three_Puzzle east_Temple_Three_Puzzle;
    public Temple_Three_Puzzle south_Temple_Three_Puzzle;
    public Temple_Three_Puzzle west_Temple_Three_Puzzle;

    public float current_Lerp_Time;
    public float rotation_Smoothing = 0.4f;
    public float destination_Rotation;
    public Transform pipe_To_Be_Moved;
    public float rotation_Amount = 90f;
    // public float turn_Speed = .01f;

    public bool can_Be_Powered_By_East_Side = true;
    public bool can_Be_Powered_By_West_Side = true;
    public bool can_Be_Powered_By_North_Side = true;
    public bool can_Be_Powered_By_South_Side = true;


    //change in inputs from adjacent pipes
    public void Power_Input_Removed_From_North()
    {
        incoming_Power_From_North_Side = false;
        if (is_Powered)
        {
            Update_System();
        }

    }


    public void Power_Input_Removed_From_East()
    {
        incoming_Power_From_East_Side = false;
        if (is_Powered)
        {
            Update_System();
        }
    }

    public void Power_Input_Removed_From_South()
    {
        incoming_Power_From_South_Side = false;
        if (is_Powered)
        {
            Update_System();
        }
    }

    public void Power_Input_Removed_From_West()
    {
        incoming_Power_From_West_Side = false;
        if (is_Powered)
        {
            Update_System();
        }
    }

    public void Power_Input_Added_From_North()
    {
        if (can_Be_Powered_By_North_Side)
        {
            incoming_Power_From_North_Side = true;
        }

        if (!is_Powered)
        {
            Update_System();
        }

    }

    public void Power_Input_Added_From_East()
    {
        if (can_Be_Powered_By_East_Side)
        {
            incoming_Power_From_East_Side = true;
        }

        if (!is_Powered)
        {
            Update_System();
        }
    }

    public void Power_Input_Added_From_South()
    {
        if (can_Be_Powered_By_South_Side)
        {
            incoming_Power_From_South_Side = true;
        }

        if (!is_Powered)
        {
            Update_System();
        }
    }

    public void Power_Input_Added_From_West()
    {
        if (can_Be_Powered_By_West_Side)
        {
            incoming_Power_From_West_Side = true;
        }

        if (!is_Powered)
        {
            Update_System();
        }

    }

    //change in outputs from this pipe
    public void Power_Output_Removed_From_North()
    {

        if (north_Temple_Three_Puzzle != null)
        {
            north_Temple_Three_Puzzle.Power_Input_Removed_From_South();
        }

    }

    public void Power_Output_Removed_From_East()
    {

        if (east_Temple_Three_Puzzle != null)
        {
            east_Temple_Three_Puzzle.Power_Input_Removed_From_West();
        }

    }

    public void Power_Output_Removed_From_South()
    {

        if (south_Temple_Three_Puzzle != null)
        {
            south_Temple_Three_Puzzle.Power_Input_Removed_From_North();

        }

    }

    public void Power_Output_Removed_From_West()
    {

        if (west_Temple_Three_Puzzle != null)
        {
            west_Temple_Three_Puzzle.Power_Input_Removed_From_East();
        }

    }

    public void Power_Output_Added_From_North()
    {

        if (north_Temple_Three_Puzzle != null)
        {
            north_Temple_Three_Puzzle.Power_Input_Added_From_South();
        }

    }

    public void Power_Output_Added_From_East()
    {

        if (east_Temple_Three_Puzzle != null)
        {
            east_Temple_Three_Puzzle.Power_Input_Added_From_West();
        }

    }

    public void Power_Output_Added_From_South()
    {

        if (south_Temple_Three_Puzzle != null)
        {
            south_Temple_Three_Puzzle.Power_Input_Added_From_North();
        }

    }

    public void Power_Output_Added_From_West()
    {

        if (west_Temple_Three_Puzzle != null)
        {
            west_Temple_Three_Puzzle.Power_Input_Added_From_East();
        }

    }

    public void Check_If_Powered()
    {


        //checks open connections with power sources
        if (self_North_Connection_Is_Available && incoming_Power_From_North_Side && can_Be_Powered_By_North_Side)
        {
            powered_By_North_Side = true;
        }
        else
        {
            powered_By_North_Side = false;
        }

        if (self_East_Connection_Is_Available && incoming_Power_From_East_Side && can_Be_Powered_By_East_Side)
        {
            powered_By_East_Side = true;
        }
        else
        {
            powered_By_East_Side = false;
        }

        if (self_South_Connection_Is_Available && incoming_Power_From_South_Side && can_Be_Powered_By_South_Side)
        {
            powered_By_South_Side = true;
        }
        else
        {
            powered_By_South_Side = false;
        }

        if (self_West_Connection_Is_Available && incoming_Power_From_West_Side && can_Be_Powered_By_West_Side)
        {
            powered_By_West_Side = true;
        }
        else
        {
            powered_By_West_Side = false;
        }

        //sets the overall pipe to ON if any connections are valid
        if (powered_By_North_Side || powered_By_East_Side || powered_By_South_Side || powered_By_West_Side)
        {
            is_Powered = true;
            if (self_East_Connection_Is_Available && !powered_By_East_Side)
            {
                can_Be_Powered_By_East_Side = false;
                Power_Output_Added_From_East();
            }

            else if (east_Temple_Three_Puzzle != null)
            {
                if (!self_East_Connection_Is_Available && east_Temple_Three_Puzzle.incoming_Power_From_West_Side)
                {
                    Power_Output_Removed_From_East();
                }

            }

            if (self_North_Connection_Is_Available && !powered_By_North_Side)
            {
                can_Be_Powered_By_North_Side = false;
                Power_Output_Added_From_North();

            }

            else if (north_Temple_Three_Puzzle != null)
            {
                if (!self_North_Connection_Is_Available && north_Temple_Three_Puzzle.incoming_Power_From_South_Side)
                {
                    Power_Output_Removed_From_North();
                }

            }

            if (self_South_Connection_Is_Available && !powered_By_South_Side)
            {
                can_Be_Powered_By_South_Side = false;
                Power_Output_Added_From_South();

            }

            else if (south_Temple_Three_Puzzle != null)
            {
                if (!self_South_Connection_Is_Available && south_Temple_Three_Puzzle.incoming_Power_From_North_Side)
                {
                    Power_Output_Removed_From_South();
                }

            }

            if (self_West_Connection_Is_Available && !powered_By_West_Side)
            {
                can_Be_Powered_By_West_Side = false;
                Power_Output_Added_From_West();

            }

            else if (west_Temple_Three_Puzzle != null)
            {
                if (self_West_Connection_Is_Available && west_Temple_Three_Puzzle.incoming_Power_From_East_Side)
                {
                    Power_Output_Removed_From_West();
                }

            }

            //turn on the powered wind trails at the end of the pipes here
            if (north_Wind_Trail != null)
            {
                if (self_East_Connection_Is_Available)
                {
                    west_Wind_Trail.SetActive(true);
                }
                else
                {
                    west_Wind_Trail.SetActive(false);
                }

                if (self_North_Connection_Is_Available)
                {
                    north_Wind_Trail.SetActive(true);
                }
                else
                {
                    north_Wind_Trail.SetActive(false);
                }

                if (self_South_Connection_Is_Available)
                {
                    south_Wind_Trail.SetActive(true);
                }
                else
                {
                    south_Wind_Trail.SetActive(false);
                }

                if (self_West_Connection_Is_Available)
                {

                    east_Wind_Trail.SetActive(true);
                }
                else
                {
                    east_Wind_Trail.SetActive(false);
                }
            }


        }

        else
        {
            if (is_Powered)
            {
                is_Powered = false;

                Power_Output_Removed_From_South();
                Power_Output_Removed_From_East();
                Power_Output_Removed_From_North();
                Power_Output_Removed_From_West();
                //  can_Be_Powered_By_South_Side = true;
                //can_Be_Powered_By_North_Side = true;
                //can_Be_Powered_By_East_Side = true;
                //can_Be_Powered_By_West_Side = true;
                StartCoroutine("Reset_Blockages");
                //turn off the wind trails at the end of the pipes here
                if (north_Wind_Trail != null)
                {
                    north_Wind_Trail.SetActive(false);
                    south_Wind_Trail.SetActive(false);
                    east_Wind_Trail.SetActive(false);
                    west_Wind_Trail.SetActive(false);
                }


            }


        }

    }

    IEnumerator Reset_Blockages()
    {
        yield return new WaitForSeconds(.3f);
        can_Be_Powered_By_South_Side = true;
        can_Be_Powered_By_North_Side = true;
        can_Be_Powered_By_East_Side = true;
        can_Be_Powered_By_West_Side = true;
        /*
                if (south_Temple_Three_Puzzle_Two.powered_By_North_Side)
                {
                    can_Be_Powered_By_South_Side = false;
                }

                if (north_Temple_Three_Puzzle_Two.powered_By_North_Side)
                {
                    can_Be_Powered_By_North_Side = false;
                }

                if (east_Temple_Three_Puzzle_Two.powered_By_North_Side)
                {
                    can_Be_Powered_By_South_Side = false;
                }

                if (west_Temple_Three_Puzzle_Two.powered_By_North_Side)
                {
                    can_Be_Powered_By_South_Side = false;
                }
                */
    }

    private void Start()
    {
        local_Temple_Three_Puzzle_Manager = GameObject.Find("Puzzle_Manager").GetComponent<Temple_Three_Puzzle_Manager>();

        //set the directions that are able to receive power based on the shape
        Update_Pipe_Status();
        Check_If_Powered();

    }

    public void Update_Pipe_Status()
    {
        switch (local_Facing_Direction)
        {
            case Facing_Direction.EAST:
                switch (local_Shape)
                {
                    case Shape.STRAIGHT:
                        self_North_Connection_Is_Available = true;
                        self_East_Connection_Is_Available = false;
                        self_South_Connection_Is_Available = true;
                        self_West_Connection_Is_Available = false;

                        if (is_On_Back_Wall)
                        {
                            self_North_Connection_Is_Available = false;
                            self_East_Connection_Is_Available = true;
                            self_South_Connection_Is_Available = false;
                            self_West_Connection_Is_Available = true;
                        }
                        break;

                    case Shape.BEND:
                        self_North_Connection_Is_Available = true;
                        self_East_Connection_Is_Available = false;
                        self_South_Connection_Is_Available = false;
                        self_West_Connection_Is_Available = true;

                        if (is_On_Back_Wall)
                        {
                            self_North_Connection_Is_Available = false;
                            self_East_Connection_Is_Available = true;
                            self_South_Connection_Is_Available = true;
                            self_West_Connection_Is_Available = false;
                        }
                        break;



                    case Shape.CROSS:
                        self_North_Connection_Is_Available = true;
                        self_East_Connection_Is_Available = true;
                        self_South_Connection_Is_Available = true;
                        self_West_Connection_Is_Available = true;
                        break;

                    case Shape.TJUNCTION:
                        self_North_Connection_Is_Available = true;
                        self_East_Connection_Is_Available = true;
                        self_South_Connection_Is_Available = false;
                        self_West_Connection_Is_Available = true;

                        if (is_On_Back_Wall)
                        {
                            self_North_Connection_Is_Available = true;
                            self_East_Connection_Is_Available = true;
                            self_South_Connection_Is_Available = true;
                            self_West_Connection_Is_Available = false;
                        }
                        break;
                }
                break;

            case Facing_Direction.NORTH:
                switch (local_Shape)
                {
                    case Shape.STRAIGHT:
                        self_North_Connection_Is_Available = false;
                        self_East_Connection_Is_Available = true;
                        self_South_Connection_Is_Available = false;
                        self_West_Connection_Is_Available = true;

                        if (is_On_Back_Wall)
                        {
                            self_North_Connection_Is_Available = true;
                            self_East_Connection_Is_Available = false;
                            self_South_Connection_Is_Available = true;
                            self_West_Connection_Is_Available = false;
                        }
                        break;

                    case Shape.BEND:
                        self_North_Connection_Is_Available = true;
                        self_East_Connection_Is_Available = true;
                        self_South_Connection_Is_Available = false;
                        self_West_Connection_Is_Available = false;

                        if (is_On_Back_Wall)
                        {
                            self_North_Connection_Is_Available = false;
                            self_East_Connection_Is_Available = false;
                            self_South_Connection_Is_Available = true;
                            self_West_Connection_Is_Available = true;
                        }
                        break;

                    case Shape.CROSS:
                        self_North_Connection_Is_Available = true;
                        self_East_Connection_Is_Available = true;
                        self_South_Connection_Is_Available = true;
                        self_West_Connection_Is_Available = true;
                        break;

                    case Shape.TJUNCTION:
                        self_North_Connection_Is_Available = true;
                        self_East_Connection_Is_Available = true;
                        self_South_Connection_Is_Available = true;
                        self_West_Connection_Is_Available = false;

                        if (is_On_Back_Wall)
                        {
                            self_North_Connection_Is_Available = false;
                            self_East_Connection_Is_Available = true;
                            self_South_Connection_Is_Available = true;
                            self_West_Connection_Is_Available = true;
                        }
                        break;
                }
                break;

            case Facing_Direction.WEST:
                switch (local_Shape)
                {
                    case Shape.STRAIGHT:
                        self_North_Connection_Is_Available = true;
                        self_East_Connection_Is_Available = false;
                        self_South_Connection_Is_Available = true;
                        self_West_Connection_Is_Available = false;

                        if (is_On_Back_Wall)
                        {
                            self_North_Connection_Is_Available = false;
                            self_East_Connection_Is_Available = true;
                            self_South_Connection_Is_Available = false;
                            self_West_Connection_Is_Available = true;
                        }

                        break;

                    case Shape.BEND:
                        self_North_Connection_Is_Available = false;
                        self_East_Connection_Is_Available = true;
                        self_South_Connection_Is_Available = true;
                        self_West_Connection_Is_Available = false;

                        if (is_On_Back_Wall)
                        {
                            self_North_Connection_Is_Available = true;
                            self_East_Connection_Is_Available = false;
                            self_South_Connection_Is_Available = false;
                            self_West_Connection_Is_Available = true;
                        }
                        break;

                    case Shape.CROSS:
                        self_North_Connection_Is_Available = true;
                        self_East_Connection_Is_Available = true;
                        self_South_Connection_Is_Available = true;
                        self_West_Connection_Is_Available = true;
                        break;

                    case Shape.TJUNCTION:
                        self_North_Connection_Is_Available = false;
                        self_East_Connection_Is_Available = true;
                        self_South_Connection_Is_Available = true;
                        self_West_Connection_Is_Available = true;

                        if (is_On_Back_Wall)
                        {
                            self_North_Connection_Is_Available = true;
                            self_East_Connection_Is_Available = false;
                            self_South_Connection_Is_Available = true;
                            self_West_Connection_Is_Available = true;
                        }
                        break;
                }
                break;

            case Facing_Direction.SOUTH:
                switch (local_Shape)
                {
                    case Shape.STRAIGHT:
                        self_North_Connection_Is_Available = false;
                        self_East_Connection_Is_Available = true;
                        self_South_Connection_Is_Available = false;
                        self_West_Connection_Is_Available = true;

                        if (is_On_Back_Wall)
                        {
                            self_North_Connection_Is_Available = true;
                            self_East_Connection_Is_Available = false;
                            self_South_Connection_Is_Available = true;
                            self_West_Connection_Is_Available = false;
                        }
                        break;

                    case Shape.BEND:
                        self_North_Connection_Is_Available = false;
                        self_East_Connection_Is_Available = false;
                        self_South_Connection_Is_Available = true;
                        self_West_Connection_Is_Available = true;

                        if (is_On_Back_Wall)
                        {
                            self_North_Connection_Is_Available = true;
                            self_East_Connection_Is_Available = true;
                            self_South_Connection_Is_Available = false;
                            self_West_Connection_Is_Available = false;
                        }
                        break;

                    case Shape.CROSS:
                        self_North_Connection_Is_Available = true;
                        self_East_Connection_Is_Available = true;
                        self_South_Connection_Is_Available = true;
                        self_West_Connection_Is_Available = true;
                        break;

                    case Shape.TJUNCTION:
                        self_North_Connection_Is_Available = true;
                        self_East_Connection_Is_Available = false;
                        self_South_Connection_Is_Available = true;
                        self_West_Connection_Is_Available = true;

                        if (is_On_Back_Wall)
                        {
                            self_North_Connection_Is_Available = true;
                            self_East_Connection_Is_Available = true;
                            self_South_Connection_Is_Available = false;
                            self_West_Connection_Is_Available = true;
                        }
                        break;
                }
                break;
        }

    }

    public IEnumerator Rotate_Pipe(Transform ring_T, float dest_Rotation)
    {

        local_Temple_Three_Puzzle_Manager.pipe_SFX.Play();

        if (local_Facing_Direction != Facing_Direction.WEST)
        {
            local_Facing_Direction++;
        }
        else
        {
            local_Facing_Direction = Facing_Direction.NORTH;
        }


        bool fully_Rotated = false;
        float temp_Num;
        Transform temp_Rot = ring_T;
        current_Lerp_Time = 0f;
        temp_Num = dest_Rotation;
        if (temp_Num < 0)
        {
            temp_Num = 270f;
        }

        if (is_On_Back_Wall)
        {
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
        }

        else
        {
            while (!fully_Rotated)
            {

                current_Lerp_Time += Time.deltaTime;
                if (current_Lerp_Time > rotation_Smoothing)
                {
                    current_Lerp_Time = rotation_Smoothing;
                }

                float t = current_Lerp_Time / rotation_Smoothing;
                t = Mathf.Sin(t * Mathf.PI * 0.5f);


                ring_T.rotation = Quaternion.Lerp(temp_Rot.rotation, Quaternion.Euler(0f, 0f, dest_Rotation), t);

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
        }

        Update_Pipe_Status();
        Update_System();

    }

    public void Update_System()
    {

        Check_Adjacent_Pipes();
        Check_If_Powered();

        //put switch in here

        switch (local_Puzzle_Number)
        {
            case Puzzle_Number.TWO:
                if (local_Temple_Three_Puzzle_Manager != null)
                {
                    local_Temple_Three_Puzzle_Manager.Check_Puzzle_Two_is_Solved();
                }
                break;

            case Puzzle_Number.THREE:
                if (local_Temple_Three_Puzzle_Manager != null)
                {
                    local_Temple_Three_Puzzle_Manager.Check_Puzzle_Three_is_Solved();
                }
                break;

            case Puzzle_Number.FOUR:
                if (local_Temple_Three_Puzzle_Manager != null)
                {
                    local_Temple_Three_Puzzle_Manager.Check_Puzzle_Four_is_Solved();
                }
                break;

            case Puzzle_Number.FIVE:
                if (local_Temple_Three_Puzzle_Manager != null)
                {
                    local_Temple_Three_Puzzle_Manager.Check_Puzzle_Five_is_Solved();
                }
                break;
        }


    }


    public void Check_Adjacent_Pipes()
    {
        if (west_Temple_Three_Puzzle != null)
        {
            if (west_Temple_Three_Puzzle.is_Powered && west_Temple_Three_Puzzle.self_East_Connection_Is_Available)
            {
                incoming_Power_From_West_Side = true;
            }
            else
            {
                incoming_Power_From_West_Side = false;
            }
        }

        if (east_Temple_Three_Puzzle != null)
        {
            if (east_Temple_Three_Puzzle.is_Powered && east_Temple_Three_Puzzle.self_West_Connection_Is_Available)
            {
                incoming_Power_From_East_Side = true;
            }
            else
            {
                incoming_Power_From_East_Side = false;
            }
        }

        if (north_Temple_Three_Puzzle != null)
        {
            if (north_Temple_Three_Puzzle.is_Powered && north_Temple_Three_Puzzle.self_South_Connection_Is_Available)
            {
                incoming_Power_From_North_Side = true;
            }

            else
            {
                incoming_Power_From_North_Side = false;
            }
        }

        if (south_Temple_Three_Puzzle != null)
        {
            if (south_Temple_Three_Puzzle.is_Powered && south_Temple_Three_Puzzle.self_North_Connection_Is_Available)
            {
                incoming_Power_From_South_Side = true;
            }

            else
            {
                incoming_Power_From_South_Side = false;
            }
        }
    }




}
