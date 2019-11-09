using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGlobalSettings : MonoBehaviour
{
    public void SaveSettings()
    {
        DataManager.instance.GlobalSave();
    }
}
