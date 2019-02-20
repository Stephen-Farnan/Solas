using System.Collections;
using UnityEngine;

public class Campfire_Manager : MonoBehaviour
{

    public Player_Light_Manager local_Player_Light_Manager;
    public Player_Location_Tracking local_Player_Location_Tracking;

    public Light fire_Light;
    public ParticleSystem local_Fire_Particles;

    public Mountain_Area_Temperature_Manager local_Mountain_Area_Temperature_Manager;

    public AudioSource fire_Lighting;
    public AudioSource fire_Constant_Burning;

    bool is_Lit = false;

    public Transform playerAnimationSpot;


    public enum campfire_number
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
    }

    public campfire_number local_Campfire_Number;


    /// <summary>
    /// Calls the function to restore light to the player torch and moves the character in position for the animation
    /// </summary>
    public void Interact_With()
    {
        StartCoroutine("Delay_Restoring_Light");
        StartCoroutine(GameObject.FindWithTag("Player").transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(playerAnimationSpot, "Campfire", true));

    }

    /// <summary>
    /// Increases the torch brightness over time
    /// </summary>
    /// <returns></returns>
    IEnumerator Delay_Restoring_Light()
    {
        yield return new WaitForSeconds(2.5f);
        local_Player_Light_Manager.Restore_Light();

        switch (local_Campfire_Number)
        {
            case campfire_number.CAMPFIRE_HUB_1:
                local_Player_Location_Tracking.campfire_Hub_1 = 1;
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.CAMPFIRE_HUB_1;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.HUB;

                break;

            case campfire_number.CAMPFIRE_HUB_2:
                local_Player_Location_Tracking.campfire_Hub_2 = 1;
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.CAMPFIRE_HUB_2;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.HUB;
                break;

            case campfire_number.CAMPFIRE_ICE_1:
                local_Player_Location_Tracking.campfire_Ice_1 = 1;
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.CAMPFIRE_ICE_1;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.ICE_AREA;
                break;

            case campfire_number.CAMPFIRE_ICE_2:
                local_Player_Location_Tracking.campfire_Ice_2 = 1;
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.CAMPFIRE_ICE_2;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.ICE_AREA;
                break;

            case campfire_number.CAMPFIRE_MOUNTAIN_1:
                local_Player_Location_Tracking.campfire_Mountain_1 = 1;
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.CAMPFIRE_MOUNTAIN_1;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.MOUNTAIN_AREA;
                local_Player_Location_Tracking.is_In_Cold_Area = 1;
                break;

            case campfire_number.CAMPFIRE_MOUNTAIN_2:
                local_Player_Location_Tracking.campfire_Mountain_2 = 1;
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.CAMPFIRE_MOUNTAIN_2;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.MOUNTAIN_AREA;
                local_Player_Location_Tracking.is_In_Cold_Area = 1;
                break;

            case campfire_number.CAMPFIRE_MOUNTAIN_3:
                local_Player_Location_Tracking.campfire_Mountain_3 = 1;
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.CAMPFIRE_MOUNTAIN_3;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.MOUNTAIN_AREA;
                local_Player_Location_Tracking.is_In_Cold_Area = 1;
                break;

            case campfire_number.CAMPFIRE_MOUNTAIN_4:
                local_Player_Location_Tracking.campfire_Mountain_4 = 1;
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.CAMPFIRE_MOUNTAIN_4;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.MOUNTAIN_AREA;
                local_Player_Location_Tracking.is_In_Cold_Area = 1;
                break;

            case campfire_number.CAMPFIRE_MOUNTAIN_5:
                local_Player_Location_Tracking.campfire_Mountain_5 = 1;
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.CAMPFIRE_MOUNTAIN_5;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.MOUNTAIN_AREA;
                local_Player_Location_Tracking.is_In_Cold_Area = 1;
                break;

            case campfire_number.CAMPFIRE_MOUNTAIN_6:
                local_Player_Location_Tracking.campfire_Mountain_6 = 1;
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.CAMPFIRE_MOUNTAIN_6;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.MOUNTAIN_AREA;
                local_Player_Location_Tracking.is_In_Cold_Area = 1;
                break;

            case campfire_number.CAMPFIRE_MOUNTAIN_7:
                local_Player_Location_Tracking.campfire_Mountain_7 = 1;
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.CAMPFIRE_MOUNTAIN_7;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.MOUNTAIN_AREA;
                local_Player_Location_Tracking.is_In_Cold_Area = 1;
                break;

            case campfire_number.CAMPFIRE_TRAP_1:
                local_Player_Location_Tracking.campfire_Trap_1 = 1;
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.CAMPFIRE_TRAP_1;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.TRAP_AREA;
                break;

            case campfire_number.CAMPFIRE_TRAP_2:
                local_Player_Location_Tracking.campfire_Trap_2 = 1;
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.CAMPFIRE_TRAP_2;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.TRAP_AREA;
                break;

            case campfire_number.CAMPFIRE_TRAP_3:
                local_Player_Location_Tracking.campfire_Trap_3 = 1;
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.CAMPFIRE_TRAP_3;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.TRAP_AREA;
                break;

            case campfire_number.CAMPFIRE_TRAP_4:
                local_Player_Location_Tracking.campfire_Trap_4 = 1;
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.CAMPFIRE_TRAP_4;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.TRAP_AREA;
                break;
        }

        local_Player_Location_Tracking.Save_Data();
        PlayerPrefs.Save();

        if (local_Mountain_Area_Temperature_Manager != null)
        {
            if (local_Mountain_Area_Temperature_Manager.enabled)
            {
                local_Mountain_Area_Temperature_Manager.StopCoroutine("Change_Temperature_Over_Time");
                local_Mountain_Area_Temperature_Manager.StopAllCoroutines();
                local_Mountain_Area_Temperature_Manager.Restore_Temperature();
                local_Mountain_Area_Temperature_Manager.StopCoroutine("Countdown_To_Player_Death");
                local_Mountain_Area_Temperature_Manager.Stop_Pulsing();
                local_Mountain_Area_Temperature_Manager.StartCoroutine("Change_Temperature_Over_Time");
            }



            Color tempColor = new Color(local_Mountain_Area_Temperature_Manager.screen_Cover_Effect.color.r, local_Mountain_Area_Temperature_Manager.screen_Cover_Effect.color.g, local_Mountain_Area_Temperature_Manager.screen_Cover_Effect.color.b, 0f);
            local_Mountain_Area_Temperature_Manager.screen_Cover_Effect.color = tempColor;
            yield return new WaitForSeconds(.5f);
            //
        }

        if (!is_Lit)
        {
            local_Fire_Particles.Play();
            fire_Constant_Burning.Play();
            fire_Lighting.Play();
            fire_Light.enabled = true;
            is_Lit = true;
        }
    }

    /// <summary>
    /// Lights up the campfire and starts playing sfx and vfx
    /// </summary>
    public void Set_Light_On()
    {
        is_Lit = true;
        fire_Light.enabled = true;
        local_Fire_Particles.Play();
        fire_Constant_Burning.Play();
    }
}
