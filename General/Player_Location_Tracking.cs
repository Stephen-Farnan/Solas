using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Player_Location_Tracking : MonoBehaviour
{

    public static bool beginning_Play = true;
    public bool in_Cabin = false;
    public GameObject player;
    public GameObject main_Camera;

    public bool cabin_Button_Prompt = true;
    public int cabin_Button_Prompt_Val = 1;

    public int campfire_Hub_1 = 0;
    public int campfire_Hub_2 = 0;
    public int campfire_Ice_1 = 0;
    public int campfire_Ice_2 = 0;
    public int campfire_Mountain_1 = 0;
    public int campfire_Mountain_2 = 0;
    public int campfire_Mountain_3 = 0;
    public int campfire_Mountain_4 = 0;
    public int campfire_Mountain_5 = 0;
    public int campfire_Mountain_6 = 0;
    public int campfire_Mountain_7 = 0;
    public int campfire_Trap_1 = 0;
    public int campfire_Trap_2 = 0;
    public int campfire_Trap_3 = 0;
    public int campfire_Trap_4 = 0;

    public int is_In_Cold_Area = 0;
    public ColdEffectTrigger local_ColdEffectTrigger;

    public Transform CAMPFIRE_HUB_1;
    public Transform CAMPFIRE_HUB_2;
    public Transform CAMPFIRE_ICE_1;
    public Transform CAMPFIRE_ICE_2;
    public Transform CAMPFIRE_MOUNTAIN_1;
    public Transform CAMPFIRE_MOUNTAIN_2;
    public Transform CAMPFIRE_MOUNTAIN_3;
    public Transform CAMPFIRE_MOUNTAIN_4;
    public Transform CAMPFIRE_MOUNTAIN_5;
    public Transform CAMPFIRE_MOUNTAIN_6;
    public Transform CAMPFIRE_MOUNTAIN_7;
    public Transform CAMPFIRE_TRAP_1;
    public Transform CAMPFIRE_TRAP_2;
    public Transform CAMPFIRE_TRAP_3;
    public Transform CAMPFIRE_TRAP_4;
    public Transform CABIN_INTERIOR;
    public Transform ICE_START_AREA;
    public Transform MOUNTAIN_START_AREA;
    public Transform TRAP_START_AREA;
    public Transform ICE_TEMPLE_START;
    public Transform FIRE_TEMPLE_START;
    public Transform MOUNTAIN_TEMPLE_START;
    public Transform TRAP_TEMPLE_START;
    public Transform HUB_AREA_CABIN_EXIT;
    public Transform HUB_AREA_TRAP_EXIT;
    public Transform HUB_AREA_MOUNTAIN_EXIT;
    public Transform HUB_AREA_ICE_EXIT;
    public Transform FINAL_TEMPLE_START;

    public enum Current_Checkpoint
    {
        CAMPFIRE_HUB_1,
        CAMPFIRE_HUB_2,
        CAMPFIRE_ICE_1,
        CAMPFIRE_ICE_2,
        CAMPFIRE_MOUNTAIN_1,
        CAMPFIRE_MOUNTAIN_2,
        CAMPFIRE_MOUNTAIN_3,
        CAMPFIRE_MOUNTAIN_4,
        CAMPFIRE_MOUNTAIN_5,
        CAMPFIRE_MOUNTAIN_6,
        CAMPFIRE_MOUNTAIN_7,
        CAMPFIRE_TRAP_1,
        CAMPFIRE_TRAP_2,
        CAMPFIRE_TRAP_3,
        CAMPFIRE_TRAP_4,
        CABIN_INTERIOR,
        ICE_START_AREA,
        MOUNTAIN_START_AREA,
        TRAP_START_AREA,
        ICE_TEMPLE_START,
        FIRE_TEMPLE_START,
        MOUNTAIN_TEMPLE_START,
        TRAP_TEMPLE_START,
        HUB_AREA_CABIN_EXIT,
        HUB_AREA_TRAP_EXIT,
        HUB_AREA_MOUNTAIN_EXIT,
        HUB_AREA_ICE_EXIT,
        FINAL_TEMPLE_START
    }

    public enum Current_Level
    {
        CABIN,
        HUB,
        TUTORIAL_TEMPLE,
        ICE_TEMPLE,
        WIND_TEMPLE,
        TRAP_TEMPLE,
        MOUNTAIN_AREA,
        TRAP_AREA,
        ICE_AREA,
        FINAL_TEMPLE
    }

    public Current_Level local_Current_Level;


    private void Awake()
    {
        Reload_From_Last_checkpoint();
    }

    private void Start()
    {



        if (PlayerPrefs.HasKey("cabin_Button_Prompt"))
        {
            if (PlayerPrefs.GetInt("cabin_Button_Prompt") == 0)
            {
                cabin_Button_Prompt = false;
                cabin_Button_Prompt_Val = 0;
            }

            else
            {
                cabin_Button_Prompt = true;
                cabin_Button_Prompt_Val = 1;
            }
        }

        if (PlayerPrefs.HasKey("current_Checkpoint"))
        {
            current_Checkpoint = (Current_Checkpoint)PlayerPrefs.GetInt("current_Checkpoint");
        }

        if (PlayerPrefs.HasKey("current_Level"))
        {
            local_Current_Level = (Current_Level)PlayerPrefs.GetInt("current_Level");
        }

        if (PlayerPrefs.HasKey("is_In_Cold_Area"))
        {
            is_In_Cold_Area = PlayerPrefs.GetInt("is_In_Cold_Area");

            if (is_In_Cold_Area == 1)
            {
                if (local_ColdEffectTrigger != null)
                {
                    local_ColdEffectTrigger.Initialise_Cold();
                }

            }

        }

        if (beginning_Play)
        {

            beginning_Play = false;
        }
        //StartCoroutine("Move_Solas");
        StartCoroutine("delay_Respawn");

        Reload_From_Last_checkpoint();
    }

    public void Player_In_Cold_Area_Toggle(bool state)
    {
        if (!state)
        {
            is_In_Cold_Area = 0;
            PlayerPrefs.SetInt("is_In_Cold_Area", 0);
        }

        else
        {
            is_In_Cold_Area = 1;
            PlayerPrefs.SetInt("is_In_Cold_Area", 1);
        }
    }


    public Current_Checkpoint current_Checkpoint;

    /// <summary>
    /// Initialises which campfire checkpoints have already been activated by the player and turns them on
    /// </summary>
    public void Turn_Campfires_On()
    {
        if (CAMPFIRE_HUB_1 != null && PlayerPrefs.GetInt("campfire_Hub_1") == 1)
        {
            CAMPFIRE_HUB_1.GetComponentInParent<Campfire_Manager>().Set_Light_On();
        }

        if (CAMPFIRE_HUB_2 != null && PlayerPrefs.GetInt("campfire_Hub_2") == 1)
        {
            CAMPFIRE_HUB_2.GetComponentInParent<Campfire_Manager>().Set_Light_On();
        }

        if (CAMPFIRE_ICE_1 != null && PlayerPrefs.GetInt("campfire_Ice_1") == 1)
        {
            CAMPFIRE_ICE_1.GetComponentInParent<Campfire_Manager>().Set_Light_On();
        }

        if (CAMPFIRE_ICE_2 != null && PlayerPrefs.GetInt("campfire_Ice_2") == 1)
        {
            CAMPFIRE_ICE_2.GetComponentInParent<Campfire_Manager>().Set_Light_On();
        }

        if (CAMPFIRE_MOUNTAIN_1 != null && PlayerPrefs.GetInt("campfire_Mountain_1") == 1)
        {
            CAMPFIRE_MOUNTAIN_1.GetComponentInParent<Campfire_Manager>().Set_Light_On();
            Player_In_Cold_Area_Toggle(false);
        }

        if (CAMPFIRE_MOUNTAIN_2 != null && PlayerPrefs.GetInt("campfire_Mountain_2") == 1)
        {
            CAMPFIRE_MOUNTAIN_2.GetComponentInParent<Campfire_Manager>().Set_Light_On();
            Player_In_Cold_Area_Toggle(true);
        }

        if (CAMPFIRE_MOUNTAIN_3 != null && PlayerPrefs.GetInt("campfire_Mountain_3") == 1)
        {
            CAMPFIRE_MOUNTAIN_3.GetComponentInParent<Campfire_Manager>().Set_Light_On();
            Player_In_Cold_Area_Toggle(true);
        }

        if (CAMPFIRE_MOUNTAIN_4 != null && PlayerPrefs.GetInt("campfire_Mountain_4") == 1)
        {
            CAMPFIRE_MOUNTAIN_4.GetComponentInParent<Campfire_Manager>().Set_Light_On();
            Player_In_Cold_Area_Toggle(true);
        }

        if (CAMPFIRE_MOUNTAIN_5 != null && PlayerPrefs.GetInt("campfire_Mountain_5") == 1)
        {
            CAMPFIRE_MOUNTAIN_5.GetComponentInParent<Campfire_Manager>().Set_Light_On();
            Player_In_Cold_Area_Toggle(true);
        }

        if (CAMPFIRE_MOUNTAIN_6 != null && PlayerPrefs.GetInt("campfire_Mountain_6") == 1)
        {
            CAMPFIRE_MOUNTAIN_6.GetComponentInParent<Campfire_Manager>().Set_Light_On();
            Player_In_Cold_Area_Toggle(true);
        }

        if (CAMPFIRE_MOUNTAIN_7 != null && PlayerPrefs.GetInt("campfire_Mountain_7") == 1)
        {
            CAMPFIRE_MOUNTAIN_7.GetComponentInParent<Campfire_Manager>().Set_Light_On();
            Player_In_Cold_Area_Toggle(false);
        }

        if (CAMPFIRE_TRAP_1 != null && PlayerPrefs.GetInt("campfire_Trap_1") == 1)
        {
            CAMPFIRE_TRAP_1.GetComponentInParent<Campfire_Manager>().Set_Light_On();
        }

        if (CAMPFIRE_TRAP_2 != null && PlayerPrefs.GetInt("campfire_Trap_2") == 1)
        {
            CAMPFIRE_TRAP_2.GetComponentInParent<Campfire_Manager>().Set_Light_On();
        }

        if (CAMPFIRE_TRAP_3 != null && PlayerPrefs.GetInt("campfire_Trap_3") == 1)
        {
            CAMPFIRE_TRAP_3.GetComponentInParent<Campfire_Manager>().Set_Light_On();
        }

        if (CAMPFIRE_TRAP_4 != null && PlayerPrefs.GetInt("campfire_Trap_4") == 1)
        {
            CAMPFIRE_TRAP_4.GetComponentInParent<Campfire_Manager>().Set_Light_On();
        }
    }

    public void Save_Data()
    {
        PlayerPrefs.SetInt("current_Checkpoint", (int)current_Checkpoint);
        PlayerPrefs.SetInt("current_Level", (int)local_Current_Level);
        PlayerPrefs.SetInt("campfire_Hub_1", campfire_Hub_1);
        PlayerPrefs.SetInt("campfire_Hub_2", campfire_Hub_2);
        PlayerPrefs.SetInt("campfire_Ice_1", campfire_Ice_1);
        PlayerPrefs.SetInt("campfire_Ice_2", campfire_Ice_2);
        PlayerPrefs.SetInt("campfire_Mountain_1", campfire_Mountain_1);
        PlayerPrefs.SetInt("campfire_Mountain_2", campfire_Mountain_2);
        PlayerPrefs.SetInt("campfire_Mountain_3", campfire_Mountain_3);
        PlayerPrefs.SetInt("campfire_Mountain_4", campfire_Mountain_4);
        PlayerPrefs.SetInt("campfire_Mountain_5", campfire_Mountain_5);
        PlayerPrefs.SetInt("campfire_Mountain_6", campfire_Mountain_6);
        PlayerPrefs.SetInt("campfire_Mountain_7", campfire_Mountain_7);
        PlayerPrefs.SetInt("campfire_Trap_1", campfire_Trap_1);
        PlayerPrefs.SetInt("campfire_Trap_2", campfire_Trap_2);
        PlayerPrefs.SetInt("campfire_Trap_3", campfire_Trap_3);
        PlayerPrefs.SetInt("campfire_Trap_4", campfire_Trap_4);
        PlayerPrefs.SetInt("is_In_Cold_Area", is_In_Cold_Area);
        PlayerPrefs.SetInt("cabin_Button_Prompt", cabin_Button_Prompt_Val);
    }



    /// <summary>
    /// Resets all of the player progress for campfires
    /// </summary>
    public void Reset_Data()
    {
        PlayerPrefs.SetInt("current_Checkpoint", 15);
        PlayerPrefs.SetInt("current_Level", 0);
        PlayerPrefs.SetInt("campfire_Hub_1", 0);
        PlayerPrefs.SetInt("campfire_Hub_2", 0);
        PlayerPrefs.SetInt("campfire_Ice_1", 0);
        PlayerPrefs.SetInt("campfire_Ice_2", 0);
        PlayerPrefs.SetInt("campfire_Mountain_1", 0);
        PlayerPrefs.SetInt("campfire_Mountain_2", 0);
        PlayerPrefs.SetInt("campfire_Mountain_3", 0);
        PlayerPrefs.SetInt("campfire_Mountain_4", 0);
        PlayerPrefs.SetInt("campfire_Mountain_5", 0);
        PlayerPrefs.SetInt("campfire_Mountain_6", 0);
        PlayerPrefs.SetInt("campfire_Mountain_7", 0);
        PlayerPrefs.SetInt("campfire_Trap_1", 0);
        PlayerPrefs.SetInt("campfire_Trap_2", 0);
        PlayerPrefs.SetInt("campfire_Trap_3", 0);
        PlayerPrefs.SetInt("campfire_Trap_4", 0);
        PlayerPrefs.SetInt("is_In_Cold_Area", 0);
        PlayerPrefs.SetInt("cabin_Button_Prompt", 1);
    }

    public void Reload_From_Last_checkpoint()
    {
        if (PlayerPrefs.HasKey("current_Checkpoint"))
        {
            current_Checkpoint = (Current_Checkpoint)PlayerPrefs.GetInt("current_Checkpoint");
        }

        Turn_Campfires_On();
        Move_Solas();



    }

    public IEnumerator delay_Respawn()
    {
        yield return new WaitForSeconds(.1f);
        Move_Solas();
    }

    /// <summary>
    /// move solas and the camera to the checkpoint transform when loading a new level
    /// </summary>
    public void Move_Solas()
    {
        if (!in_Cabin)
        {

            switch (current_Checkpoint)
            {
                case Current_Checkpoint.CAMPFIRE_HUB_1:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = CAMPFIRE_HUB_1.position;
                    player.transform.rotation = CAMPFIRE_HUB_1.rotation;
                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;

                    break;

                case Current_Checkpoint.CAMPFIRE_HUB_2:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = CAMPFIRE_HUB_2.position;
                    player.transform.rotation = CAMPFIRE_HUB_2.rotation;
                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    break;

                case Current_Checkpoint.CAMPFIRE_ICE_1:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = CAMPFIRE_ICE_1.position;
                    player.transform.rotation = CAMPFIRE_ICE_1.rotation;
                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    break;

                case Current_Checkpoint.CAMPFIRE_ICE_2:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = CAMPFIRE_ICE_2.position;
                    player.transform.rotation = CAMPFIRE_ICE_2.rotation;
                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    break;

                case Current_Checkpoint.CAMPFIRE_MOUNTAIN_1:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = CAMPFIRE_MOUNTAIN_1.position;
                    player.transform.rotation = CAMPFIRE_MOUNTAIN_1.rotation;
                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    break;

                case Current_Checkpoint.CAMPFIRE_MOUNTAIN_2:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = CAMPFIRE_MOUNTAIN_2.position;
                    player.transform.rotation = CAMPFIRE_MOUNTAIN_2.rotation;
                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    break;

                case Current_Checkpoint.CAMPFIRE_MOUNTAIN_3:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = CAMPFIRE_MOUNTAIN_3.position;
                    player.transform.rotation = CAMPFIRE_MOUNTAIN_3.rotation;
                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    break;

                case Current_Checkpoint.CAMPFIRE_MOUNTAIN_4:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = CAMPFIRE_MOUNTAIN_4.position;
                    player.transform.rotation = CAMPFIRE_MOUNTAIN_4.rotation;
                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    break;

                case Current_Checkpoint.CAMPFIRE_MOUNTAIN_5:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = CAMPFIRE_MOUNTAIN_5.position;
                    player.transform.rotation = CAMPFIRE_MOUNTAIN_5.rotation;
                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    break;

                case Current_Checkpoint.CAMPFIRE_MOUNTAIN_6:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = CAMPFIRE_MOUNTAIN_6.position;
                    player.transform.rotation = CAMPFIRE_MOUNTAIN_6.rotation;
                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    break;

                case Current_Checkpoint.CAMPFIRE_MOUNTAIN_7:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = CAMPFIRE_MOUNTAIN_7.position;
                    player.transform.rotation = CAMPFIRE_MOUNTAIN_7.rotation;
                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    break;

                case Current_Checkpoint.CAMPFIRE_TRAP_1:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = CAMPFIRE_TRAP_1.position;
                    player.transform.rotation = CAMPFIRE_TRAP_1.rotation;
                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    break;

                case Current_Checkpoint.CAMPFIRE_TRAP_2:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = CAMPFIRE_TRAP_2.position;
                    player.transform.rotation = CAMPFIRE_TRAP_2.rotation;
                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    break;

                case Current_Checkpoint.CAMPFIRE_TRAP_3:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = CAMPFIRE_TRAP_3.position;
                    player.transform.rotation = CAMPFIRE_TRAP_3.rotation;
                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    break;

                case Current_Checkpoint.CAMPFIRE_TRAP_4:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = CAMPFIRE_TRAP_4.position;
                    player.transform.rotation = CAMPFIRE_TRAP_4.rotation;
                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    break;

                case Current_Checkpoint.CABIN_INTERIOR:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    if (CABIN_INTERIOR != null)
                    {
                        player.transform.position = CABIN_INTERIOR.position;
                        player.transform.rotation = CABIN_INTERIOR.rotation;
                    }

                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    break;

                case Current_Checkpoint.ICE_START_AREA:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = ICE_START_AREA.position;
                    player.transform.rotation = ICE_START_AREA.rotation;
                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    break;

                case Current_Checkpoint.MOUNTAIN_START_AREA:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = MOUNTAIN_START_AREA.position;
                    player.transform.rotation = MOUNTAIN_START_AREA.rotation;
                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    break;

                case Current_Checkpoint.TRAP_START_AREA:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = TRAP_START_AREA.position;
                    player.transform.rotation = TRAP_START_AREA.rotation;
                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    break;

                case Current_Checkpoint.ICE_TEMPLE_START:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = ICE_TEMPLE_START.position;
                    player.transform.rotation = ICE_TEMPLE_START.rotation;
                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    break;

                case Current_Checkpoint.FIRE_TEMPLE_START:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = FIRE_TEMPLE_START.position;
                    player.transform.rotation = FIRE_TEMPLE_START.rotation;
                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    break;

                case Current_Checkpoint.MOUNTAIN_TEMPLE_START:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = MOUNTAIN_TEMPLE_START.position;
                    player.transform.rotation = MOUNTAIN_TEMPLE_START.rotation;
                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    break;

                case Current_Checkpoint.TRAP_TEMPLE_START:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = TRAP_TEMPLE_START.position;
                    player.transform.rotation = TRAP_TEMPLE_START.rotation;
                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    break;

                case Current_Checkpoint.HUB_AREA_CABIN_EXIT:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = HUB_AREA_CABIN_EXIT.position;
                    player.transform.rotation = HUB_AREA_CABIN_EXIT.rotation;
                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    break;

                case Current_Checkpoint.HUB_AREA_TRAP_EXIT:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = HUB_AREA_TRAP_EXIT.position;
                    player.transform.rotation = HUB_AREA_TRAP_EXIT.rotation;
                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    break;

                case Current_Checkpoint.HUB_AREA_MOUNTAIN_EXIT:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = HUB_AREA_MOUNTAIN_EXIT.position;
                    player.transform.rotation = HUB_AREA_MOUNTAIN_EXIT.rotation;
                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    break;

                case Current_Checkpoint.HUB_AREA_ICE_EXIT:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = HUB_AREA_ICE_EXIT.position;
                    player.transform.rotation = HUB_AREA_ICE_EXIT.rotation;
                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    break;

                case Current_Checkpoint.FINAL_TEMPLE_START:
                    player.GetComponent<NavMeshAgent>().enabled = false;
                    player.transform.position = FINAL_TEMPLE_START.position;
                    player.transform.rotation = FINAL_TEMPLE_START.rotation;
                    main_Camera.transform.position = player.transform.position;
                    player.GetComponent<NavMeshAgent>().enabled = true;
                    break;


            }
        }

    }
}
