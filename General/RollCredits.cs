using UnityEngine;

public class RollCredits : MonoBehaviour
{

    public GameObject root;

    /// <summary>
    /// Starts playing the credits animation at the end of the game
    /// </summary>
    void StartCredits()
    {
        root.SetActive(true);
        root.transform.parent.GetComponent<Animator>().SetTrigger("Start");
    }
}
