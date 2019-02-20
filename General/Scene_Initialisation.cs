using System.Collections;
using UnityEngine;

public class Scene_Initialisation : MonoBehaviour
{

    [Header("Audio")]
    public float windAudioVolume = 0.1f;
    [Range(0.0f, 1.0f)]
    public float windSpatial3D = 0;
    [Tooltip("Set to negative value for no music")]
    public int musicTrack;
    public float musicAudioVolume = 0.05f;
    private Audio_Manager_Singleton audioManager;
    private ProgressManager progMan;
    private Scene_Management_Singleton sceneManagement;

    [Header("Temple Deactivation")]
    public Animator templeAnim;
    public string templeArea;
    private Animator cameraAnim;
    private CameraFollowOrbit playerCameraScript;
    public GameObject templeBeam;

    void Awake()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            playerCameraScript = GameObject.FindWithTag("Player").transform.parent.GetChild(1).GetComponent<CameraFollowOrbit>();
        }
        sceneManagement = GameObject.FindWithTag("Scene_Manager").GetComponent<Scene_Management_Singleton>();
        cameraAnim = GameObject.FindWithTag("MainCamera").GetComponent<Animator>();
        audioManager = GameObject.Find("Audio Manager").GetComponent<Audio_Manager_Singleton>();
        progMan = GameObject.FindWithTag("Scene_Manager").GetComponent<ProgressManager>();

        audioManager.SetAudioVolume(windAudioVolume, Audio_Manager_Singleton.AudioSourceType.wind);
        audioManager.SetSpatialBlend(windSpatial3D);


        if (progMan.deactivateTemple)
        {
            DeactivatePlayer();
            StartCoroutine(PlayTempleDeactivation());

        }
        else if (progMan.activateStandingStone)
        {
            DeactivatePlayer();

        }
        else if (musicTrack >= 0 && audioManager.musicAudioSource.clip != audioManager.musicTracks[musicTrack])
        {
            if (progMan.noOfTemplesCompleted < 5)
            {
                StartCoroutine(audioManager.ChangeMusicTrack(audioManager.musicTracks[musicTrack], musicAudioVolume));
            }
        }
        else
        {
            audioManager.SetAudioVolume(musicAudioVolume, Audio_Manager_Singleton.AudioSourceType.music);
        }

        //Deactivating Temple beams
        if (templeArea == "Hub")
        {
            if (progMan.templesCompleted[0] && !progMan.deactivateTemple)
            {
                templeBeam.SetActive(false);
            }
        }
        if (templeArea == "Trap")
        {
            if (progMan.templesCompleted[1] && !progMan.deactivateTemple)
            {
                templeBeam.SetActive(false);
            }
        }
        if (templeArea == "Mountain")
        {
            if (progMan.templesCompleted[2] && !progMan.deactivateTemple)
            {
                templeBeam.SetActive(false);
            }
        }
        if (templeArea == "Ice")
        {
            if (progMan.templesCompleted[3] && !progMan.deactivateTemple)
            {
                templeBeam.SetActive(false);
            }
        }
    }

    IEnumerator PlayTempleDeactivation()
    {
        playerCameraScript.enabled = false;
        cameraAnim.enabled = true;
        cameraAnim.SetTrigger(templeArea);

        yield return new WaitForSeconds(4.5f);

        templeAnim.SetTrigger("Deactivate");
        progMan.deactivateTemple = false;

        progMan.activateStandingStone = true;
    }

    void DeactivatePlayer()
    {
        if (sceneManagement.GetCurrentScene() != "CabinInterior" && sceneManagement.GetCurrentScene() != "Story Book Scene")
        {
            playerCameraScript.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            if (musicTrack >= 0 && audioManager.musicAudioSource.clip != audioManager.musicTracks[5])
            {
                StartCoroutine(audioManager.ChangeMusicTrack(audioManager.musicTracks[5], musicAudioVolume));
            }
            else
            {
                audioManager.SetAudioVolume(musicAudioVolume, Audio_Manager_Singleton.AudioSourceType.music);
            }
        }
    }
}
