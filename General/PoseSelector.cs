using UnityEngine;

public class PoseSelector : MonoBehaviour
{

    public string animTrigger;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        anim.SetTrigger(animTrigger);
    }
}
