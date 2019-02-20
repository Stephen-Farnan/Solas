using System.Collections;
using UnityEngine;

public class Temple_One_Puzzle_One : MonoBehaviour
{

    public bool torch_One_Is_Lit;
    public bool torch_Two_Is_Lit;
    bool puzzle_Is_Solved;
    public float torch_Light_Delay = .6f;

    private CameraTransition camTrans;
    [Space]
    public ParticleSystem[] door_Rubble_Particles;

    public GameObject temple_Door;

    private Player_Interaction playInt;

    public AudioSource door_Opening_Sound;

    private ProgressManager progMan;

    void Start()
    {
        camTrans = GameObject.Find("Door Camera Position").GetComponent<CameraTransition>();
        if (GameObject.FindWithTag("Player") != null)
        {
            playInt = GameObject.FindWithTag("Player").GetComponent<Player_Interaction>();
        }
    }

    public void Check_Puzzle_Is_Solved()
    {
        if (!puzzle_Is_Solved)
        {
            if (torch_One_Is_Lit && torch_Two_Is_Lit)
            {
                StartCoroutine("Open_Door");
                puzzle_Is_Solved = true;
            }
        }

    }


    IEnumerator Open_Door()
    {
        camTrans.enabled = true;
        playInt.can_Interact = false;
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

}
