using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public DateTime SaveTime;
    public PlayerFaction Faction;
    public int Chapter;

    public string CurrentScene;
    public Dictionary<CharacterId, CharacterData> Characters;
    public List<CharacterId> PartyMembers;
    public int Gold;
    public List<IItem> Items;    
}


public interface IItem
{

}

[Serializable]
public enum PlayerFaction
{
    None,
    Blue,
    Red
}

[Serializable]
public enum CharacterId
{
    MainCharacter,
    Red1,
    Red2,
    Red3,
    Red4,
    Blue1,
    Blue2,
    Blue3,
    Blue4,
    King,
    RedSoldier,
    BlueSoldier
}
