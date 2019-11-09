using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownSaveButton : MonoBehaviour
{
    public void OpenSaveWindow()
    {
        if (!TownSceneController.instance.IsRunningDialogue)
        {
            GameObject modalBlocker = TownSceneController.instance.ModalBlocker;
            modalBlocker.SetActive(true);
            GameObject saveWindow = modalBlocker.transform.Find("SaveWindow").gameObject;
            saveWindow.SetActive(true);
        }
    }

}
