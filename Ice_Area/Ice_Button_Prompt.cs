using System.Collections;
using UnityEngine;

public class Ice_Button_Prompt : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (!triggered)
        {
            StartCoroutine("Turn_Off_Prompt");
        }

    }

    bool triggered = false;

    public GameObject buttons_prompts;

    IEnumerator Turn_Off_Prompt()
    {
        buttons_prompts.SetActive(true);
        triggered = true;
        yield return new WaitForSeconds(4f);
        buttons_prompts.SetActive(false);
    }
}
