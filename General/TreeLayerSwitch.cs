using UnityEngine;

public class TreeLayerSwitch : MonoBehaviour
{

    private int defaultLayer = 0;
    private int ignoreRaycastLayer = 2;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.layer = ignoreRaycastLayer;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.layer = defaultLayer;
        }
    }
}
