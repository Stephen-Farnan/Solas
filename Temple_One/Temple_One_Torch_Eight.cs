using System.Collections;
using UnityEngine;

public class Temple_One_Torch_Eight : MonoBehaviour
{

    public Temple_One_Puzzle_Three local_Temple_One_Puzzle_Three;
    public ParticleSystem fire_Particles;
    public Light fire_Light;
    public AudioSource fire_Startup;
    public AudioSource fire_Constant;

    public Transform playerAnimationSpot;

    public bool activated = false;

    public bool Interact_With()
    {
        if (!activated)
        {
            StartCoroutine("Turn_On_Torches");
            activated = true;
            local_Temple_One_Puzzle_Three.torch_Eight_Is_Lit = true;
            local_Temple_One_Puzzle_Three.Check_Puzzle_Is_Solved(2);

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
        yield return new WaitForSeconds(local_Temple_One_Puzzle_Three.torch_Light_Delay);
        fire_Particles.Play();
        fire_Light.enabled = true;
        fire_Startup.Play();
        fire_Constant.Play();
    }

    public void Reset_Torch()
    {
        fire_Light.enabled = false;
        fire_Particles.Stop();
        activated = false;
        fire_Constant.Stop();
    }
}

