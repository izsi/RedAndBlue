using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;

public class LocalisationManager : MonoBehaviour
{
    public static LocalisationManager instance;

    private Dictionary<string, string> localisedText;
    private bool isReady = false;
    private readonly string _missingTextString = "Text not found";
    private readonly string _entextFile = "LocalisedText_en.json";
    private readonly string _jptextFile = "LocalisedText_jp.json";

    public void Awake()
    {
        Debug.Log("Loading LocalisationManager");
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        
        LoadlocalisedText();
    }

    public void LoadlocalisedText()
    {
        LanguageOption currentLang = DataManager.instance.LanguageOption;
        string fileName;
        if (currentLang == LanguageOption.EnglishUk)
        {
            fileName = _entextFile;
        }
        else if (currentLang == LanguageOption.Japanese)
        {
            fileName = _jptextFile;
        }
        else
        {
            Debug.Log("Unrecognised language; defaulting to English text file");
            fileName = _entextFile;
        }

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

            Debug.Log("Data loaded, dictionary contains: " + localisedText.Count + " entries");
        }
        else
        {
            Debug.LogError("Cannot find file!");
        }

        isReady = true;
    }

    public string GetLocalisedValue(string key)
    {
        string result = _missingTextString;
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

}
