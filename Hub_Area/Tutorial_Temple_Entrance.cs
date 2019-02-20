using System.Collections;
using UnityEngine;

public class Tutorial_Temple_Entrance : MonoBehaviour
{

    private Scene_Management local_Scene_Management;
    public Fade_To_Black local_Fade_To_Black;
    public ThirdPerson3D thirdPerson3D;
    public Player_Location_Tracking local_Player_Location_Tracking;

    // Use this for initialization
    void Start()
    {

        local_Scene_Management = GameObject.FindGameObjectWithTag("Scene_Manager").GetComponent<Scene_Management>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("Exit_Level");
        }
    }

    IEnumerator Exit_Level()
    {
        local_Fade_To_Black.Fade_Out();
        thirdPerson3D.canMove = false;
        local_Player_Location_Tracking.local_Current_Level = Player_Location_Tracking.Current_Level.TUTORIAL_TEMPLE;
        local_Player_Location_Tracking.current_Checkpoint = Player_Location_Tracking.Current_Checkpoint.FIRE_TEMPLE_START;
        local_Player_Location_Tracking.Save_Data();
        yield return new WaitForSeconds(1.5f);
        local_Scene_Management.Load_Temple_One();
    }
}
