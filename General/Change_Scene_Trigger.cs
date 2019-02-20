using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Fade_To_Black))]
public class Change_Scene_Trigger : MonoBehaviour
{

    private Scene_Management_Singleton sceneManagement;
    public CharacterAnimationController charAnim;
    public Transform navTarget;
    public string sceneToLoad;
    private Fade_To_Black fade;

    public Player_Location_Tracking local_Player_Location_Tracking;
    public enum Scene_Locations
    {
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

    public Scene_Locations local_Scene_Locations;

    void Start()
    {
        fade = GetComponent<Fade_To_Black>();
        sceneManagement = GameObject.FindWithTag("Scene_Manager").GetComponent<Scene_Management_Singleton>();
    }

    void OnTriggerEnter()
    {
        StartCoroutine(MoveToNewScene());
    }

    private IEnumerator MoveToNewScene()
    {
        charAnim.charController.canMove = false;
        if (navTarget != null)
        {
            charAnim.navAgent.SetDestination(navTarget.position);
            yield return null;
            charAnim.anim.SetBool("Run", true);
        }
        StartCoroutine(LoadNewScene());
    }

    public IEnumerator LoadNewScene()
    {
        if (navTarget != null)
        {
            yield return new WaitForSeconds(1.8f);
        }
        if (local_Player_Location_Tracking != null)
        {
            Set_New_Checkpoint();
        }

        fade.Fade_Out();
        yield return new WaitForSeconds(1.5f);
        sceneManagement.Load_Scene(sceneToLoad);
    }

    /// <summary>
    /// Updates and saves the current level, and position of the player and saves it as a checkpoint
    /// </summary>
    public void Set_New_Checkpoint()
    {
        switch (local_Scene_Locations)
        {
            case Scene_Locations.CABIN_INTERIOR:
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.CABIN_INTERIOR;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.CABIN;
                break;

            case Scene_Locations.ICE_START_AREA:
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.ICE_START_AREA;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.ICE_AREA;
                break;

            case Scene_Locations.MOUNTAIN_START_AREA:
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.MOUNTAIN_START_AREA;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.MOUNTAIN_AREA;
                break;

            case Scene_Locations.TRAP_START_AREA:
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.TRAP_START_AREA;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.TRAP_AREA;
                break;

            case Scene_Locations.ICE_TEMPLE_START:
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.ICE_TEMPLE_START;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.ICE_TEMPLE;
                break;

            case Scene_Locations.FIRE_TEMPLE_START:
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.FIRE_TEMPLE_START;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.TUTORIAL_TEMPLE;
                break;

            case Scene_Locations.MOUNTAIN_TEMPLE_START:
                local_Player_Location_Tracking.Player_In_Cold_Area_Toggle(false);
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.MOUNTAIN_TEMPLE_START;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.WIND_TEMPLE;
                break;

            case Scene_Locations.TRAP_TEMPLE_START:
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.TRAP_TEMPLE_START;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.TRAP_TEMPLE;
                break;

            case Scene_Locations.HUB_AREA_CABIN_EXIT:
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.HUB_AREA_CABIN_EXIT;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.HUB;
                break;

            case Scene_Locations.HUB_AREA_TRAP_EXIT:
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.HUB_AREA_TRAP_EXIT;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.HUB;
                break;

            case Scene_Locations.HUB_AREA_MOUNTAIN_EXIT:
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.HUB_AREA_MOUNTAIN_EXIT;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.HUB;
                break;

            case Scene_Locations.HUB_AREA_ICE_EXIT:
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.HUB_AREA_ICE_EXIT;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.HUB;
                break;

            case Scene_Locations.FINAL_TEMPLE_START:
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.FINAL_TEMPLE_START;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.FINAL_TEMPLE;
                break;
        }

        local_Player_Location_Tracking.Save_Data();

    }
}
