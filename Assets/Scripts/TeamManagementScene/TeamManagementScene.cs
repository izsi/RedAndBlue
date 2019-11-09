using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TeamManagementScene : ISceneClass
{
    public SceneType SceneType
    {
        get { return SceneType.TeamManagement; }
    }

    public string SceneName { get { return "TeamManagementScene"; } }

    private TeamManageSceneController Controller
    {
        get { return TeamManageSceneController.instance; }
    }

    public void SetupManagementScene()
    {
        SetUpCharacterSelectors();
    }

    private void SetUpCharacterSelectors()
    {
        List<CharacterId> availableCharacters = new List<CharacterId>();

        if (DataManager.instance.CurrentState.Faction == PlayerFaction.Blue)
        {
            Debug.Log("Faction: Blue");
            availableCharacters = BlueFactionCharacters;
        }
        else if (DataManager.instance.CurrentState.Faction == PlayerFaction.Red)
        {
            Debug.Log("Faction: Red");
            availableCharacters = RedFactionCharacters;
        }
        // Other scenarios pending....

        int counter = 0;
        while (counter < availableCharacters.Count)
        {
            Controller.CharacterSelectors[counter].GetComponent<CharacterSelector>().SetCharacter(availableCharacters[counter]);
            counter += 1;
        }
        // TODO: account for scenarios where num of available characters is less/more than num of character selectors.

        

    }


    public List<CharacterId> BlueFactionCharacters = new List<CharacterId>()
    {
        CharacterId.MainCharacter,
        CharacterId.Blue1,
        CharacterId.Blue2,
        CharacterId.Blue3,
        CharacterId.Blue4
    };

    public List<CharacterId> RedFactionCharacters = new List<CharacterId>()
    {
        CharacterId.MainCharacter,
        CharacterId.Red1,
        CharacterId.Red2,
        CharacterId.Red3,
        CharacterId.Red4
    };
}


