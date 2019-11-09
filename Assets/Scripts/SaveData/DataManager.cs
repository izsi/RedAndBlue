using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public LanguageOption LanguageOption { get; set; }
    public SaveData CurrentState { get; set; }

    public int SelectedSaveSlot = 0;

    private string _globalSaveLocation;
    private bool _isReady = false;

    // Town Scene
    public TownSceneState TownSceneState;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        // ...\AppData\LocalLow\DefaultCompany\RedAndBlue
        _globalSaveLocation = $"{Application.persistentDataPath}{Path.DirectorySeparatorChar}globalData.dat";
        GlobalLoad();

        if (CurrentState == null)
        {
            CurrentState = new SaveData();
        }

        _isReady = true;
    }

    public bool GetIsReady()
    {
        return _isReady;
    }

    public void LoadNextScene(ISceneClass scene)
    {
        CurrentState.CurrentScene = scene.SceneName;
        SceneManager.LoadScene(scene.SceneType.ToString());
    }

    public void GlobalSave(bool reloadTextFile = false)
    {
        Debug.Log($"Saving settings to {_globalSaveLocation}");
        BinaryFormatter bf = new BinaryFormatter();
        GlobalSaveData globalData = new GlobalSaveData();
        using (FileStream file = File.Create(_globalSaveLocation))
        {
            globalData.language = LanguageOption;
            bf.Serialize(file, globalData);
        }

        if (reloadTextFile == true && LocalisationManager.instance != null)
        {
            LocalisationManager.instance.LoadlocalisedText();
        }
    }

    public void GlobalLoad()
    {
        if (File.Exists(_globalSaveLocation))
        {
            Debug.Log($"Loading settings from {_globalSaveLocation}");
            BinaryFormatter bf = new BinaryFormatter();
            GlobalSaveData globalData;
            using (FileStream file = File.Open(_globalSaveLocation, FileMode.Open))
            {
                globalData = (GlobalSaveData)bf.Deserialize(file);
            }
            LanguageOption = globalData.language;
        }
    }

    // Can pass data in for testing purposes
    public void SaveDataToSlot(int slotNumber, SaveData data = null)
    {
        if (!Directory.Exists(SaveSlotsDir))
        {
            Directory.CreateDirectory(SaveSlotsDir);
        }

        string slotLocation = GetSlotLocation(slotNumber);
        Debug.Log($"Saving data to {slotLocation}");
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream file = File.Create(slotLocation))
        {
            if (data == null)
            {
                CurrentState.SaveTime = DateTime.Now;
                bf.Serialize(file, CurrentState);
            }
            else
            {
                bf.Serialize(file, data);
            }
        }
    }

    public void LoadDataFromSlot(int slotNumber, bool loadScene = true)
    {
        string slotLocation = GetSlotLocation(slotNumber);
        Debug.Log($"Loading data from {slotLocation}");
        if (!File.Exists(slotLocation))
        {
            Debug.Log($"No file found at {slotLocation}");
            return;
        }
        BinaryFormatter bf = new BinaryFormatter();
        SaveData data = new SaveData();
        using (FileStream file = File.Open(slotLocation, FileMode.Open))
        {
            data = (SaveData)bf.Deserialize(file);
        }
        CurrentState = data;
        if (loadScene == true)
        {
            LoadNextScene(SceneFinder.GetSceneFromName(data.CurrentScene));
        }
    }

    public string GetSlotLocation(int slotNumber)
    {
        return $"{SaveSlotsDir}{Path.DirectorySeparatorChar}Slot{slotNumber.ToString()}.dat";
    }

    private string SaveSlotsDir
    {
        get { return $"{Application.persistentDataPath}{Path.DirectorySeparatorChar}SaveSlots"; }
    }
}
