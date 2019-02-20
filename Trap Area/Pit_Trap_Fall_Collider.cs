using UnityEngine;
using UnityEngine.AI;

public class Pit_Trap_Fall_Collider : MonoBehaviour
{


    public NavMeshAgent local_NavMeshAgent;
    public Collider player_Collider;
    public Player_Manager local_Player_manager;
    public Animator anim;

    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;
    public GameObject six;
    public GameObject seven;
    public GameObject eight;
    public GameObject camera_Target;

    bool is_Inside_Trap = false;

    public Trap_Triggers local_Trap_Triggers;

    public void Fall_Through_Pit()
    {
        one.SetActive(false);
        two.SetActive(false);
        three.SetActive(false);
        four.SetActive(false);
        five.SetActive(false);
        six.SetActive(false);
        seven.SetActive(false);
        eight.SetActive(false);
        camera_Target.SetActive(false);
        local_NavMeshAgent.enabled = false;
        player_Collider.enabled = false;
        local_Player_manager.Kill_Player();
        anim.SetTrigger("Pit Trap");
        //play particle effect to hide solas clipping through the ground here
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            is_Inside_Trap = true;
        }

        if (other.gameObject.tag == "Player" && local_Trap_Triggers.is_Triggered)
        {
            Fall_Through_Pit();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            is_Inside_Trap = false;
        }
    }

    public void Check_Will_Solas_Fall()
    {
        if (is_Inside_Trap)
        {
            Fall_Through_Pit();
        }
    }


}
