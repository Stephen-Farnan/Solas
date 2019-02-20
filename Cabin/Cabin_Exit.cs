using System.Collections;
using UnityEngine;

public class Cabin_Exit : MonoBehaviour
{

    private Scene_Management_Singleton local_Scene_Management;
    public Player_Location_Tracking local_Player_Location_Tracking;
    public Fade_To_Black local_Fade_To_Black;
    public AudioSource doorAudioSource;
    public GameObject button_Prompt;
    public string sceneToLoad;

    public bool outside = false;

    private void Start()
    {
        local_Scene_Management = GameObject.FindGameObjectWithTag("Scene_Manager").GetComponent<Scene_Management_Singleton>();
        if (button_Prompt != null)
        {
            if (local_Player_Location_Tracking.cabin_Button_Prompt == false)
            {
                button_Prompt.SetActive(false);
                local_Player_Location_Tracking.Save_Data();
            }

        }

    }

    /// <summary>
    /// Sets up the player position upon exiting the cabin and saves the new position
    /// </summary>
    public void Exit_Cabin()
    {
        if (local_Player_Location_Tracking != null)
        {
            if (button_Prompt != null)
            {
                local_Player_Location_Tracking.cabin_Button_Prompt = false;
                local_Player_Location_Tracking.cabin_Button_Prompt_Val = 0;
            }
            if (outside == false)
            {
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.HUB_AREA_CABIN_EXIT;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.HUB;
            }

            else
            {
                local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.CABIN_INTERIOR;
                local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.CABIN;
            }

            local_Player_Location_Tracking.Save_Data();
        }

        StartCoroutine("Fade_Over_Time");

    }

    /// <summary>
    /// Screen fade upon leaving the cabin
    /// </summary>
    /// <returns></returns>
    IEnumerator Fade_Over_Time()
    {
        local_Fade_To_Black.Fade_Out();
        doorAudioSource.Play();
        yield return new WaitForSeconds(1.5f);
        local_Scene_Management.Load_Scene(sceneToLoad);
    }
}
