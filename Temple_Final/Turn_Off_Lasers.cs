using UnityEngine;

public class Turn_Off_Lasers : MonoBehaviour
{

    public GameObject laser1;
    public GameObject laser2;
    public GameObject laser3;
    public GameObject laser4;
    public GameObject laser5;
    public GameObject laser6;
    public GameObject laser7;
    public GameObject laser8;
    public GameObject laser9;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            laser1.SetActive(false);
            laser2.SetActive(false);
            laser3.SetActive(false);
            laser4.SetActive(false);
            laser5.SetActive(false);
            laser6.SetActive(false);
            laser7.SetActive(false);
            laser8.SetActive(false);
            laser9.SetActive(false);
        }
    }
}
