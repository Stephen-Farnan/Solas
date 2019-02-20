using System.Collections;
using UnityEngine;

public class Temple_One_Puzzle_Three : MonoBehaviour
{


    bool puzzle_Solved = false;
    public bool torches_Lit_In_Right_Order = true;
    public bool torch_Seven_Is_Lit;
    public bool torch_Eight_Is_Lit;
    public bool torch_Nine_Is_Lit;
    public bool torch_Ten_Is_Lit;
    int next_Torch_To_Be_Lit = 1;
    public float torch_Light_Delay = .6f;
    public float time_Delay_To_Reset_Lights = .5f;

    public Temple_One_Torch_Seven local_Temple_One_Torch_Seven;
    public Temple_One_Torch_Eight local_Temple_One_Torch_Eight;
    public Temple_One_Torch_Nine local_Temple_One_Torch_Nine;
    public Temple_One_Torch_Ten local_Temple_One_Torch_Ten;


    public GameObject local_Scene_Management;

    private CameraTransition camTrans;

    public AudioSource torch_Whoosh_Sound;

    public Fade_To_Black local_Fade_To_Black;

    public Transform resetAnimationSpot;

    void Start()
    {
        camTrans = GameObject.Find("Temple Complete Camera Position").GetComponent<CameraTransition>();
        local_Scene_Management = GameObject.FindWithTag("Scene_Manager");
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



            if (torch_Seven_Is_Lit && torch_Eight_Is_Lit && torch_Nine_Is_Lit && torch_Ten_Is_Lit)
            {
                if (torches_Lit_In_Right_Order)
                {
                    puzzle_Solved = true;
                    StartCoroutine("Puzzle_Solved");

                }

                else
                {
                    StartCoroutine("Reset_Puzzle", false);
                }

            }

        }


    }

    IEnumerator Puzzle_Solved()
    {
        camTrans.enabled = true;
        yield return new WaitForSeconds(5.8f);
        camTrans.MoveToNewPosition();
        yield return new WaitForSeconds(3f);
        //local_Fade_To_Black.Fade_Out();
        local_Scene_Management.GetComponent<ProgressManager>().TempleCompleted(0);
        StartCoroutine(GetComponent<Change_Scene_Trigger>().LoadNewScene());
        //yield return new WaitForSeconds(1.5f);
        //local_Scene_Management.Load_Scene("Hub Scene");
    }

    public IEnumerator Reset_Puzzle(bool pulling_Lever)
    {
        if (pulling_Lever)
        {
            StartCoroutine(GameObject.FindWithTag("Player").transform.GetChild(0).GetComponent<CharacterAnimationController>().MoveToPosition(resetAnimationSpot, "Pull Lever", true));
        }

        yield return new WaitForSeconds(torch_Light_Delay + time_Delay_To_Reset_Lights);
        torch_Seven_Is_Lit = false;
        torch_Eight_Is_Lit = false;
        torch_Nine_Is_Lit = false;
        torch_Ten_Is_Lit = false;

        local_Temple_One_Torch_Seven.Reset_Torch();
        local_Temple_One_Torch_Eight.Reset_Torch();
        local_Temple_One_Torch_Nine.Reset_Torch();
        local_Temple_One_Torch_Ten.Reset_Torch();

        torch_Whoosh_Sound.Play();

        torches_Lit_In_Right_Order = true;
        next_Torch_To_Be_Lit = 1;
    }

    //Instant Temple Completion for testing
    /*
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.M))
		{
			StartCoroutine (Puzzle_Solved());
		}
	}
	*/
}
