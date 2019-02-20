using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MotherController : MonoBehaviour
{

    /// <summary>
    /// This script handles all aspects of the ghostly mother figure in the game
    /// </summary>

    private Animator anim;
    public Transform target;
    private NavMeshAgent navAgent;
    private Material mat;
    private Light mLight;
    public float fadeTime = 1.0f;
    public bool isFirst;
    public GameObject nextInstance;
    private ProgressManager progMan;

    void Awake()
    {
        anim = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        mat = transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material;
        mLight = GetComponent<Light>();
        progMan = GameObject.FindWithTag("Scene_Manager").GetComponent<ProgressManager>();
        if (isFirst)
        {
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, 0.8f);
        }
        else
        {
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, 0);
            mLight.intensity = 0;
        }
    }

    void Start()
    {
        if (progMan.noOfTemplesCompleted == 0 || FindObjectOfType<Scene_Management_Singleton>().GetCurrentScene() == "FinalTemple")
        {
            StartCoroutine(FadeIn());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter()
    {
        if (target != null)
        {
            navAgent.SetDestination(target.position);
            anim.SetBool("Walk", true);
        }
        GetComponent<SphereCollider>().enabled = false;
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        Color matAlpha = mat.color;
        while (mat.color.a > 0)
        {
            matAlpha.a -= Time.deltaTime * fadeTime;
            mat.color = matAlpha;
            mLight.intensity -= Time.deltaTime * fadeTime;
            yield return null;
        }
        if (nextInstance != null)
        {
            nextInstance.gameObject.SetActive(true);
            //			nextInstance.GetComponent<MotherController>().StartCoroutine(FadeIn());
        }
        gameObject.SetActive(false);
    }

    public IEnumerator FadeIn()
    {
        Color matAlpha = mat.color;
        while (mat.color.a < 0.8f)
        {
            matAlpha.a += Time.deltaTime * fadeTime;
            mat.color = matAlpha;
            mLight.intensity += Time.deltaTime * fadeTime;
            yield return null;
        }
    }
}
