using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataModifier : MonoBehaviour
{
    private Dropdown _languageDropdown { get; set; }

    private void Start()
    {
        _languageDropdown = GetComponent<Dropdown>();
    }

    public void SetLanguageFromDropDown()
    {
        SetLanguage(_languageDropdown.value);
    }

    private void SetLanguage(int languageIndex)
    {
        switch (languageIndex)
        {
            case 0:
                Debug.Log("Default selected - will not change language");
                break;
            case 1:
                DataManager.instance.LanguageOption = LanguageOption.EnglishUk;
                break;
            case 2:
                DataManager.instance.LanguageOption = LanguageOption.Japanese;
                break;
            default:
                Debug.Log("Failed to switch language");
                break;
        }
    }
}
