using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadConfirmationButton : MonoBehaviour
{
    public GameObject ConfirmationWindow;

    public void CloseConfirmationWindow()
    {
        DataManager.instance.SelectedSaveSlot = 0;
        ConfirmationWindow.SetActive(false);
    }

    public void LoadFromSlot()
    {
        int slotNumber = DataManager.instance.SelectedSaveSlot;
        if (slotNumber >= 1 && slotNumber <= 10)
        {
            DataManager.instance.SelectedSaveSlot = 0;
            DataManager.instance.LoadDataFromSlot(slotNumber);
        }
        else
        {
            Debug.Log($"Incorrect slot number of {slotNumber}. Not loading.");
        }        
    }
}
