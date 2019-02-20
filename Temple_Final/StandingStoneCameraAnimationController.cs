using UnityEngine;

public class StandingStoneCameraAnimationController : MonoBehaviour
{

    [HideInInspector]
    public bool isFinal = false;

    void Fade()
    {
        if (!isFinal)
        {
            GetComponent<Fade_To_Black>().Fade_Out();
        }
    }

    void ActivateFinalAnimation()
    {
        if (isFinal)
        {
            GetComponent<Animator>().SetTrigger("Final");
        }
    }
}
