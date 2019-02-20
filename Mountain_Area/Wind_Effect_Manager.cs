using UnityEngine;

public class Wind_Effect_Manager : MonoBehaviour
{

    public ParticleSystem windEffect;
    public int windLevel = 0;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            var em = windEffect.emission;

            em.rateOverTime = windLevel;
        }
    }
}
