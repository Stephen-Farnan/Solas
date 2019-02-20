using System.Collections;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    //References
    //Temple One
    public Final_Temple_Torch_Puzzle local_Final_Temple_Torch_Puzzle;
    public Temple_One_Puzzle_Two local_Temple_One_Puzzle_Two;
    public Temple_One_Puzzle_Three local_Temple_One_Puzzle_Three;

    public Temple_One_Torch_One local_Temple_One_Torch_One;
    public Temple_One_Torch_Two local_Temple_One_Torch_Two;

    public Temple_One_Torch_Three local_Temple_One_Torch_Three;
    public Temple_One_Torch_Four local_Temple_One_Torch_Four;
    public Temple_One_Torch_Five local_Temple_One_Torch_Five;
    public Temple_One_Torch_Six local_Temple_One_Torch_Six;

    public Temple_One_Torch_Seven local_Temple_One_Torch_Seven;
    public Temple_One_Torch_Eight local_Temple_One_Torch_Eight;
    public Temple_One_Torch_Nine local_Temple_One_Torch_Nine;
    public Temple_One_Torch_Ten local_Temple_One_Torch_Ten;

    //Temple Two Trap Area
    public Temple_Two_Puzzle_One_Handle first_Temple_Two_Puzzle_One_Handle;

    public Temple_Two_Puzzle_Two_Handle first_Temple_Two_Puzzle_Two_Handle;
    public Temple_Two_Puzzle_Two_Handle second_Temple_Two_Puzzle_Two_Handle;
    public Temple_Two_Puzzle_Two_Handle third_Temple_Two_Puzzle_Two_Handle;

    public Temple_Two_Puzzle_Three_Handle first_Temple_Two_Puzzle_Three_Handle;
    public Temple_Two_Puzzle_Three_Handle second_Temple_Two_Puzzle_Three_Handle;
    public Temple_Two_Puzzle_Three_Handle third_Temple_Two_Puzzle_Three_Handle;
    public Temple_Two_Puzzle_Three_Handle fourth_Temple_Two_Puzzle_Three_Handle;

    public Temple_Two_Puzzle_Four_Handle first_Temple_Two_Puzzle_Four_Handle;
    public Temple_Two_Puzzle_Four_Handle second_Temple_Two_Puzzle_Four_Handle;
    public Temple_Two_Puzzle_Four_Handle third_Temple_Two_Puzzle_Four_Handle;
    public Temple_Two_Puzzle_Four_Handle fourth_Temple_Two_Puzzle_Four_Handle;

    public Temple_Two_Puzzle_Five_Handle first_Temple_Two_Puzzle_Five_Handle;
    public Temple_Two_Puzzle_Five_Handle second_Temple_Two_Puzzle_Five_Handle;
    public Temple_Two_Puzzle_Five_Handle third_Temple_Two_Puzzle_Five_Handle;
    public Temple_Two_Puzzle_Five_Handle fourth_Temple_Two_Puzzle_Five_Handle;
    public Temple_Two_Puzzle_Five_Handle fifth_Temple_Two_Puzzle_Five_Handle;

    //Temple Three Mountain Area
    public Temple_Three_Puzzle_One_Handle first_Temple_Three_Puzzle_One_Handle;

    public Temple_Three_Puzzle_Handle first_Temple_Three_Puzzle_Two_Handle;
    public Temple_Three_Puzzle_Handle second_Temple_Three_Puzzle_Two_Handle;
    public Temple_Three_Puzzle_Handle third_Temple_Three_Puzzle_Two_Handle;
    public Temple_Three_Puzzle_Handle fourth_Temple_Three_Puzzle_Two_Handle;
    public Temple_Three_Puzzle_Handle fifth_Temple_Three_Puzzle_Two_Handle;

    public Temple_Three_Puzzle_Handle first_Temple_Three_Puzzle_Three_Handle;
    public Temple_Three_Puzzle_Handle second_Temple_Three_Puzzle_Three_Handle;
    public Temple_Three_Puzzle_Handle third_Temple_Three_Puzzle_Three_Handle;
    public Temple_Three_Puzzle_Handle fourth_Temple_Three_Puzzle_Three_Handle;
    public Temple_Three_Puzzle_Handle fifth_Temple_Three_Puzzle_Three_Handle;
    public Temple_Three_Puzzle_Handle sixth_Temple_Three_Puzzle_Three_Handle;
    public Temple_Three_Puzzle_Handle seventh_Temple_Three_Puzzle_Three_Handle;

    public Temple_Three_Puzzle_Handle first_Temple_Three_Puzzle_Four_Handle;
    public Temple_Three_Puzzle_Handle second_Temple_Three_Puzzle_Four_Handle;
    public Temple_Three_Puzzle_Handle third_Temple_Three_Puzzle_Four_Handle;
    public Temple_Three_Puzzle_Handle fourth_Temple_Three_Puzzle_Four_Handle;
    public Temple_Three_Puzzle_Handle fifth_Temple_Three_Puzzle_Four_Handle;
    public Temple_Three_Puzzle_Handle sixth_Temple_Three_Puzzle_Four_Handle;
    public Temple_Three_Puzzle_Handle seventh_Temple_Three_Puzzle_Four_Handle;

    public Temple_Three_Puzzle_Handle first_Temple_Three_Puzzle_Five_Handle;
    public Temple_Three_Puzzle_Handle second_Temple_Three_Puzzle_Five_Handle;
    public Temple_Three_Puzzle_Handle third_Temple_Three_Puzzle_Five_Handle;
    public Temple_Three_Puzzle_Handle fourth_Temple_Three_Puzzle_Five_Handle;
    public Temple_Three_Puzzle_Handle fifth_Temple_Three_Puzzle_Five_Handle;
    public Temple_Three_Puzzle_Handle sixth_Temple_Three_Puzzle_Five_Handle;
    public Temple_Three_Puzzle_Handle seventh_Temple_Three_Puzzle_Five_Handle;
    public Temple_Three_Puzzle_Handle eight_Temple_Three_Puzzle_Five_Handle;
    public Temple_Three_Puzzle_Handle ninth_Temple_Three_Puzzle_Five_Handle;
    public Temple_Three_Puzzle_Handle tenth_Temple_Three_Puzzle_Five_Handle;
    public Temple_Three_Puzzle_Handle eleventh_Temple_Three_Puzzle_Five_Handle;
    public Temple_Three_Puzzle_Handle twelfth_Temple_Three_Puzzle_Five_Handle;
    public Temple_Three_Puzzle_Handle thirteenth_Temple_Three_Puzzle_Five_Handle;
    public Temple_Three_Puzzle_Handle fourteenth_Temple_Three_Puzzle_Five_Handle;
    public Temple_Three_Puzzle_Handle fifteenth_Temple_Three_Puzzle_Five_Handle;
    public Temple_Three_Puzzle_Handle sixteenth_Temple_Three_Puzzle_Five_Handle;
    public Temple_Three_Puzzle_Handle seventeenth_Temple_Three_Puzzle_Five_Handle;

    public Temple_Three_Puzzle_Handle first_Final_Temple_Wind_Handle;
    public Temple_Three_Puzzle_Handle second_Final_Temple_Wind_Handle;
    public Temple_Three_Puzzle_Handle third_Final_Temple_Wind_Handle;
    public Temple_Three_Puzzle_Handle fourth_Final_Temple_Wind_Handle;
    public Temple_Three_Puzzle_Handle fifth_Final_Temple_Wind_Handle;
    public Temple_Three_Puzzle_Handle sixth_Final_Temple_Wind_Handle;
    public Temple_Three_Puzzle_Handle seventh_Final_Temple_Wind_Handle;
    public Temple_Three_Puzzle_Handle eight_Final_Temple_Wind_Handle;
    public Temple_Three_Puzzle_Handle ninth_Final_Temple_Wind_Handle;
    public Temple_Three_Puzzle_Handle tenth_Final_Temple_Wind_Handle;
    public Temple_Three_Puzzle_Handle eleventh_Final_Temple_Wind_Handle;
    public Temple_Three_Puzzle_Handle twelfth_Final_Temple_Wind_Handle;


    //Temple Four Ice Temple
    public Ice_Temple_Puzzle_Five local_Ice_Temple_Puzzle_Five;
    public Ice_Temple_Puzzle_Four local_Ice_Temple_Puzzle_Four;
    public Ice_Temple_Puzzle_Three local_Ice_Temple_Puzzle_Three;
    public Ice_Temple_Puzzle_Two local_Ice_Temple_Puzzle_Two;

    //Final Temple
    public Final_Temple_Torch_One final_Temple_Torch_One;
    public Final_Temple_Torch_Two final_Temple_Torch_Two;
    public Final_Temple_Torch_Three final_Temple_Torch_Three;
    public Final_Temple_Torch_Four final_Temple_Torch_Four;

    public Temple_Two_Puzzle_Two_Handle final_Rotation_Puzzle_Handle_1;
    public Temple_Two_Puzzle_Two_Handle final_Rotation_Puzzle_Handle_2;
    public Temple_Two_Puzzle_Two_Handle final_Rotation_Puzzle_Handle_3;
    public Temple_Two_Puzzle_Two_Handle final_Rotation_Puzzle_Handle_4;
    public Temple_Two_Puzzle_Two_Handle final_Rotation_Puzzle_Handle_5;
    public Temple_Two_Puzzle_Two_Handle final_Rotation_Puzzle_Handle_6;
    public Temple_Two_Puzzle_Two_Handle final_Rotation_Puzzle_Handle_7;
    public Temple_Two_Puzzle_Two_Handle final_Rotation_Puzzle_Handle_8;
    public Temple_Two_Puzzle_Two_Handle final_Rotation_Puzzle_Handle_9;

    //Cabin
    public Cabin_Exit local_Cabin_Exit;

    public CameraTransition local_CameraTransition;

    public float interaction_Cooldown = 3f;
    [HideInInspector]
    public bool can_Interact = true;
    public GlowObject temp_Glow_Object;
    public GameObject button_Prompt_Gameobject;

    [HideInInspector]
    public GameObject interactionGameObject;

    [HideInInspector]
    public bool can_Highlight = true;

    bool temp_Can_Animate = false;

    GameObject current_Campfire;
    GameObject current_Flower;

    ThirdPerson3D charController;

    void Start()
    {
        charController = GameObject.FindWithTag("Player").GetComponent<ThirdPerson3D>();
    }


    public enum Object_To_Interact_With
    {
        NONE,

        //General
        CAMPFIRE,
        FLOWER,

        //Cabin
        FIREPLACE,
        DOOR,
        BOOK,

        //In Temple One
        TEMPLE_ONE_RESET_ONE,
        TEMPLE_ONE_RESET_TWO,
        TEMPLE_ONE_TORCH_ONE,
        TEMPLE_ONE_TORCH_TWO,

        TEMPLE_ONE_TORCH_THREE,
        TEMPLE_ONE_TORCH_FOUR,
        TEMPLE_ONE_TORCH_FIVE,
        TEMPLE_ONE_TORCH_SIX,

        TEMPLE_ONE_TORCH_SEVEN,
        TEMPLE_ONE_TORCH_EIGHT,
        TEMPLE_ONE_TORCH_NINE,
        TEMPLE_ONE_TORCH_TEN,

        //In Temple Two Trap Area
        TEMPLE_TWO_PUZZLE_ONE_HANDLE_ONE,

        TEMPLE_TWO_PUZZLE_TWO_HANDLE_ONE,
        TEMPLE_TWO_PUZZLE_TWO_HANDLE_TWO,
        TEMPLE_TWO_PUZZLE_TWO_HANDLE_THREE,

        TEMPLE_TWO_PUZZLE_THREE_HANDLE_ONE,
        TEMPLE_TWO_PUZZLE_THREE_HANDLE_TWO,
        TEMPLE_TWO_PUZZLE_THREE_HANDLE_THREE,
        TEMPLE_TWO_PUZZLE_THREE_HANDLE_FOUR,

        TEMPLE_TWO_PUZZLE_FOUR_HANDLE_ONE,
        TEMPLE_TWO_PUZZLE_FOUR_HANDLE_TWO,
        TEMPLE_TWO_PUZZLE_FOUR_HANDLE_THREE,
        TEMPLE_TWO_PUZZLE_FOUR_HANDLE_FOUR,

        TEMPLE_TWO_PUZZLE_FIVE_HANDLE_ONE,
        TEMPLE_TWO_PUZZLE_FIVE_HANDLE_TWO,
        TEMPLE_TWO_PUZZLE_FIVE_HANDLE_THREE,
        TEMPLE_TWO_PUZZLE_FIVE_HANDLE_FOUR,
        TEMPLE_TWO_PUZZLE_FIVE_HANDLE_FIVE,


        //In Temple Three
        TEMPLE_THREE_PUZZLE_ONE_HANDLE_ONE,

        TEMPLE_THREE_PUZZLE_TWO_HANDLE_ONE,
        TEMPLE_THREE_PUZZLE_TWO_HANDLE_TWO,
        TEMPLE_THREE_PUZZLE_TWO_HANDLE_THREE,
        TEMPLE_THREE_PUZZLE_TWO_HANDLE_FOUR,
        TEMPLE_THREE_PUZZLE_TWO_HANDLE_FIVE,

        TEMPLE_THREE_PUZZLE_THREE_HANDLE_ONE,
        TEMPLE_THREE_PUZZLE_THREE_HANDLE_TWO,
        TEMPLE_THREE_PUZZLE_THREE_HANDLE_THREE,
        TEMPLE_THREE_PUZZLE_THREE_HANDLE_FOUR,
        TEMPLE_THREE_PUZZLE_THREE_HANDLE_FIVE,
        TEMPLE_THREE_PUZZLE_THREE_HANDLE_SIX,
        TEMPLE_THREE_PUZZLE_THREE_HANDLE_SEVEN,

        TEMPLE_THREE_PUZZLE_FOUR_HANDLE_ONE,




        //In Temple Four
        TEMPLE_FOUR_PUZZLE_ONE_HANDLE_NORTH,
        TEMPLE_FOUR_PUZZLE_ONE_HANDLE_SOUTH,
        TEMPLE_FOUR_PUZZLE_ONE_HANDLE_EAST,
        TEMPLE_FOUR_PUZZLE_ONE_HANDLE_WEST,

        TEMPLE_FOUR_PUZZLE_TWO_HANDLE_WEST,
        TEMPLE_FOUR_PUZZLE_TWO_HANDLE_EAST,
        TEMPLE_FOUR_PUZZLE_TWO_HANDLE_NORTH,
        TEMPLE_FOUR_PUZZLE_TWO_HANDLE_SOUTH,

        TEMPLE_FOUR_PUZZLE_THREE_HANDLE_WEST,
        TEMPLE_FOUR_PUZZLE_THREE_HANDLE_EAST,
        TEMPLE_FOUR_PUZZLE_THREE_HANDLE_NORTH,
        TEMPLE_FOUR_PUZZLE_THREE_HANDLE_SOUTH,

        TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_WEST_A,
        TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_EAST_A,
        TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_NORTH_A,
        TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_SOUTH_A,

        TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_WEST_B,
        TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_EAST_B,
        TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_NORTH_B,
        TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_SOUTH_B,

        TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_WEST_C,
        TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_EAST_C,
        TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_NORTH_C,
        TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_SOUTH_C,

        TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_WEST_A,
        TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_EAST_A,
        TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_NORTH_A,
        TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_SOUTH_A,

        TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_WEST_B,
        TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_EAST_B,
        TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_NORTH_B,
        TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_SOUTH_B,

        TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_WEST_C,
        TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_EAST_C,
        TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_NORTH_C,
        TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_SOUTH_C,

        TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_WEST_D,
        TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_EAST_D,
        TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_NORTH_D,
        TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_SOUTH_D,

        //In Final Temple
        FINAL_TEMPLE_TORCH_ONE,
        FINAL_TEMPLE_TORCH_TWO,
        FINAL_TEMPLE_TORCH_THREE,
        FINAL_TEMPLE_TORCH_FOUR,

        FINAL_TEMPLE_ROTATION_PUZZLE_HANDLE_ONE,
        FINAL_TEMPLE_ROTATION_PUZZLE_HANDLE_TWO,
        FINAL_TEMPLE_ROTATION_PUZZLE_HANDLE_THREE,
        FINAL_TEMPLE_ROTATION_PUZZLE_HANDLE_FOUR,
        FINAL_TEMPLE_ROTATION_PUZZLE_HANDLE_FIVE,
        FINAL_TEMPLE_ROTATION_PUZZLE_HANDLE_SIX,
        FINAL_TEMPLE_ROTATION_PUZZLE_HANDLE_SEVEN,
        FINAL_TEMPLE_ROTATION_PUZZLE_HANDLE_EIGHT,
        FINAL_TEMPLE_ROTATION_PUZZLE_HANDLE_NINE,

        FINAL_TEMPLE_RESET,

        //In Hub Area

        //In Traps Area

        //In Ice Area

        //In Mountain Area

        //In Wolves Area
    }

    public Object_To_Interact_With local_Object_To_Interact_With;


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Block")
        {
            if (button_Prompt_Gameobject != null)
            {
                button_Prompt_Gameobject.SetActive(false);
            }
            local_Object_To_Interact_With = Object_To_Interact_With.NONE;
            if (temp_Glow_Object != null)
            {
                temp_Glow_Object.Turn_Off_Highlight();
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (button_Prompt_Gameobject != null)
        {
            button_Prompt_Gameobject.SetActive(true);
        }

        temp_Glow_Object = other.gameObject.GetComponentInParent<GlowObject>();
        if (temp_Glow_Object != null)
        {
            temp_Glow_Object.Turn_On_Highlight();
        }

        switch (other.gameObject.tag)
        {
            //General
            case "Campfire":
                local_Object_To_Interact_With = Object_To_Interact_With.CAMPFIRE;
                current_Campfire = other.gameObject;
                break;

            case "Flower":
                local_Object_To_Interact_With = Object_To_Interact_With.FLOWER;
                current_Flower = other.gameObject;
                break;

            //Cabin
            case "Fireplace":
                local_Object_To_Interact_With = Object_To_Interact_With.FIREPLACE;
                break;

            case "Book":
                local_Object_To_Interact_With = Object_To_Interact_With.BOOK;
                break;

            case "Cabin_Door":
                local_Object_To_Interact_With = Object_To_Interact_With.DOOR;
                break;

            //In Temple One
            case "Temple_One_Torch_One":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_ONE_TORCH_ONE;
                break;

            case "Temple_One_Torch_Two":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_ONE_TORCH_TWO;
                break;

            case "Temple_One_Torch_Three":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_ONE_TORCH_THREE;
                break;

            case "Temple_One_Torch_Four":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_ONE_TORCH_FOUR;
                break;

            case "Temple_One_Torch_Five":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_ONE_TORCH_FIVE;
                break;

            case "Temple_One_Torch_Six":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_ONE_TORCH_SIX;
                break;

            case "Temple_One_Torch_Seven":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_ONE_TORCH_SEVEN;
                break;

            case "Temple_One_Torch_Eight":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_ONE_TORCH_EIGHT;
                break;

            case "Temple_One_Torch_Nine":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_ONE_TORCH_NINE;
                break;


            case "Temple_One_Room_One_Reset":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_ONE_RESET_ONE;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_One_Room_Two_Reset":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_ONE_RESET_TWO;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_One_Torch_Ten":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_ONE_TORCH_TEN;
                break;


            //In Temple Two

            case "Temple_Two_Puzzle_One_Handle_One":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_TWO_PUZZLE_ONE_HANDLE_ONE;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Two_Puzzle_Two_Handle_One":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_TWO_PUZZLE_TWO_HANDLE_ONE;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Two_Puzzle_Two_Handle_Two":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_TWO_PUZZLE_TWO_HANDLE_TWO;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Two_Puzzle_Two_Handle_Three":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_TWO_PUZZLE_TWO_HANDLE_THREE;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Two_Puzzle_Three_Handle_One":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_TWO_PUZZLE_THREE_HANDLE_ONE;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Two_Puzzle_Three_Handle_Two":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_TWO_PUZZLE_THREE_HANDLE_TWO;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Two_Puzzle_Three_Handle_Three":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_TWO_PUZZLE_THREE_HANDLE_THREE;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Two_Puzzle_Three_Handle_Four":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_TWO_PUZZLE_THREE_HANDLE_FOUR;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Two_Puzzle_Four_Handle_One":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_TWO_PUZZLE_FOUR_HANDLE_ONE;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Two_Puzzle_Four_Handle_Two":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_TWO_PUZZLE_FOUR_HANDLE_TWO;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Two_Puzzle_Four_Handle_Three":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_TWO_PUZZLE_FOUR_HANDLE_THREE;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Two_Puzzle_Four_Handle_Four":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_TWO_PUZZLE_FOUR_HANDLE_FOUR;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Two_Puzzle_Five_Handle_One":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_TWO_PUZZLE_FIVE_HANDLE_ONE;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Two_Puzzle_Five_Handle_Two":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_TWO_PUZZLE_FIVE_HANDLE_TWO;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Two_Puzzle_Five_Handle_Three":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_TWO_PUZZLE_FIVE_HANDLE_THREE;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Two_Puzzle_Five_Handle_Four":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_TWO_PUZZLE_FIVE_HANDLE_FOUR;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Two_Puzzle_Five_Handle_Five":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_TWO_PUZZLE_FIVE_HANDLE_FIVE;
                interactionGameObject = other.gameObject;
                break;

            //In Temple Three

            case "Temple_Three_Puzzle_One_Handle_One":
                if (can_Highlight)
                {
                    StartCoroutine(first_Temple_Three_Puzzle_One_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case "Temple_Three_Puzzle_Two_Handle_One":
                if (can_Highlight)
                {
                    StartCoroutine(first_Temple_Three_Puzzle_Two_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case "Temple_Three_Puzzle_Two_Handle_Two":
                if (can_Highlight)
                {
                    StartCoroutine(second_Temple_Three_Puzzle_Two_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case "Temple_Three_Puzzle_Two_Handle_Three":
                if (can_Highlight)
                {
                    StartCoroutine(third_Temple_Three_Puzzle_Two_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case "Temple_Three_Puzzle_Two_Handle_Four":
                if (can_Highlight)
                {
                    StartCoroutine(fourth_Temple_Three_Puzzle_Two_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case "Temple_Three_Puzzle_Two_Handle_Five":
                if (can_Highlight)
                {
                    StartCoroutine(fifth_Temple_Three_Puzzle_Two_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }


                break;


            case "Temple_Three_Puzzle_Three_Handle_One":
                if (can_Highlight)
                {
                    StartCoroutine(first_Temple_Three_Puzzle_Three_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case "Temple_Three_Puzzle_Three_Handle_Two":
                if (can_Highlight)
                {
                    StartCoroutine(second_Temple_Three_Puzzle_Three_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case "Temple_Three_Puzzle_Three_Handle_Three":
                if (can_Highlight)
                {
                    StartCoroutine(third_Temple_Three_Puzzle_Three_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case "Temple_Three_Puzzle_Three_Handle_Four":
                if (can_Highlight)
                {
                    StartCoroutine(fourth_Temple_Three_Puzzle_Three_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case "Temple_Three_Puzzle_Three_Handle_Five":
                if (can_Highlight)
                {
                    StartCoroutine(fifth_Temple_Three_Puzzle_Three_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case "Temple_Three_Puzzle_Three_Handle_Six":
                if (can_Highlight)
                {
                    StartCoroutine(sixth_Temple_Three_Puzzle_Three_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case "Temple_Three_Puzzle_Three_Handle_Seven":
                if (can_Highlight)
                {
                    StartCoroutine(seventh_Temple_Three_Puzzle_Three_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case "Temple_Three_Puzzle_Four_Handle_One":
                if (can_Highlight)
                {
                    StartCoroutine(first_Temple_Three_Puzzle_Four_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case "Temple_Three_Puzzle_Four_Handle_Two":
                if (can_Highlight)
                {
                    StartCoroutine(second_Temple_Three_Puzzle_Four_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case "Temple_Three_Puzzle_Four_Handle_Three":
                if (can_Highlight)
                {
                    StartCoroutine(third_Temple_Three_Puzzle_Four_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case "Temple_Three_Puzzle_Four_Handle_Four":
                if (can_Highlight)
                {
                    StartCoroutine(fourth_Temple_Three_Puzzle_Four_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;


            case "Temple_Three_Puzzle_Four_Handle_Five":
                if (can_Highlight)
                {
                    StartCoroutine(fifth_Temple_Three_Puzzle_Four_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;


            case "Temple_Three_Puzzle_Four_Handle_Six":
                if (can_Highlight)
                {
                    StartCoroutine(sixth_Temple_Three_Puzzle_Four_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;


            case "Temple_Three_Puzzle_Four_Handle_Seven":
                if (can_Highlight)
                {
                    StartCoroutine(seventh_Temple_Three_Puzzle_Four_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case "Temple_Three_Puzzle_Five_Handle_One":
                if (can_Highlight)
                {
                    StartCoroutine(first_Temple_Three_Puzzle_Five_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case "Temple_Three_Puzzle_Five_Handle_Two":
                if (can_Highlight)
                {
                    StartCoroutine(second_Temple_Three_Puzzle_Five_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case "Temple_Three_Puzzle_Five_Handle_Three":
                if (can_Highlight)
                {
                    StartCoroutine(third_Temple_Three_Puzzle_Five_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case "Temple_Three_Puzzle_Five_Handle_Four":
                if (can_Highlight)
                {
                    StartCoroutine(fourth_Temple_Three_Puzzle_Five_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case "Temple_Three_Puzzle_Five_Handle_Five":
                if (can_Highlight)
                {
                    StartCoroutine(fifth_Temple_Three_Puzzle_Five_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case "Temple_Three_Puzzle_Five_Handle_Six":
                if (can_Highlight)
                {
                    StartCoroutine(sixth_Temple_Three_Puzzle_Five_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case "Temple_Three_Puzzle_Five_Handle_Seven":
                if (can_Highlight)
                {
                    StartCoroutine(seventh_Temple_Three_Puzzle_Five_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case "Temple_Three_Puzzle_Five_Handle_Eight":
                if (can_Highlight)
                {
                    StartCoroutine(eight_Temple_Three_Puzzle_Five_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case "Temple_Three_Puzzle_Five_Handle_Nine":
                if (can_Highlight)
                {
                    StartCoroutine(ninth_Temple_Three_Puzzle_Five_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case "Temple_Three_Puzzle_Five_Handle_Ten":
                if (can_Highlight)
                {
                    StartCoroutine(tenth_Temple_Three_Puzzle_Five_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case "Temple_Three_Puzzle_Five_Handle_Eleven":
                if (can_Highlight)
                {
                    StartCoroutine(eleventh_Temple_Three_Puzzle_Five_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case "Temple_Three_Puzzle_Five_Handle_Twelve":
                if (can_Highlight)
                {
                    StartCoroutine(twelfth_Temple_Three_Puzzle_Five_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case "Temple_Three_Puzzle_Five_Handle_Thirteen":
                if (can_Highlight)
                {
                    StartCoroutine(thirteenth_Temple_Three_Puzzle_Five_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case "Temple_Three_Puzzle_Five_Handle_Fourteen":
                if (can_Highlight)
                {
                    StartCoroutine(fourteenth_Temple_Three_Puzzle_Five_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case "Temple_Three_Puzzle_Five_Handle_Fifteen":
                if (can_Highlight)
                {
                    StartCoroutine(fifteenth_Temple_Three_Puzzle_Five_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case "Temple_Three_Puzzle_Five_Handle_Sixteen":
                if (can_Highlight)
                {
                    StartCoroutine(sixteenth_Temple_Three_Puzzle_Five_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case "Temple_Three_Puzzle_Five_Handle_Seventeen":
                if (can_Highlight)
                {
                    StartCoroutine(seventeenth_Temple_Three_Puzzle_Five_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;





            //In Temple Four
            case "Temple_Four_Puzzle_One_Handle_North":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_ONE_HANDLE_NORTH;

                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_One_Handle_South":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_ONE_HANDLE_SOUTH;

                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_One_Handle_East":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_ONE_HANDLE_EAST;

                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_One_Handle_West":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_ONE_HANDLE_WEST;

                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_Two_Handle_North":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_TWO_HANDLE_NORTH;

                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_Two_Handle_South":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_TWO_HANDLE_SOUTH;

                interactionGameObject = other.gameObject;

                break;

            case "Temple_Four_Puzzle_Two_Handle_East":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_TWO_HANDLE_EAST;

                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_Two_Handle_West":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_TWO_HANDLE_WEST;

                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_Three_Handle_North":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_THREE_HANDLE_NORTH;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_Three_Handle_South":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_THREE_HANDLE_SOUTH;
                interactionGameObject = other.gameObject;

                break;

            case "Temple_Four_Puzzle_Three_Handle_East":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_THREE_HANDLE_EAST;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_Three_Handle_West":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_THREE_HANDLE_WEST;
                interactionGameObject = other.gameObject;
                break;


            case "Temple_Four_Puzzle_Four_Handle_North_A":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_NORTH_A;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_Four_Handle_South_A":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_SOUTH_A;
                interactionGameObject = other.gameObject;

                break;

            case "Temple_Four_Puzzle_Four_Handle_East_A":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_EAST_A;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_Four_Handle_West_A":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_WEST_A;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_Four_Handle_North_B":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_NORTH_B;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_Four_Handle_South_B":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_SOUTH_B;
                interactionGameObject = other.gameObject;

                break;

            case "Temple_Four_Puzzle_Four_Handle_East_B":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_EAST_B;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_Four_Handle_West_B":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_WEST_B;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_Four_Handl_North_C":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_NORTH_C;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_Four_Handl_South_C":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_SOUTH_C;
                interactionGameObject = other.gameObject;

                break;

            case "Temple_Four_Puzzle_Four_Handl_East_C":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_EAST_C;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_Four_Handl_West_C":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_WEST_C;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_Five_Handle_North_A":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_NORTH_A;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_Five_Handle_South_A":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_SOUTH_A;
                interactionGameObject = other.gameObject;

                break;

            case "Temple_Four_Puzzle_Five_Handle_East_A":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_EAST_A;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_Five_Handle_West_A":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_WEST_A;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_Five_Handle_North_B":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_NORTH_B;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_Five_Handle_South_B":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_SOUTH_B;
                interactionGameObject = other.gameObject;

                break;

            case "Temple_Four_Puzzle_Five_Handle_East_B":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_EAST_B;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_Five_Handle_West_B":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_WEST_B;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_Five_Handle_North_C":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_NORTH_C;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_Five_Handle_South_C":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_SOUTH_C;
                interactionGameObject = other.gameObject;

                break;

            case "Temple_Four_Puzzle_Five_Handle_East_C":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_EAST_C;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_Five_Handle_West_C":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_WEST_C;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_Five_Handle_North_D":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_NORTH_D;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_Five_Handle_South_D":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_SOUTH_D;
                interactionGameObject = other.gameObject;

                break;

            case "Temple_Four_Puzzle_Five_Handle_East_D":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_EAST_D;
                interactionGameObject = other.gameObject;
                break;

            case "Temple_Four_Puzzle_Five_Handle_West_D":
                local_Object_To_Interact_With = Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_WEST_D;
                interactionGameObject = other.gameObject;
                break;


            //In Final Temple

            case "Final_Temple_Rotation_Puzzle_Handle_One":
                local_Object_To_Interact_With = Object_To_Interact_With.FINAL_TEMPLE_ROTATION_PUZZLE_HANDLE_ONE;
                interactionGameObject = other.gameObject;
                break;

            case "Final_Temple_Rotation_Puzzle_Handle_Two":
                local_Object_To_Interact_With = Object_To_Interact_With.FINAL_TEMPLE_ROTATION_PUZZLE_HANDLE_TWO;
                interactionGameObject = other.gameObject;
                break;

            case "Final_Temple_Rotation_Puzzle_Handle_Three":
                local_Object_To_Interact_With = Object_To_Interact_With.FINAL_TEMPLE_ROTATION_PUZZLE_HANDLE_THREE;
                interactionGameObject = other.gameObject;
                break;

            case "Final_Temple_Rotation_Puzzle_Handle_Four":
                local_Object_To_Interact_With = Object_To_Interact_With.FINAL_TEMPLE_ROTATION_PUZZLE_HANDLE_FOUR;
                interactionGameObject = other.gameObject;
                break;

            case "Final_Temple_Rotation_Puzzle_Handle_Five":
                local_Object_To_Interact_With = Object_To_Interact_With.FINAL_TEMPLE_ROTATION_PUZZLE_HANDLE_FIVE;
                interactionGameObject = other.gameObject;
                break;

            case "Final_Temple_Rotation_Puzzle_Handle_Six":
                local_Object_To_Interact_With = Object_To_Interact_With.FINAL_TEMPLE_ROTATION_PUZZLE_HANDLE_SIX;
                interactionGameObject = other.gameObject;
                break;

            case "Final_Temple_Rotation_Puzzle_Handle_Seven":
                local_Object_To_Interact_With = Object_To_Interact_With.FINAL_TEMPLE_ROTATION_PUZZLE_HANDLE_SEVEN;
                interactionGameObject = other.gameObject;
                break;

            case "Final_Temple_Rotation_Puzzle_Handle_Eight":
                local_Object_To_Interact_With = Object_To_Interact_With.FINAL_TEMPLE_ROTATION_PUZZLE_HANDLE_EIGHT;
                interactionGameObject = other.gameObject;
                break;

            case "Final_Temple_Rotation_Puzzle_Handle_Nine":
                local_Object_To_Interact_With = Object_To_Interact_With.FINAL_TEMPLE_ROTATION_PUZZLE_HANDLE_NINE;
                interactionGameObject = other.gameObject;
                break;


            case "Final_Temple_Torch_One":
                local_Object_To_Interact_With = Object_To_Interact_With.FINAL_TEMPLE_TORCH_ONE;
                interactionGameObject = other.gameObject;
                break;

            case "Final_Temple_Torch_Two":
                local_Object_To_Interact_With = Object_To_Interact_With.FINAL_TEMPLE_TORCH_TWO;
                interactionGameObject = other.gameObject;
                break;

            case "Final_Temple_Torch_Three":
                local_Object_To_Interact_With = Object_To_Interact_With.FINAL_TEMPLE_TORCH_THREE;
                interactionGameObject = other.gameObject;
                break;

            case "Final_Temple_Torch_Four":
                local_Object_To_Interact_With = Object_To_Interact_With.FINAL_TEMPLE_TORCH_FOUR;
                interactionGameObject = other.gameObject;
                break;

            case "Final_Temple_Wind_Handle_One":
                if (can_Highlight)
                {
                    StartCoroutine(first_Final_Temple_Wind_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case "Final_Temple_Wind_Handle_Two":
                if (can_Highlight)
                {
                    StartCoroutine(second_Final_Temple_Wind_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case "Final_Temple_Wind_Handle_Three":
                if (can_Highlight)
                {
                    StartCoroutine(third_Final_Temple_Wind_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case "Final_Temple_Wind_Handle_Four":
                if (can_Highlight)
                {
                    StartCoroutine(fourth_Final_Temple_Wind_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case "Final_Temple_Wind_Handle_Five":
                if (can_Highlight)
                {
                    StartCoroutine(fifth_Final_Temple_Wind_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case "Final_Temple_Wind_Handle_Six":
                if (can_Highlight)
                {
                    StartCoroutine(sixth_Final_Temple_Wind_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case "Final_Temple_Wind_Handle_Seven":
                if (can_Highlight)
                {
                    StartCoroutine(seventh_Final_Temple_Wind_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case "Final_Temple_Wind_Handle_Eight":
                if (can_Highlight)
                {
                    StartCoroutine(eight_Final_Temple_Wind_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case "Final_Temple_Wind_Handle_Nine":
                if (can_Highlight)
                {
                    StartCoroutine(ninth_Final_Temple_Wind_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case "Final_Temple_Wind_Handle_Ten":
                if (can_Highlight)
                {
                    StartCoroutine(tenth_Final_Temple_Wind_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case "Final_Temple_Wind_Handle_Eleven":
                if (can_Highlight)
                {
                    StartCoroutine(eleventh_Final_Temple_Wind_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case "Final_Temple_Wind_Handle_Twelve":
                if (can_Highlight)
                {
                    StartCoroutine(twelfth_Final_Temple_Wind_Handle.Press_Pressure_Plate());
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case "Final_Temple_Torch_Reset":


                local_Object_To_Interact_With = Object_To_Interact_With.FINAL_TEMPLE_RESET;
                interactionGameObject = other.gameObject;
                break;

            //In Hub Area

            //In Traps Area

            //In Ice Area

            //In Mountain Area

            //In Wolves Area

            default:
                break;
        }
    }

    public void Interact_With_Object()
    {

        switch (local_Object_To_Interact_With)
        {
            //General

            case Object_To_Interact_With.CAMPFIRE:
                StartCoroutine("Start_Interaction_Cooldown");
                current_Campfire.GetComponent<Campfire_Manager>().Interact_With();
                break;

            case Object_To_Interact_With.FLOWER:
                StartCoroutine("Start_Interaction_Cooldown");
                current_Flower.GetComponent<Flower_Manager>().Interact_With();
                break;


            //Cabin
            case Object_To_Interact_With.FIREPLACE:
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            case Object_To_Interact_With.BOOK:
                StartCoroutine("Start_Interaction_Cooldown");

                break;

            case Object_To_Interact_With.DOOR:
                StartCoroutine("Start_Interaction_Cooldown");
                local_Cabin_Exit.Invoke("Exit_Cabin", 2.0f);
                break;

            //In Temple One
            case Object_To_Interact_With.TEMPLE_ONE_TORCH_ONE:
                temp_Can_Animate = local_Temple_One_Torch_One.Interact_With();
                if (temp_Can_Animate == true)
                {
                    StartCoroutine("Start_Interaction_Cooldown");
                }

                break;

            case Object_To_Interact_With.TEMPLE_ONE_TORCH_TWO:
                temp_Can_Animate = local_Temple_One_Torch_Two.Interact_With();
                if (temp_Can_Animate == true)
                {
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case Object_To_Interact_With.TEMPLE_ONE_TORCH_THREE:
                temp_Can_Animate = local_Temple_One_Torch_Three.Interact_With();
                if (temp_Can_Animate == true)
                {
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case Object_To_Interact_With.TEMPLE_ONE_TORCH_FOUR:
                temp_Can_Animate = local_Temple_One_Torch_Four.Interact_With();
                if (temp_Can_Animate == true)
                {
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case Object_To_Interact_With.TEMPLE_ONE_TORCH_FIVE:
                temp_Can_Animate = local_Temple_One_Torch_Five.Interact_With();
                if (temp_Can_Animate == true)
                {
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case Object_To_Interact_With.TEMPLE_ONE_TORCH_SIX:
                temp_Can_Animate = local_Temple_One_Torch_Six.Interact_With();
                if (temp_Can_Animate == true)
                {
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case Object_To_Interact_With.TEMPLE_ONE_TORCH_SEVEN:
                temp_Can_Animate = local_Temple_One_Torch_Seven.Interact_With();
                if (temp_Can_Animate == true)
                {
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case Object_To_Interact_With.TEMPLE_ONE_TORCH_EIGHT:
                temp_Can_Animate = local_Temple_One_Torch_Eight.Interact_With();
                if (temp_Can_Animate == true)
                {
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case Object_To_Interact_With.TEMPLE_ONE_TORCH_NINE:
                temp_Can_Animate = local_Temple_One_Torch_Nine.Interact_With();
                if (temp_Can_Animate == true)
                {
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case Object_To_Interact_With.TEMPLE_ONE_TORCH_TEN:
                temp_Can_Animate = local_Temple_One_Torch_Ten.Interact_With();
                if (temp_Can_Animate == true)
                {
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case Object_To_Interact_With.TEMPLE_ONE_RESET_ONE:
                StartCoroutine(local_Temple_One_Puzzle_Two.Reset_Puzzle(true));
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            case Object_To_Interact_With.TEMPLE_ONE_RESET_TWO:
                StartCoroutine(local_Temple_One_Puzzle_Three.Reset_Puzzle(true));
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            //In Temple Two
            case Object_To_Interact_With.TEMPLE_TWO_PUZZLE_ONE_HANDLE_ONE:
                StartCoroutine(first_Temple_Two_Puzzle_One_Handle.PullLever());
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            case Object_To_Interact_With.TEMPLE_TWO_PUZZLE_TWO_HANDLE_ONE:
                StartCoroutine(first_Temple_Two_Puzzle_Two_Handle.PullLever());
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            case Object_To_Interact_With.TEMPLE_TWO_PUZZLE_TWO_HANDLE_TWO:
                StartCoroutine(second_Temple_Two_Puzzle_Two_Handle.PullLever());
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            case Object_To_Interact_With.TEMPLE_TWO_PUZZLE_TWO_HANDLE_THREE:
                StartCoroutine(third_Temple_Two_Puzzle_Two_Handle.PullLever());
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            case Object_To_Interact_With.TEMPLE_TWO_PUZZLE_THREE_HANDLE_ONE:
                StartCoroutine(first_Temple_Two_Puzzle_Three_Handle.PullLever());
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            case Object_To_Interact_With.TEMPLE_TWO_PUZZLE_THREE_HANDLE_TWO:
                StartCoroutine(second_Temple_Two_Puzzle_Three_Handle.PullLever());
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            case Object_To_Interact_With.TEMPLE_TWO_PUZZLE_THREE_HANDLE_THREE:
                StartCoroutine(third_Temple_Two_Puzzle_Three_Handle.PullLever());
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            case Object_To_Interact_With.TEMPLE_TWO_PUZZLE_THREE_HANDLE_FOUR:
                StartCoroutine(fourth_Temple_Two_Puzzle_Three_Handle.PullLever());
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            case Object_To_Interact_With.TEMPLE_TWO_PUZZLE_FOUR_HANDLE_ONE:
                StartCoroutine(first_Temple_Two_Puzzle_Four_Handle.PullLever());
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            case Object_To_Interact_With.TEMPLE_TWO_PUZZLE_FOUR_HANDLE_TWO:
                StartCoroutine(second_Temple_Two_Puzzle_Four_Handle.PullLever());
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            case Object_To_Interact_With.TEMPLE_TWO_PUZZLE_FOUR_HANDLE_THREE:
                StartCoroutine(third_Temple_Two_Puzzle_Four_Handle.PullLever());
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            case Object_To_Interact_With.TEMPLE_TWO_PUZZLE_FOUR_HANDLE_FOUR:
                StartCoroutine(fourth_Temple_Two_Puzzle_Four_Handle.PullLever());
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            case Object_To_Interact_With.TEMPLE_TWO_PUZZLE_FIVE_HANDLE_ONE:
                StartCoroutine(first_Temple_Two_Puzzle_Five_Handle.PullLever());
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            case Object_To_Interact_With.TEMPLE_TWO_PUZZLE_FIVE_HANDLE_TWO:
                StartCoroutine(second_Temple_Two_Puzzle_Five_Handle.PullLever());
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            case Object_To_Interact_With.TEMPLE_TWO_PUZZLE_FIVE_HANDLE_THREE:
                StartCoroutine(third_Temple_Two_Puzzle_Five_Handle.PullLever());
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            case Object_To_Interact_With.TEMPLE_TWO_PUZZLE_FIVE_HANDLE_FOUR:
                StartCoroutine(fourth_Temple_Two_Puzzle_Five_Handle.PullLever());
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            case Object_To_Interact_With.TEMPLE_TWO_PUZZLE_FIVE_HANDLE_FIVE:
                StartCoroutine(fifth_Temple_Two_Puzzle_Five_Handle.PullLever());
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            //In Temple Three

            //In Temple Four

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_ONE_HANDLE_NORTH:
                //local_Ice_Temple_Puzzle_Two.Move_West(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_ONE_HANDLE_EAST:
                //local_Ice_Temple_Puzzle_Two.Move_West(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_ONE_HANDLE_SOUTH:
                //local_Ice_Temple_Puzzle_Two.Move_West(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_ONE_HANDLE_WEST:
                //local_Ice_Temple_Puzzle_Two.Move_West(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_TWO_HANDLE_EAST:
                //local_Ice_Temple_Puzzle_Two.Move_West(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_TWO_HANDLE_WEST:
                //local_Ice_Temple_Puzzle_Two.Move_East(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_TWO_HANDLE_SOUTH:
                //local_Ice_Temple_Puzzle_Two.Move_North(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_TWO_HANDLE_NORTH:
                //local_Ice_Temple_Puzzle_Two.Move_South(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_THREE_HANDLE_EAST:
                //local_Ice_Temple_Puzzle_Three.Move_West(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_THREE_HANDLE_WEST:
                //local_Ice_Temple_Puzzle_Three.Move_East(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_THREE_HANDLE_SOUTH:
                //local_Ice_Temple_Puzzle_Three.Move_North(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_THREE_HANDLE_NORTH:
                //local_Ice_Temple_Puzzle_Three.Move_South(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_EAST_A:
                local_Ice_Temple_Puzzle_Four.Change_Current_Moving_Block(Ice_Temple_Puzzle_Four.Active_Box.FIRST);
                //local_Ice_Temple_Puzzle_Four.Move_West(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_WEST_A:
                local_Ice_Temple_Puzzle_Four.Change_Current_Moving_Block(Ice_Temple_Puzzle_Four.Active_Box.FIRST);
                //local_Ice_Temple_Puzzle_Four.Move_East(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_SOUTH_A:
                local_Ice_Temple_Puzzle_Four.Change_Current_Moving_Block(Ice_Temple_Puzzle_Four.Active_Box.FIRST);
                //local_Ice_Temple_Puzzle_Four.Move_North(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_NORTH_A:
                local_Ice_Temple_Puzzle_Four.Change_Current_Moving_Block(Ice_Temple_Puzzle_Four.Active_Box.FIRST);
                //local_Ice_Temple_Puzzle_Four.Move_South(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_EAST_B:
                local_Ice_Temple_Puzzle_Four.Change_Current_Moving_Block(Ice_Temple_Puzzle_Four.Active_Box.SECOND);
                //local_Ice_Temple_Puzzle_Four.Move_West(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_WEST_B:
                local_Ice_Temple_Puzzle_Four.Change_Current_Moving_Block(Ice_Temple_Puzzle_Four.Active_Box.SECOND);
                //local_Ice_Temple_Puzzle_Four.Move_East(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_SOUTH_B:
                local_Ice_Temple_Puzzle_Four.Change_Current_Moving_Block(Ice_Temple_Puzzle_Four.Active_Box.SECOND);
                //local_Ice_Temple_Puzzle_Four.Move_North(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_NORTH_B:
                local_Ice_Temple_Puzzle_Four.Change_Current_Moving_Block(Ice_Temple_Puzzle_Four.Active_Box.SECOND);
                //local_Ice_Temple_Puzzle_Four.Move_South(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_EAST_C:
                local_Ice_Temple_Puzzle_Four.Change_Current_Moving_Block(Ice_Temple_Puzzle_Four.Active_Box.THIRD);
                //local_Ice_Temple_Puzzle_Four.Move_West(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_WEST_C:
                local_Ice_Temple_Puzzle_Four.Change_Current_Moving_Block(Ice_Temple_Puzzle_Four.Active_Box.THIRD);
                //local_Ice_Temple_Puzzle_Four.Move_East(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_SOUTH_C:
                local_Ice_Temple_Puzzle_Four.Change_Current_Moving_Block(Ice_Temple_Puzzle_Four.Active_Box.THIRD);
                //local_Ice_Temple_Puzzle_Four.Move_North(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FOUR_HANDLE_NORTH_C:
                local_Ice_Temple_Puzzle_Four.Change_Current_Moving_Block(Ice_Temple_Puzzle_Four.Active_Box.THIRD);
                //local_Ice_Temple_Puzzle_Four.Move_South(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_EAST_A:
                local_Ice_Temple_Puzzle_Five.Change_Current_Moving_Block(Ice_Temple_Puzzle_Five.Active_Box.FIRST);
                //local_Ice_Temple_Puzzle_Five.Move_West(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_WEST_A:
                local_Ice_Temple_Puzzle_Five.Change_Current_Moving_Block(Ice_Temple_Puzzle_Five.Active_Box.FIRST);
                //local_Ice_Temple_Puzzle_Five.Move_East(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_SOUTH_A:
                local_Ice_Temple_Puzzle_Five.Change_Current_Moving_Block(Ice_Temple_Puzzle_Five.Active_Box.FIRST);
                //local_Ice_Temple_Puzzle_Five.Move_North(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_NORTH_A:
                local_Ice_Temple_Puzzle_Five.Change_Current_Moving_Block(Ice_Temple_Puzzle_Five.Active_Box.FIRST);
                //local_Ice_Temple_Puzzle_Five.Move_South(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_EAST_B:
                local_Ice_Temple_Puzzle_Five.Change_Current_Moving_Block(Ice_Temple_Puzzle_Five.Active_Box.SECOND);
                //local_Ice_Temple_Puzzle_Five.Move_West(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_WEST_B:
                local_Ice_Temple_Puzzle_Five.Change_Current_Moving_Block(Ice_Temple_Puzzle_Five.Active_Box.SECOND);
                //local_Ice_Temple_Puzzle_Five.Move_East(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_SOUTH_B:
                local_Ice_Temple_Puzzle_Five.Change_Current_Moving_Block(Ice_Temple_Puzzle_Five.Active_Box.SECOND);
                //local_Ice_Temple_Puzzle_Five.Move_North(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_NORTH_B:
                local_Ice_Temple_Puzzle_Five.Change_Current_Moving_Block(Ice_Temple_Puzzle_Five.Active_Box.SECOND);
                //local_Ice_Temple_Puzzle_Five.Move_South(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_EAST_C:
                local_Ice_Temple_Puzzle_Five.Change_Current_Moving_Block(Ice_Temple_Puzzle_Five.Active_Box.THIRD);
                //local_Ice_Temple_Puzzle_Five.Move_West(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_WEST_C:
                local_Ice_Temple_Puzzle_Five.Change_Current_Moving_Block(Ice_Temple_Puzzle_Five.Active_Box.THIRD);
                //local_Ice_Temple_Puzzle_Five.Move_East(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_SOUTH_C:
                local_Ice_Temple_Puzzle_Five.Change_Current_Moving_Block(Ice_Temple_Puzzle_Five.Active_Box.THIRD);
                //local_Ice_Temple_Puzzle_Five.Move_North(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_NORTH_C:
                local_Ice_Temple_Puzzle_Five.Change_Current_Moving_Block(Ice_Temple_Puzzle_Five.Active_Box.THIRD);
                //local_Ice_Temple_Puzzle_Five.Move_South(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_EAST_D:
                local_Ice_Temple_Puzzle_Five.Change_Current_Moving_Block(Ice_Temple_Puzzle_Five.Active_Box.FOURTH);
                //local_Ice_Temple_Puzzle_Five.Move_West(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_WEST_D:
                local_Ice_Temple_Puzzle_Five.Change_Current_Moving_Block(Ice_Temple_Puzzle_Five.Active_Box.FOURTH);
                //local_Ice_Temple_Puzzle_Five.Move_East(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_SOUTH_D:
                local_Ice_Temple_Puzzle_Five.Change_Current_Moving_Block(Ice_Temple_Puzzle_Five.Active_Box.FOURTH);
                //local_Ice_Temple_Puzzle_Five.Move_North(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;

            case Object_To_Interact_With.TEMPLE_FOUR_PUZZLE_FIVE_HANDLE_NORTH_D:
                local_Ice_Temple_Puzzle_Five.Change_Current_Moving_Block(Ice_Temple_Puzzle_Five.Active_Box.FOURTH);
                //local_Ice_Temple_Puzzle_Five.Move_South(local_Ice_Temple_Puzzle_Two.local_Current_Tile_Number);
                StartCoroutine("Start_Interaction_Cooldown");

                StartCoroutine(
                    transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(
                        interactionGameObject.transform.GetChild(0), "Push Block", true));
                break;



            //In Final Temple

            case Object_To_Interact_With.FINAL_TEMPLE_ROTATION_PUZZLE_HANDLE_ONE:
                StartCoroutine(final_Rotation_Puzzle_Handle_1.PullLever());
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            case Object_To_Interact_With.FINAL_TEMPLE_ROTATION_PUZZLE_HANDLE_TWO:
                StartCoroutine(final_Rotation_Puzzle_Handle_2.PullLever());
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            case Object_To_Interact_With.FINAL_TEMPLE_ROTATION_PUZZLE_HANDLE_THREE:
                StartCoroutine(final_Rotation_Puzzle_Handle_3.PullLever());
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            case Object_To_Interact_With.FINAL_TEMPLE_ROTATION_PUZZLE_HANDLE_FOUR:
                StartCoroutine(final_Rotation_Puzzle_Handle_4.PullLever());
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            case Object_To_Interact_With.FINAL_TEMPLE_ROTATION_PUZZLE_HANDLE_FIVE:
                StartCoroutine(final_Rotation_Puzzle_Handle_5.PullLever());
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            case Object_To_Interact_With.FINAL_TEMPLE_ROTATION_PUZZLE_HANDLE_SIX:
                StartCoroutine(final_Rotation_Puzzle_Handle_6.PullLever());
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            case Object_To_Interact_With.FINAL_TEMPLE_ROTATION_PUZZLE_HANDLE_SEVEN:
                StartCoroutine(final_Rotation_Puzzle_Handle_7.PullLever());
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            case Object_To_Interact_With.FINAL_TEMPLE_ROTATION_PUZZLE_HANDLE_EIGHT:
                StartCoroutine(final_Rotation_Puzzle_Handle_8.PullLever());
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            case Object_To_Interact_With.FINAL_TEMPLE_ROTATION_PUZZLE_HANDLE_NINE:
                StartCoroutine(final_Rotation_Puzzle_Handle_9.PullLever());
                StartCoroutine("Start_Interaction_Cooldown");
                break;

            case Object_To_Interact_With.FINAL_TEMPLE_TORCH_ONE:
                temp_Can_Animate = final_Temple_Torch_One.Interact_With();
                if (temp_Can_Animate == true)
                {
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case Object_To_Interact_With.FINAL_TEMPLE_TORCH_TWO:
                temp_Can_Animate = final_Temple_Torch_Two.Interact_With();
                if (temp_Can_Animate == true)
                {
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case Object_To_Interact_With.FINAL_TEMPLE_TORCH_THREE:
                temp_Can_Animate = final_Temple_Torch_Three.Interact_With();
                if (temp_Can_Animate == true)
                {
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;

            case Object_To_Interact_With.FINAL_TEMPLE_TORCH_FOUR:
                temp_Can_Animate = final_Temple_Torch_Four.Interact_With();
                if (temp_Can_Animate == true)
                {
                    StartCoroutine("Start_Interaction_Cooldown");
                }
                break;


            case Object_To_Interact_With.FINAL_TEMPLE_RESET:

                StartCoroutine(local_Final_Temple_Torch_Puzzle.Reset_Puzzle(true));
                StartCoroutine("Start_Interaction_Cooldown");

                break;


            //In Hub Area

            //In Traps Area

            //In Ice Area

            //In Mountain Area

            //In Wolves Area

            default:
                break;
        }

    }

    IEnumerator Start_Interaction_Cooldown()
    {
        if (temp_Glow_Object != null)
        {
            temp_Glow_Object.Turn_Off_Highlight();
        }

        if (button_Prompt_Gameobject != null)
        {
            button_Prompt_Gameobject.SetActive(false);
        }

        can_Highlight = false;

        yield return new WaitForSeconds(interaction_Cooldown);

        if (charController.canMove)
        {
            can_Highlight = true;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && can_Highlight)
        {
            Interact_With_Object();
        }
    }
}
