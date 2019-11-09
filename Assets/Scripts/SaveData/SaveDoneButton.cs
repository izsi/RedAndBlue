using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDoneButton : MonoBehaviour
{
    public void CloseSaveWindow(string windowName = "SaveWindow")
    {
        GameObject modalBlocker = gameObject.transform.parent.parent.gameObject;
        if (modalBlocker.name != "ModalBlocker")
        {
            throw new System.Exception("Could not find ModalBlocker");
        }
        GameObject saveWindow = modalBlocker.transform.Find(windowName).gameObject;
        saveWindow.SetActive(false);
        modalBlocker.SetActive(false);
    }
    
}
