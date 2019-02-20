using System.Collections;
using UnityEngine;

public class ColdEffectTrigger : MonoBehaviour
{

    public Animator anim;

    public Player_Light_Manager local_Player_Light_Manager;
    public Mountain_Area_Temperature_Manager local_Mountain_Area_Temperature_Manager;
    public Player_Location_Tracking local_Player_Location_Tracking;

    void Start()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Initialise_Cold();
            local_Player_Location_Tracking.Save_Data();
            PlayerPrefs.Save();
        }
    }

    public void Shiver()
    {
        anim.SetBool("Shiver", true);
        StartCoroutine(WaitForEnd());
    }

    IEnumerator WaitForEnd()
    {
        yield return new WaitForSeconds(3.0f);
        anim.SetBool("Shiver", false);
    }

    public void Initialise_Cold()
    {
        Shiver();
        local_Player_Light_Manager.enabled = true;
        local_Mountain_Area_Temperature_Manager.enabled = true;
        local_Player_Light_Manager.StartCoroutine("Lower_Light_Value");
    }
}
