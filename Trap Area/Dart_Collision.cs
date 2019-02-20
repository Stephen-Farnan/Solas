using UnityEngine;

public class Dart_Collision : MonoBehaviour
{

    public Trap_Triggers local_Trap_Triggers;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Dart Trap");
            other.gameObject.GetComponent<Player_Manager>().Kill_Player();
        }
        if (other.gameObject.tag == "Trap_Destination")
        {
            local_Trap_Triggers.Stop_Dart();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
