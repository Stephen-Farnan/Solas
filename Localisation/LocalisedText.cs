using UnityEngine;
using UnityEngine.UI;

public class LocalisedText : MonoBehaviour
{

    public string key;
    private LocalisationManager locMan;


    void Start()
    {
        locMan = GameObject.Find("Local Scene Manager").GetComponent<LocalisationManager>();
        UpdateText();
    }

    public void UpdateText()
    {
        Text text = GetComponent<Text>();
        if (locMan != null)
        {
            text.text = locMan.GetLocalisedValue(key);
        }
    }
}
