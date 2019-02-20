using UnityEngine;

public class FinalTempleStoneActivation : MonoBehaviour
{

    [HideInInspector]
    public int stoneToActivate = 1;
    public Animator cameraAnim;
    public Animator[] stoneAnim;

    void Start()
    {
        cameraAnim.SetTrigger(stoneToActivate.ToString());
    }

    void PlayStoneAnimation()
    {
        stoneAnim[stoneToActivate].SetTrigger("Orb");
    }
}
