using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LanguageButtonController : MonoBehaviour
{
    public Button EnglishUkButton, JapaneseButton;

    // Use this for initialization
    void Start()
    {        
        if (DataManager.instance.LanguageOption == LanguageOption.EnglishUk)
        {
            JapaneseButton.interactable = true;
            EnglishUkButton.interactable = false;
        }
        else if (DataManager.instance.LanguageOption == LanguageOption.Japanese)
        {
            EnglishUkButton.interactable = true;
            JapaneseButton.interactable = false;
        }
        else
        {
            Debug.Log("Unrecognised language option in DataManager");            
        }

        EnglishUkButton.onClick.AddListener(TaskOnEnglishClick);
        JapaneseButton.onClick.AddListener(TaskOnJapaneseClick);
    }

    public void TaskOnEnglishClick()
    {
        DataManager.instance.LanguageOption = LanguageOption.EnglishUk;
        DataManager.instance.GlobalSave(reloadTextFile: true);
        JapaneseButton.interactable = true;
        EnglishUkButton.interactable = false;
        SceneManager.LoadScene("InitialLoad");
    }

    public void TaskOnJapaneseClick()
    {
        DataManager.instance.LanguageOption = LanguageOption.Japanese;
        DataManager.instance.GlobalSave(reloadTextFile: true);
        EnglishUkButton.interactable = true;
        JapaneseButton.interactable = false;
        SceneManager.LoadScene("InitialLoad");
    }

}
