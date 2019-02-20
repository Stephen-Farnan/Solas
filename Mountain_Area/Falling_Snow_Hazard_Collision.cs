using UnityEngine;

public class Falling_Snow_Hazard_Collision : MonoBehaviour
{

    public Falling_Snow_Hazard_Manager local_Falling_Snow_Hazard_Manager;

    bool has_Been_Triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !has_Been_Triggered)
        {
            local_Falling_Snow_Hazard_Manager.Drop_Snow();
            has_Been_Triggered = true;
        }
    }
}
