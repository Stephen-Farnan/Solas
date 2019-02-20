using UnityEngine;
using UnityEngine.AI;

public class Scene_Spawning : MonoBehaviour
{
    private Scene_Management_Singleton sceneManagement;
    public GameObject player;
    public Transform[] spawnLocations;
    public string[] connectedScenes;
    private GameObject mainCamera;
    private ProgressManager progMan;

    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        sceneManagement = GameObject.FindWithTag("Scene_Manager").GetComponent<Scene_Management_Singleton>();
        progMan = GameObject.FindWithTag("Scene_Manager").GetComponent<ProgressManager>();
        if (!progMan.activateStandingStone && !progMan.deactivateTemple)
        {
            PlayerPlacement();
        }
    }

    /// <summary>
    /// Handles the movement of Solas to her start location
    /// </summary>
    void PlayerPlacement()
    {
        for (int i = 0; i < connectedScenes.Length; i++)
        {
            if (sceneManagement.previousScene == connectedScenes[i])
            {
                player.GetComponent<NavMeshAgent>().enabled = false;
                player.transform.position = spawnLocations[i].position;
                player.transform.rotation = spawnLocations[i].rotation;
                mainCamera.transform.position = player.transform.position;
                player.GetComponent<NavMeshAgent>().enabled = true;
                break;
            }
        }
    }
}
