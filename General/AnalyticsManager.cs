using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class AnalyticsManager : GenericSingleton<AnalyticsManager>
{

    Scene_Management_Singleton sceneMan;
    float sceneStartTime = 0;

    void Start()
    {
        sceneMan = GameObject.FindWithTag("Scene_Manager").GetComponent<Scene_Management_Singleton>();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        LogTimePerScene(true);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (sceneMan != null)
        {
            LogTimePerScene(false);
        }
        Analytics.CustomEvent("Scene Loaded", new Dictionary<string, object> { { "Scene", scene.name } });
        sceneStartTime = Time.time;
    }

    public void LogDeath()
    {
        Analytics.CustomEvent("Deaths", new Dictionary<string, object> { { "Scene Death Ocurred In", SceneManager.GetActiveScene().name } });
    }

    void LogTimePerScene(bool onSceneDisabled)
    {
        string sceneName;

        if (onSceneDisabled)
        {
            sceneName = SceneManager.GetActiveScene().name;
        }
        else
        {
            sceneName = sceneMan.previousScene;
        }

        Analytics.CustomEvent("Time Per Scene: " + sceneName, new Dictionary<string, object> {
                { "Time Spent in " + sceneName, Time.time - sceneStartTime}
            });
    }

    /// <summary>
    /// 0: Hub, 1: Trap, 2: Mountain, 3: Ice, 4: Final
    /// </summary>
    /// <param name="templeCompleted"></param>
    public void LogTempleCompletion(int templeCompleted)
    {
        Analytics.CustomEvent("Temple Completed", new Dictionary<string, object> { { "Temple Number", templeCompleted } });
    }
}
