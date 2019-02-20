using UnityEngine;

public class Camera_Pan_Hub_Area : MonoBehaviour
{

    public float move_SpeedFWD;
    public float move_SpeedUP;

    // Use this for initialization
    void Start()
    {

    }

    public bool moving = false;

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            Move_Camera();

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (moving)
            {
                moving = false;
            }

            else
            {
                moving = true;
            }
        }
    }

    void Move_Camera()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * move_SpeedFWD);
        transform.Translate(Vector3.up * Time.deltaTime * move_SpeedUP, Space.World);
    }
}
