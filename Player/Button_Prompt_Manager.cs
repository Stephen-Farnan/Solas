using UnityEngine;

public class Button_Prompt_Manager : MonoBehaviour
{

    public Transform camera_Transform;


    private void Update()
    {

        Vector3 v = camera_Transform.position - transform.position;

        v.x = v.z = 0.0f;
        transform.LookAt(camera_Transform.transform.position - v);
        transform.Rotate(0, 140, 0);
    }




}
