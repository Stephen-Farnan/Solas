using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Management : MonoBehaviour
{
    [HideInInspector]
    public string previousScene;
    /// <summary>
    /// This class holds calls to load each of the levels in the game and is not destroyed when a new scene is loaded
    /// </summary>
    // Use this for initialization
    void Start()
    {

        DontDestroyOnLoad(transform.gameObject);

    }

    public void Load_Scene(string scene)
    {
        previousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene);
    }



    public void Load_Cabin_Interior_Scene()
    {
        SceneManager.LoadScene("CabinInterior");
    }

    public void Load_Hub_Area_Post_Tutorial()
    {
        SceneManager.LoadScene("Hub_Post_Temple");
    }

    public void Load_Main_Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Load_Cabin_Area()
    {
        SceneManager.LoadScene("CabinInterior");
    }

    public void Load_Hub_Area()
    {
        SceneManager.LoadScene("Hub Scene");
    }

    public void Load_Temple_One()
    {
        SceneManager.LoadScene("Temple1Interior");
    }
}
