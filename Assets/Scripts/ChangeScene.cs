using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void LoadNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneNewGame()
    {
        var startState = CreateStartState();
        DataManager.instance.CurrentState = startState;
        DataManager.instance.LoadNextScene(SceneFinder.GetSceneFromName(startState.CurrentScene));
    }

    private SaveData CreateStartState()
    {
        SaveData startData = new SaveData()
        {
            Faction = PlayerFaction.None,
            Chapter = 1,
            CurrentScene = "Narration_Intro",
            Characters = StartingCharacterData.CharactersStartingData,
            PartyMembers = new List<CharacterId>() { CharacterId.MainCharacter },
            Gold = 0,
            Items = new List<IItem>()
        };

        return startData;
    }
}
