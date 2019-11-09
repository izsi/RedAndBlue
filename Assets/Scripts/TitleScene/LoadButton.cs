using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButton : MonoBehaviour
{
    public void OpenLoadWindow()
    {
        GameObject modalBlocker = TitleSceneController.instance.ModalBlocker;
        modalBlocker.SetActive(true);
        GameObject loadWindow = modalBlocker.transform.Find("LoadWindow").gameObject;
        loadWindow.SetActive(true);
    }

}
