using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManageSaveButton : MonoBehaviour
{
    public void OpenSaveWindow()
    {
        GameObject modalBlocker = TeamManageSceneController.instance.ModalBlocker;
        modalBlocker.SetActive(true);
        GameObject saveWindow = modalBlocker.transform.Find("SaveWindow").gameObject;
        saveWindow.SetActive(true);
    }
}
