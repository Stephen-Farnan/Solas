using System.Collections;
using UnityEngine;

public class FinalSceneAnimationTiming : MonoBehaviour
{

    public ParticleSystem blizzardEffect;
    public float blizzardDecreaseRate;
    [Space]
    public Animator doorAnim;
    public Animator solasAnim;
    public Animator flowerAnim;
    public Animator motherAnim;
    public Material spiritMaterial;
    private ProgressManager progMan;

    void Start()
    {
        progMan = GameObject.FindWithTag("Scene_Manager").GetComponent<ProgressManager>();

        if (progMan.noOfTemplesCompleted == 5)
        {
            StartFinalCutscene();
        }
    }

    public void StartFinalCutscene()
    {
        GetComponent<Animator>().enabled = true;
        GetComponent<Animator>().SetTrigger("Final");
        solasAnim.gameObject.SetActive(true);
        motherAnim.gameObject.SetActive(true);
        flowerAnim.gameObject.SetActive(true);

        Color clr = spiritMaterial.color;
        clr.a = 0;
        spiritMaterial.color = clr;

        blizzardEffect.gameObject.SetActive(true);
        StartCoroutine(DecreaseBlizzard());
        Invoke("DisablePlayerController", 1);
    }


    void DoorClose()
    {
        doorAnim.speed = 1;
        doorAnim.SetTrigger("Close");
    }

    void SolasAppear()
    {
        solasAnim.SetTrigger("End");
    }

    void FlowerBloom()
    {
        flowerAnim.SetTrigger("Grow");
    }

    void MotherAppear()
    {
        motherAnim.SetTrigger("End");
    }

    void DisablePlayerController()
    {
        GameObject.FindWithTag("Player").transform.parent.gameObject.SetActive(false);
    }

    IEnumerator DecreaseBlizzard()
    {
        while (blizzardEffect.emission.rateOverTimeMultiplier > 0)
        {
            var em = blizzardEffect.emission;
            em.rateOverTimeMultiplier -= blizzardDecreaseRate;
            yield return null;
        }
    }

    public IEnumerator DecreaseFog()
    {
        while (RenderSettings.fogEndDistance < 500)
        {
            RenderSettings.fogEndDistance += blizzardDecreaseRate * 3;
            yield return null;
        }
    }

    public void GameOver()
    {

        GameObject.FindWithTag("Scene_Manager").GetComponent<Scene_Management_Singleton>().Load_Scene("Main_Menu");
    }
}
