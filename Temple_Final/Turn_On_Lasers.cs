using UnityEngine;

public class Turn_On_Lasers : MonoBehaviour
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
            laser1.SetActive(true);
            laser2.SetActive(true);
            laser3.SetActive(true);
            laser4.SetActive(true);
            laser5.SetActive(true);
            laser6.SetActive(true);
            laser7.SetActive(true);
            laser8.SetActive(true);
            laser9.SetActive(true);
        }
    }


}
