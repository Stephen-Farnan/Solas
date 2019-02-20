using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Management_Singleton : GenericSingleton<Scene_Management_Singleton>
{

    [HideInInspector]
    public string previousScene;

    public void Load_Scene(string scene)
    {
        previousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene);
    }

    public string GetCurrentScene()
    {
        return SceneManager.GetActiveScene().name;
    }
}
