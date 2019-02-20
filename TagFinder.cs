using UnityEngine;

public class TagFinder : MonoBehaviour
{

    [Tooltip("Enter tag here")]
    public string tagToFind;

    [Tooltip("Objects with tag will appear here")]
    public GameObject[] objectsWithTag;

    void Start()
    {
        if (tagToFind != null)
        {
            objectsWithTag = GameObject.FindGameObjectsWithTag(tagToFind);
        }
    }
}
