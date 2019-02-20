using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Manager : MonoBehaviour
{

    public ThirdPerson3D local_ThirdPerson3D;
    private Audio_Manager_Singleton audioMan;
    public AudioSource death_Sound;
    private Fade_To_Black fade;
    private ProgressManager progMan;

    bool is_Dead = false;

    void Start()
    {
        audioMan = GameObject.Find("Audio Manager").GetComponent<Audio_Manager_Singleton>();
        fade = FindObjectOfType<Fade_To_Black>();
        progMan = GameObject.FindWithTag("Scene_Manager").GetComponent<ProgressManager>();
    }

    public void Kill_Player()
    {
        if (!is_Dead)
        {
            local_ThirdPerson3D.is_Dead = true;
            death_Sound.Play();
            is_Dead = true;
            progMan.AddDeath();
            StartCoroutine("Reload_Level");
        }

    }

    public IEnumerator Reload_Level()
    {
        StartCoroutine(audioMan.ChangeMusicTrack(audioMan.musicTracks[6], audioMan.transform.GetChild(1).GetComponent<AudioSource>().volume));
        audioMan.SetAudioVolume(0.01f, Audio_Manager_Singleton.AudioSourceType.wind);
        yield return new WaitForSeconds(4f);
        fade.Fade_Out();
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
