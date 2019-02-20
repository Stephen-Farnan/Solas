using System.Collections;
using UnityEngine;

public class Trap_Triggers : MonoBehaviour
{


    public GameObject Trap_Object;
    public GameObject Trap_Object2;
    public GameObject Trap_Target;

    public Collider bear_Trap_Death_Collider;

    public Pit_Trap_Fall_Collider local_Pit_Trap_Fall_Collider;

    public bool is_Triggered = false;

    public float trap_Speed = 0.001f;

    public float activation_Delay = 1f;
    public float bear_Trap_Time_Active = .6f;

    public float trap_Movement_Speed = 1f;

    public Animator anim;
    private AudioSource audioSource;
    public AudioClip[] audioClips;

    bool is_Pit_Trap;

    public enum TRAP_TYPE

    {
        PIT_TRAP,
        DART_TRAP,
        BEAR_TRAP
    }

    public TRAP_TYPE local_TRAP_TYPE;


    private void Start()
    {
        if (local_Pit_Trap_Fall_Collider != null)
        {
            is_Pit_Trap = true;
        }

        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !is_Triggered)
        {
            switch (local_TRAP_TYPE)
            {
                case TRAP_TYPE.BEAR_TRAP:

                    StartCoroutine("Activated_Trap", true);
                    break;

                case TRAP_TYPE.DART_TRAP:

                    StartCoroutine("Activated_Trap", false);
                    break;

                case TRAP_TYPE.PIT_TRAP:
                    StartCoroutine("Activated_Trap", false);
                    break;
            }

        }

        else if (other.gameObject.tag == "Trap Target" || (other.gameObject.tag == "Player_Hazard" && gameObject.tag != "Dart_Trigger"))
        {
            StopCoroutine("Activated_Trap");
        }
    }

    public void Stop_Dart()
    {
        StopCoroutine("Activated_Trap");
    }


    public IEnumerator Activated_Trap(bool is_Bear_Trap)
    {
        if (!is_Triggered)
        {
            if (!is_Bear_Trap && !is_Pit_Trap)
            {
                is_Triggered = true;
            }
            audioSource.clip = audioClips[0];
            audioSource.Play();

            yield return new WaitForSeconds(activation_Delay);

            anim.SetTrigger("Trap Activate");

            if (is_Pit_Trap)
            {
                yield return new WaitForSeconds(1f);
                is_Triggered = true;
            }


            //COLM Play Trap animation, effects, and sounds here if applicable


            if (is_Bear_Trap)
            {
                bear_Trap_Death_Collider.enabled = true;
                audioSource.clip = audioClips[1];
                audioSource.Play();

                yield return new WaitForSeconds(bear_Trap_Time_Active);
                bear_Trap_Death_Collider.enabled = false;
                is_Triggered = true;
            }



            else
            {
                if (is_Pit_Trap)
                {

                    local_Pit_Trap_Fall_Collider.Check_Will_Solas_Fall();
                }
                Trap_Object.GetComponent<Collider>().isTrigger = true;

                if (Trap_Object.GetComponent<Trap_Collision>() != null)
                {
                    Trap_Object.tag = "Player_Hazard";
                    Trap_Object.GetComponent<Trap_Collision>().is_Live = true;
                }

                while (true)
                {

                    if (!is_Bear_Trap)
                    {
                        Trap_Object.transform.position = Vector3.Lerp(Trap_Object.transform.position, Trap_Target.transform.position, .2f);
                    }

                    else
                    {
                        Trap_Object.transform.position = Vector3.Lerp(Trap_Object.transform.position, Trap_Target.transform.position, .2f);
                        Trap_Object2.transform.position = Vector3.Lerp(Trap_Object2.transform.position, Trap_Target.transform.position, .2f);
                    }
                    yield return new WaitForSeconds(trap_Speed);
                }
            }
        }




    }
}
