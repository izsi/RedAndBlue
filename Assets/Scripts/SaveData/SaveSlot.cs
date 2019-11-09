using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour
{
    public GameObject SaveConfirmationWindow;
    public GameObject LoadConfirmationWindow;

    private bool _isData;

    private SaveData CurrentState
    {
        get { return DataManager.instance.CurrentState; }
    }

    private LocalisationManager LocalisationManager
    {
        get { return LocalisationManager.instance; }
    }

    // Relies on proper numbering of slot game objects
    public int SlotNumber
    {
        get
        {
            string num = Regex.Match(gameObject.name, @"\d+$").Value;
            return int.Parse(num);
        }
    }

    private void Start()
    {
        WriteSlotText();
    }

    public void OpenSaveConfirmation()
    {
        DataManager.instance.SelectedSaveSlot = SlotNumber;
        SaveConfirmationWindow.SetActive(true);
    }

    public void OpenLoadConfirmation()
    {
        if (_isData == true)
        {
            DataManager.instance.SelectedSaveSlot = SlotNumber;
            LoadConfirmationWindow.SetActive(true);
        }
    }
    
    public void WriteSlotText()
    {
        // TODO: implement Chapter numbers?
        string slot = LocalisationManager.GetLocalisedValue("SaveSlot");
        string time = LocalisationManager.GetLocalisedValue("SaveTime");
        string faction = LocalisationManager.GetLocalisedValue("SaveFaction");
        string noData = LocalisationManager.GetLocalisedValue("SaveNoData");

        var buttonText = gameObject.transform.Find("Text").gameObject.GetComponent<Text>();
        SaveData data = ReadDataFromSlot();
        if (data == null)
        {
            buttonText.text = $"{slot} {SlotNumber}    {noData}";
            _isData = false;
        }
        else
        {
            buttonText.text = $"{slot} {SlotNumber}    {time}: {data.SaveTime.ToString()}  {faction}: {data.Faction}";
            _isData = true;
        }
    }

    private SaveData ReadDataFromSlot()
    {
        string slotLocation = DataManager.instance.GetSlotLocation(SlotNumber);
        Debug.Log($"Loading data from {slotLocation}");
        if (!File.Exists(slotLocation))
        {
            Debug.Log($"No file found at {slotLocation}");
            return null;
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(slotLocation, FileMode.Open);
        SaveData data = (SaveData)bf.Deserialize(file);
        file.Close();
        return data;
    }
}
