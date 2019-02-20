using UnityEngine;

public class ProgressManager : MonoBehaviour
{

    //Has a temple just been completed?
    public bool deactivateTemple;
    //Should the standing stone activation animation play?
    public bool activateStandingStone;
    //Number of temples that have been completed
    public int noOfTemplesCompleted = 0;
    //The specific temples which have been completed
    [Tooltip("0: Hub, 1: Trap, 2: Mountain, 3: Ice, 4: Final")]
    public bool[] templesCompleted;
    //To de/activate temple saving
    public bool templeSaving;
    //Number of deaths
    [HideInInspector]
    public int noOfDeaths = 0;

    private AnalyticsManager anMan;

    void Awake()
    {
        Initialise_Data();
    }

    void Start()
    {
        anMan = GameObject.FindWithTag("Analytics_Manager").GetComponent<AnalyticsManager>();
    }

    public void Initialise_Data()
    {
        if (templeSaving)
        {
            for (int i = 0; i < templesCompleted.Length; i++)
            {
                if (PlayerPrefs.HasKey("temples_Completed_" + i.ToString()))
                {
                    if (PlayerPrefs.GetInt("temples_Completed_" + i.ToString()) == 0)
                    {
                        templesCompleted[i] = false;
                    }
                    else
                    {
                        templesCompleted[i] = true;
                    }
                }
            }
            SetNoOfTemplesCompleted();

            if (PlayerPrefs.HasKey("deaths"))
            {
                noOfDeaths = PlayerPrefs.GetInt("deaths");
            }
        }
    }

    /// <summary>
    /// 0: Hub, 1: Trap, 2: Mountain, 3: Ice, 4: Final
    /// </summary>
    /// <param name="templeCompleted"></param>
    public void TempleCompleted(int templeCompleted)
    {
        templesCompleted[templeCompleted] = true;

        SetNoOfTemplesCompleted();

        if (noOfTemplesCompleted < 5)
        {
            deactivateTemple = true;
        }

        if (templeSaving)
        {
            SaveTempleData();
        }
        if (anMan != null)
        {
            anMan.LogTempleCompletion(templeCompleted);
        }
    }

    void SetNoOfTemplesCompleted()
    {
        int newNumber = 0;
        for (int i = 0; i < templesCompleted.Length; i++)
        {
            if (templesCompleted[i])
            {
                newNumber++;
            }
        }
        noOfTemplesCompleted = newNumber;
    }

    private void SaveTempleData()
    {
        for (int i = 0; i < templesCompleted.Length; i++)
        {
            if (templesCompleted[i])
            {
                PlayerPrefs.SetInt("temples_Completed_" + i.ToString(), 1);
            }
            else
            {
                PlayerPrefs.SetInt("temples_Completed_" + i.ToString(), 0);
            }
        }

        PlayerPrefs.Save();
    }

    public void ClearProgressData()
    {
        noOfTemplesCompleted = 0;
        for (int i = 0; i < templesCompleted.Length; i++)
        {
            PlayerPrefs.SetInt("temples_Completed_" + i.ToString(), 0);
            templesCompleted[i] = false;
        }

        PlayerPrefs.SetInt("trap_Cutscene_Triggered", 0);
        PlayerPrefs.SetInt("deaths", 0);

        PlayerPrefs.Save();
    }

    public void AddDeath()
    {
        noOfDeaths++;
        PlayerPrefs.SetInt("deaths", noOfDeaths);
        anMan.LogDeath();
    }

    /*
	void Update() {
		if (Input.GetKey(KeyCode.C))
		{
			ClearProgressData();
		}
	}
	*/
}
