using System.Collections;
using UnityEngine;

public class Intro_Scene_Manager : MonoBehaviour
{

    public GameObject still1;
    public GameObject still2;
    public GameObject still3;
    public Scene_Management local_Scene_Management;
    public Fade_To_Black local_Fade_To_Black;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("Play_Stills");
    }

    /// <summary>
    /// Plays each still storyboard image and pauses between each
    /// </summary>
    /// <returns></returns>
    IEnumerator Play_Stills()
    {
        yield return new WaitForSeconds(5f);
        local_Fade_To_Black.Fade_Out();
        yield return new WaitForSeconds(1f);
        still3.SetActive(false);
        local_Fade_To_Black.Fade_In_From_Black();
        yield return new WaitForSeconds(3f);

        local_Fade_To_Black.Fade_Out();
        yield return new WaitForSeconds(3f);
        still1.SetActive(false);
        local_Fade_To_Black.Fade_In_From_Black();
        yield return new WaitForSeconds(4f);

        local_Fade_To_Black.Fade_Out();
        yield return new WaitForSeconds(6f);
        local_Scene_Management.Load_Cabin_Area();

    }
}
