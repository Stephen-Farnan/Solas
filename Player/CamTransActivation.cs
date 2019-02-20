using UnityEngine;

public class CamTransActivation : MonoBehaviour
{

    private CameraTransition camTrans;

    void Start()
    {
        camTrans = this.gameObject.GetComponent<CameraTransition>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            camTrans.enabled = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            camTrans.enabled = false;
        }
    }
}
