using System.Collections;
using UnityEngine;

public class Temple_One_Puzzle_Two : MonoBehaviour
{
    bool puzzle_Solved = false;
    public bool torches_Lit_In_Right_Order = true;
    public bool torch_Three_Is_Lit;
    public bool torch_Four_Is_Lit;
    public bool torch_Five_Is_Lit;
    public bool torch_Six_Is_Lit;
    int next_Torch_To_Be_Lit = 1;
    public float torch_Light_Delay = .6f;
    public float time_Delay_To_Reset_Lights = .5f;
    //    float movement_Smoothing = .03f;
    //    float door_Speed = 4f;

    public Temple_One_Torch_Three local_Temple_One_Torch_Three;
    public Temple_One_Torch_Four local_Temple_One_Torch_Four;
    public Temple_One_Torch_Five local_Temple_One_Torch_Five;
    public Temple_One_Torch_Six local_Temple_One_Torch_Six;
    public GameObject temple_Door;
    public AudioSource door_Opening_Sound;
    public AudioSource torch_Whoosh_Sound;


    private CameraTransition camTrans;
    [Space]
    public ParticleSystem[] door_Rubble_Particles;

    private Player_Interaction playInt;
    public Transform resetAnimationSpot;

    void Start()
    {
        camTrans = GameObject.Find("Door Camera Position 1").GetComponent<CameraTransition>();
        playInt = GameObject.FindWithTag("Player").GetComponent<Player_Interaction>();
    }

    public void Check_Puzzle_Is_Solved(int i)
    {
        if (!puzzle_Solved)
        {
            switch (i)
            {
                case 1:
                    if (next_Torch_To_Be_Lit == 1)
                    {
                        next_Torch_To_Be_Lit = 2;
                    }

                    else
                    {
                        torches_Lit_In_Right_Order = false;
                    }
                    break;

                case 2:
                    if (next_Torch_To_Be_Lit == 2)
                    {
                        next_Torch_To_Be_Lit = 3;
                    }

                    else
                    {
                        torches_Lit_In_Right_Order = false;
                    }
                    break;

                case 3:
                    if (next_Torch_To_Be_Lit == 3)
                    {
                        next_Torch_To_Be_Lit = 4;
                    }

                    else
                    {
                        torches_Lit_In_Right_Order = false;
                    }
                    break;

                case 4:
                    if (next_Torch_To_Be_Lit != 4)
                    {
                        torches_Lit_In_Right_Order = false;
                    }
                    break;

                default:
                    break;
            }



            if (torch_Three_Is_Lit && torch_Four_Is_Lit && torch_Five_Is_Lit && torch_Six_Is_Lit)
            {
                if (torches_Lit_In_Right_Order)
                {
                    puzzle_Solved = true;
                    StartCoroutine("Open_Door");
                }

                else
                {
                    StartCoroutine("Reset_Puzzle", false);
                }

            }

        }


    }


    IEnumerator Open_Door()
    {
        camTrans.enabled = true;
        yield return new WaitForSeconds(5.8f);
        camTrans.MoveToNewPosition();

        yield return new WaitForSeconds(camTrans.smoothTime + 0.6f);

        //start playing sound
        door_Opening_Sound.Play();
        temple_Door.GetComponent<Animator>().SetTrigger("Open");
        for (int i = 0; i < door_Rubble_Particles.Length - 1; i++)
        {
            door_Rubble_Particles[i].Play();
        }

        yield return new WaitForSeconds(4.0f);

        for (int i = 0; i < door_Rubble_Particles.Length - 1; i++)
        {
            door_Rubble_Particles[i].Stop();
        }
        camTrans.MoveToOldPosition();

        yield return new WaitForSeconds(camTrans.smoothTime);

        camTrans.enabled = false;
        playInt.can_Interact = true;

        door_Opening_Sound.Stop();
        //stop playing sound

    }

    public IEnumerator Reset_Puzzle(bool pulling_Lever)
    {
        if (pulling_Lever)
        {
            StartCoroutine(GameObject.FindWithTag("Player").transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(resetAnimationSpot, "Pull Lever", true));
        }

        yield return new WaitForSeconds(torch_Light_Delay + time_Delay_To_Reset_Lights);
        torch_Three_Is_Lit = false;
        torch_Four_Is_Lit = false;
        torch_Five_Is_Lit = false;
        torch_Six_Is_Lit = false;

        local_Temple_One_Torch_Three.Reset_Torch();
        local_Temple_One_Torch_Four.Reset_Torch();
        local_Temple_One_Torch_Five.Reset_Torch();
        local_Temple_One_Torch_Six.Reset_Torch();

        torch_Whoosh_Sound.Play();

        torches_Lit_In_Right_Order = true;
        next_Torch_To_Be_Lit = 1;
    }
}
