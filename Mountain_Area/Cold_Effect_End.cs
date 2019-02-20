using UnityEngine;

public class Cold_Effect_End : MonoBehaviour
{


    public Player_Light_Manager local_Player_Light_Manager;
    public Mountain_Area_Temperature_Manager local_Mountain_Area_Temperature_Manager;


    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            local_Player_Light_Manager.StopAllCoroutines();
            local_Mountain_Area_Temperature_Manager.StopAllCoroutines();
            local_Player_Light_Manager.enabled = false;
            local_Mountain_Area_Temperature_Manager.Stop_Pulsing();
            local_Mountain_Area_Temperature_Manager.Restore_Temperature();
        }
    }
}
