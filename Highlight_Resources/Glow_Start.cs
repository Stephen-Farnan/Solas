using System.Collections;
using UnityEngine;

public class Glow_Start : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine("Wait");
    }


    IEnumerator Wait()
    {
        gameObject.GetComponent<GlowPrePass>().enabled = false;
        yield return new WaitForSeconds(.2f);
        gameObject.GetComponent<GlowPrePass>().enabled = true;
    }
}
