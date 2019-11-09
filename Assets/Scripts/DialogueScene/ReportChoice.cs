using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportChoice : MonoBehaviour
{
    public int ChoiceNumber;

    public void ReportChoiceToDialogueSceneController()
    {
        DialogueSceneController.instance.ChoiceMade = ChoiceNumber;
    }
}
