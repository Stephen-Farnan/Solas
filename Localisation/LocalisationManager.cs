using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LocalisationManager : MonoBehaviour
{

    public static LocalisationManager instance;

    private Dictionary<string, string> localisedText;
    private bool isReady = false;
    private string missingTextString = "!!!";

    private Dropdown languages_Dropdown;
    private int activeLanguage;

    //private SteamManager steamMan;

    void Awake()
    {
        languages_Dropdown = FindObjectOfType<Dropdown>();
        //steamMan = GameObject.Find("SteamManager").GetComponent<SteamManager>();

        if (PlayerPrefs.HasKey("activeLanguage"))
        {
            activeLanguage = PlayerPrefs.GetInt("activeLanguage");
            if (languages_Dropdown != null)
            {
                languages_Dropdown.value = activeLanguage;
            }
        }

        Set_Language();
    }

    /*
	void OnEnable() {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnDisable() {
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}
	

	void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		languages_Dropdown = FindObjectOfType<Dropdown>();
		if (languages_Dropdown == null)
		{
			Debug.Log("No Dropdown");
		}
		else
		{
			Debug.Log("Dropdown: " + languages_Dropdown.name);
		}

		if (PlayerPrefs.HasKey("activeLanguage"))
		{
			activeLanguage = PlayerPrefs.GetInt("activeLanguage");
			if (languages_Dropdown != null)
			{
				languages_Dropdown.value = activeLanguage;
			}
		}

		Set_Language();
	}*/

    public void LoadLocalisedText(string fileName)
    {
        localisedText = new Dictionary<string, string>();
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            LocalisationData loadedData = JsonUtility.FromJson<LocalisationData>(dataAsJson);

            for (int i = 0; i < loadedData.items.Length; i++)
            {
                localisedText.Add(loadedData.items[i].key, loadedData.items[i].value);
            }
        }
        else
        {
            Debug.LogError("Cannot find file!");
        }

        isReady = true;

        GameObject[] textGOs = GameObject.FindGameObjectsWithTag("Localised_Text");
        for (int i = 0; i < textGOs.Length; i++)
        {
            textGOs[i].GetComponent<LocalisedText>().UpdateText();
            //			Text text = textGOs[i].GetComponent<Text>();
            //			text.text = GetLocalisedValue(textGOs[i].GetComponent<LocalisedText>().key);
        }
    }

    public string GetLocalisedValue(string key)
    {
        string result = missingTextString;
        if (localisedText.ContainsKey(key))
        {
            result = localisedText[key];
        }

        return result;
    }

    public bool GetIsReady()
    {
        return isReady;
    }

    public void Set_Language()
    {
        string fileName;

        if (languages_Dropdown != null)
        {
            activeLanguage = languages_Dropdown.value;
        }

        switch (activeLanguage)
        {
            case 0:
                //English
                fileName = "SolasLocalisation_EN.json";
                break;

            case 1:
                //French
                fileName = "SolasLocalisation_FR.json";
                break;

            case 2:
                //German
                fileName = "SolasLocalisation_DE.json";
                break;

            case 3:
                //Espanyol
                fileName = "SolasLocalisation_ES.json";
                break;

            case 4:
                //chinese simple
                fileName = "SolasLocalisation_ZH.json";
                break;

            case 5:
                //chinese trad
                fileName = "SolasLocalisation_ZHT.json";
                break;

            case 6:
                //japanese
                fileName = "SolasLocalisation_JP.json";
                break;

            case 7:
                //russian
                fileName = "SolasLocalisation_RU.json";
                break;

            case 8:
                //portuguese-brazil
                fileName = "SolasLocalisation_PT.json";
                break;

            case 9:
                //korean
                fileName = "SolasLocalisation_KO.json";
                break;

            case 10:
                //swedish
                fileName = "SolasLocalisation_SV.json";
                break;

            case 11:
                //Ukraine
                fileName = "SolasLocalisation_UK.json";
                break;

            case 12:
                //Polish
                fileName = "SolasLocalisation_PL.json";
                break;

            case 13:
                //Italian
                fileName = "SolasLocalisation_IT.json";
                break;

            case 14:
                //Greek
                fileName = "SolasLocalisation_GK.json";
                break;

            case 15:
                //Hungarian
                fileName = "SolasLocalisation_HU.json";
                break;

            case 16:
                //Thai
                fileName = "SolasLocalisation_TH.json";
                break;

            case 17:
                //Turkey
                fileName = "SolasLocalisation_TR.json";
                break;

            case 18:
                //Romanian
                fileName = "SolasLocalisation_RO.json";
                break;

            case 19:
                //Portugeuse
                fileName = "SolasLocalisation_PT.json";
                break;

            case 20:
                //Norwayish
                fileName = "SolasLocalisation_NO.json";
                break;

            case 21:
                //Finnish
                fileName = "SolasLocalisation_FI.json";
                break;

            case 22:
                //netherlands
                fileName = "SolasLocalisation_NL.json";
                break;

            case 23:
                //czech
                fileName = "SolasLocalisation_CZ.json";
                break;

            case 24:
                //bulgarian
                fileName = "SolasLocalisation_BG.json";
                break;

            case 25:
                //arabic
                fileName = "SolasLocalisation_AR.json";
                break;

            case 26:
                //danish
                fileName = "SolasLocalisation_DA.json";
                break;

            default:
                //english
                fileName = "SolasLocalisation_EN.json";
                break;

        }

        LoadLocalisedText(fileName);

        //saving to playerprefs here
        PlayerPrefs.SetInt("activeLanguage", activeLanguage);
        PlayerPrefs.Save();
    }
}
