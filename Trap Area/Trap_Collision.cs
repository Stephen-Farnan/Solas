using System.Collections;
using UnityEngine;

public class Trap_Collision : MonoBehaviour
{
    //[HideInInspector]
    public bool is_Live = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && is_Live)
        {
            other.transform.position = transform.position + new Vector3(0, 1.2f, 0);
            other.transform.rotation = transform.rotation;
            other.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Bear Trap");
            //StartCoroutine(KillPlayer(other.gameObject.GetComponent<Player_Manager>()));
            other.gameObject.GetComponent<Player_Manager>().Kill_Player();
        }

        if (other.gameObject.tag == "Trap_Destination")
        {
            is_Live = false;
        }
    }

    IEnumerator KillPlayer(Player_Manager pm)
    {
        yield return new WaitForSeconds(2);

        pm.Kill_Player();
    }
}
