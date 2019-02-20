using System.Collections;
using UnityEngine;

public class Falling_Snow_Hazard_Manager : MonoBehaviour
{

    public ParticleSystem prefall_Snow_Dust_Effect;
    public ParticleSystem avalanche_Snow_Effect;
    public ParticleSystem avalanche_Impact_Effect;
    [Space]
    public Light torchLight;
    public ParticleSystem fireParticle;
    [Space]
    public float avalanche_Delay = 3.5f;
    public float avalanche_Duration = 3.5f;
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    public void Drop_Snow()
    {
        prefall_Snow_Dust_Effect.Play();
        audioSource.clip = audioClips[0];
        audioSource.Play();
        StartCoroutine("Wait_For_Avalanche");
    }

    IEnumerator Wait_For_Avalanche()
    {
        yield return new WaitForSeconds(avalanche_Delay);
        avalanche_Snow_Effect.Play();
        audioSource.clip = audioClips[1];
        audioSource.Play();
        yield return new WaitForSeconds(1.5f);
        gameObject.GetComponent<Collider>().enabled = true;
        avalanche_Impact_Effect.Play();
        yield return new WaitForSeconds(avalanche_Duration);
        gameObject.GetComponent<Collider>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if (go.tag == "Player")
        {
            go.GetComponent<Player_Manager>().Kill_Player();
            //death anim here
            go.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Knock");
            torchLight.intensity = 0;
            var em = fireParticle.emission;
            em.enabled = false;
        }
    }
}
