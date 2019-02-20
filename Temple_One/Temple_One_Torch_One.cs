using System.Collections;
using UnityEngine;

public class Temple_One_Torch_One : MonoBehaviour
{
    public Temple_One_Puzzle_One local_Temple_One_Puzzle_One;

    public ParticleSystem fire_Particles;
    public Light fire_Light;
    public AudioSource fire_Startup;
    public AudioSource fire_Constant;

    public Transform playerAnimationSpot;

    private ProgressManager progMan;

    bool activated = false;

    void Start()
    {
        progMan = GameObject.FindWithTag("Scene_Manager").GetComponent<ProgressManager>();
        if (progMan.noOfTemplesCompleted != 0)
        {
            gameObject.SetActive(false);
        }
    }

    public bool Interact_With()
    {
        if (!activated)
        {
            StartCoroutine("Turn_On_Torches");
            activated = true;
            local_Temple_One_Puzzle_One.torch_One_Is_Lit = true;
            local_Temple_One_Puzzle_One.Check_Puzzle_Is_Solved();

            StartCoroutine(GameObject.FindWithTag("Player").transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(playerAnimationSpot, "Light Fire", true));

            return true;
        }

        else
        {
            return false;
        }
    }

    IEnumerator Turn_On_Torches()
    {
        yield return new WaitForSeconds(local_Temple_One_Puzzle_One.torch_Light_Delay);
        fire_Particles.Play();
        fire_Light.enabled = true;
        fire_Startup.Play();
        fire_Constant.Play();
    }
}
