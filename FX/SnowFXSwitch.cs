using UnityEngine;

public class SnowFXSwitch : MonoBehaviour
{

    public ParticleSystem[] playerFX;
    public ParticleSystem[] snowFX;
    public FootprintSpawnScript playerWalkParticles;

    public bool entrance;

    void Start()
    {
        OutdoorFXSwitch(false);
    }

    void OnTriggerEnter()
    {
        if (entrance)
        {
            PlayerFXSwitch(false);

            OutdoorFXSwitch(true);
        }
        else
        {
            PlayerFXSwitch(true);

            OutdoorFXSwitch(false);
        }
    }

    void PlayerFXSwitch(bool onOff)
    {
        for (int i = 0; i < playerFX.Length; i++)
        {
            var em = playerFX[i].emission;
            em.enabled = onOff;
        }
        playerWalkParticles.snowFootprints = onOff;
    }

    void OutdoorFXSwitch(bool onOff)
    {
        for (int i = 0; i < snowFX.Length; i++)
        {
            var em = snowFX[i].emission;
            em.enabled = onOff;
        }
    }
}
