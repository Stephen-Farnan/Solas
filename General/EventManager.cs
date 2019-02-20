using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EventManager : MonoBehaviour
{

    public GameObject[] gOs;
    public CameraTransition camTrans;

    private float overrideTimer = 0;

    public bool trapAreaCutsceneTriggered = false;

    void Awake()
    {
        if (PlayerPrefs.HasKey("trap_Cutscene_Triggered"))
        {
            if (PlayerPrefs.GetInt("trap_Cutscene_Triggered") == 0)
            {
                trapAreaCutsceneTriggered = false;
            }
            else if (GameObject.FindWithTag("Scene_Manager").GetComponent<Scene_Management_Singleton>().GetCurrentScene() == "Trap Area Scene")
            {
                trapAreaCutsceneTriggered = true;
                FindObjectOfType<CutsceneTrigger>().transform.gameObject.SetActive(false);
            }
        }
    }

    public void TrapCutscene()
    {
        if (!trapAreaCutsceneTriggered)
        {
            StartCoroutine(TrapCutsceneEnumerator());
        }
    }
    private IEnumerator TrapCutsceneEnumerator()
    {
        gOs[0].SetActive(true);
        yield return new WaitForSeconds(1.2f);
        StartCoroutine(gOs[1].GetComponent<Trap_Triggers>().Activated_Trap(true));
        yield return new WaitForSeconds(2.0f);
        camTrans.MoveToOldPosition();
        gOs[0].SetActive(false);
        yield return new WaitForSeconds(3.0f);
        camTrans.enabled = false;
        PlayerPrefs.SetInt("trap_Cutscene_Triggered", 1);
    }

    public void SolasMeetsMother()
    {
        StartCoroutine(SolasMeetsMotherEnumerator());
    }

    private IEnumerator SolasMeetsMotherEnumerator()
    {
        GameObject.FindWithTag("Scene_Manager").GetComponent<ProgressManager>().TempleCompleted(4);

        gOs[0].GetComponent<NavMeshAgent>().SetDestination(gOs[1].transform.position);
        gOs[0].GetComponent<NavMeshAgent>().isStopped = false;
        gOs[0].transform.GetChild(0).GetComponent<Animator>().SetBool("Run", true);
        while (Vector2.Distance(new Vector2(gOs[0].transform.position.x, gOs[0].transform.position.z),
            new Vector2(gOs[1].transform.position.x, gOs[1].transform.position.z)) > gOs[0].GetComponent<NavMeshAgent>().stoppingDistance * 1.2f)
        {
            overrideTimer += Time.deltaTime;
            if (overrideTimer >= 4.0f)
            {
                gOs[0].transform.position = new Vector3(gOs[1].transform.position.x, gOs[0].transform.position.y, gOs[1].transform.position.z);
                break;
            }
            yield return null;
        }
        overrideTimer = 0;
        gOs[0].transform.GetChild(0).GetComponent<Animator>().SetBool("Run", false);
        yield return new WaitForSeconds(1.2f);
        gOs[0].GetComponent<NavMeshAgent>().speed = 1.0f;
        gOs[0].GetComponent<NavMeshAgent>().SetDestination(gOs[2].transform.position);
        gOs[0].transform.GetChild(0).GetComponent<Animator>().SetBool("Walk", true);
        while (Vector2.Distance(new Vector2(gOs[0].transform.position.x, gOs[0].transform.position.z),
            new Vector2(gOs[2].transform.position.x, gOs[2].transform.position.z)) > gOs[0].GetComponent<NavMeshAgent>().stoppingDistance * 1.2f)
        {
            overrideTimer += Time.deltaTime;
            if (overrideTimer >= 4.0f)
            {
                gOs[0].transform.position = new Vector3(gOs[2].transform.position.x, gOs[0].transform.position.y, gOs[2].transform.position.z);
                break;
            }
            yield return null;
        }
        gOs[0].transform.GetChild(0).GetComponent<Animator>().SetBool("Walk", false);
        Audio_Manager_Singleton ams = FindObjectOfType<Audio_Manager_Singleton>();
        StartCoroutine(ams.ChangeMusicTrack(ams.musicTracks[5], ams.transform.GetChild(1).GetComponent<AudioSource>().volume));
        yield return new WaitForSeconds(1.2f);
        gOs[3].GetComponent<Animator>().enabled = true;
    }
}
