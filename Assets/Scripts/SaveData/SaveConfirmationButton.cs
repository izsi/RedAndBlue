using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveConfirmationButton : MonoBehaviour
{
    public GameObject ConfirmationWindow;
    public GameObject SaveSlots;

    public void CloseConfirmationWindow()
    {
        DataManager.instance.SelectedSaveSlot = 0;
        ConfirmationWindow.SetActive(false);
    }

    public void SaveToSlot()
    {
        int slotNumber = DataManager.instance.SelectedSaveSlot;
        if (slotNumber >= 1 && slotNumber <= 10)
        {
            DataManager.instance.SaveDataToSlot(slotNumber);
        }
        else
        {
            Debug.Log($"Incorrect slot number of {slotNumber}. Not saving.");
        }
        DataManager.instance.SelectedSaveSlot = 0;
        RefreshSlotInfo(slotNumber);
        CloseConfirmationWindow();
    }

    public void RefreshSlotInfo(int slotNumber)
    {
        GetSlotGameObject(slotNumber).GetComponent<SaveSlot>().WriteSlotText();
    }

    private GameObject GetSlotGameObject(int slotNumber)
    {
        string slotName = $"Slot{slotNumber}";
        return SaveSlots.transform.Find(slotName).gameObject;
    }
}
