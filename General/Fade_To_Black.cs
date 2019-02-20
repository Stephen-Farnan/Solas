using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade_To_Black : MonoBehaviour
{

    public Image fade_Panel;

    private void Start()
    {
        fade_Panel.enabled = true;

        StartCoroutine("Fade_In");
    }

    public void Fade_In_From_Black()
    {
        StartCoroutine("Fade_In");
    }

    IEnumerator Fade_In()
    {
        yield return new WaitForSeconds(0.5f);
        Color temp_Colour = fade_Panel.color;
        while (fade_Panel.color.a > 0)
        {

            temp_Colour.a -= Time.deltaTime;
            fade_Panel.color = temp_Colour;
            yield return null;
        }

        yield return null;
    }

    public void Fade_Out()
    {
        StartCoroutine("Fade_Over_Time");
    }

    IEnumerator Fade_Over_Time()
    {

        Color temp_Colour = fade_Panel.color;
        while (fade_Panel.color.a < 255)
        {

            temp_Colour.a += Time.deltaTime;
            fade_Panel.color = temp_Colour;
            yield return null;
        }

        yield return null;
    }
}


