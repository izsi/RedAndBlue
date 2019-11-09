using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingTools : MonoBehaviour
{
    public void SaveTestData()
    {
        SaveData testData = CreateTestData();
        DataManager.instance.SaveDataToSlot(1, testData);
    }

    private SaveData CreateTestData()
    {
        SaveData data = new SaveData()
        {
            SaveTime = DateTime.Now,
            Faction = PlayerFaction.Blue,
            Chapter = 1,
            CurrentScene = "TeamManagementScene",
            Characters = StartingCharacterData.CharactersStartingData,
            PartyMembers = new List<CharacterId>() { CharacterId.MainCharacter, CharacterId.Blue1, CharacterId.Blue2, CharacterId.Blue3 }
        };

        return data;
    }

}
