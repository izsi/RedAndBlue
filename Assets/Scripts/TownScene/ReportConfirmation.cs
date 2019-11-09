using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportConfirmation : MonoBehaviour
{
    public string Choice;

    public void ReportChoiceToTownSceneController()
    {
        TownSceneController.instance.ConfirmationChoice = Choice;
    }

}
