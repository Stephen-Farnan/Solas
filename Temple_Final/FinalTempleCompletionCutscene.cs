using UnityEngine;

public class FinalTempleCompletionCutscene : MonoBehaviour
{

    [Tooltip("All door controllers in the temple; ordered from LAST to FIRST")]
    public GameObject[] templeDoors;
    private int doorIndex = 0;
    private Scene_Management_Singleton sceneMan;

    void Start()
    {
        sceneMan = GameObject.FindWithTag("Scene_Manager").GetComponent<Scene_Management_Singleton>();
        templeDoors[0].GetComponent<Animator>().SetTrigger("Open");
    }

    public void CloseDoor()
    {
        templeDoors[doorIndex].GetComponent<Animator>().SetTrigger("Close");
        doorIndex++;
    }

    public void LoadFinalScene()
    {
        sceneMan.Load_Scene("Hub Scene");
    }
}
