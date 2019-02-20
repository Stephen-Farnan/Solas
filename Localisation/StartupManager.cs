using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupManager : MonoBehaviour
{

    private IEnumerator Start()
    {
        while (!LocalisationManager.instance.GetIsReady())
        {
            yield return null;
        }
        SceneManager.LoadScene("Loc Start Menu");
    }
}
