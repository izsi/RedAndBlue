using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToTeamManagementButton : MonoBehaviour
{
    public void ToTeamManagementScreen()
    {
        TownSceneController.instance.SaveTownState();
        DataManager.instance.LoadNextScene(new TeamManagementScene());
    }    
}
