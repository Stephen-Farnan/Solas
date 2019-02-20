using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CutsceneTrigger : MonoBehaviour
{

    public CameraTransition camTrans;
    public UnityEvent cutsceneEvent;
    [HideInInspector]
    public bool cutsceneHasBeenTriggered;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && !cutsceneHasBeenTriggered)
        {
            StartCoroutine(PlayCutscene());
            cutsceneHasBeenTriggered = true;
        }
    }

    /// <summary>
    /// Disables player movement and input and then calls the next cutscene from alist of unlockable cutscenes
    /// </summary>
    /// <returns></returns>
    IEnumerator PlayCutscene()
    {
        camTrans.enabled = true;
        camTrans.charController.canMove = false;
        yield return new WaitForSeconds(0.4f);
        camTrans.MoveToNewPosition();
        yield return new WaitForSeconds(camTrans.smoothTime);
        cutsceneEvent.Invoke();
    }
}
