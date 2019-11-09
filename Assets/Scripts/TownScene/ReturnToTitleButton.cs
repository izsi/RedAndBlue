using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToTitleButton : MonoBehaviour
{
    public GameObject ConfirmationWindow;

    public void OpenConfirmationWindow()
    {
        ConfirmationWindow.SetActive(true);
    }

    public void ReturnToTitle()
    {
        DataManager.instance.LoadNextScene(new TitleScene());
    }

    public void CancelReturnToTitle()
    {
        ConfirmationWindow.SetActive(false);
    }
}
