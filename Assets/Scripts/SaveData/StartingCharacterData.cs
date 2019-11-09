using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StartingCharacterData
{
    public static CharacterData MainCharacter = new CharacterData()
    {
        CharacterId = CharacterId.MainCharacter,
        NameKey = "MainCharacterName",
        Faction = Faction.MainCharacter,
        Hp = 54,
        Mp = 48,
        MaxHp = 54,
        MaxMp = 48,
        PhysAttack = 42,
        PhysDefense = 50,
        MagicAttack = 36,
        MagicDefense = 46,
        Speed = 52,
        StrongElement = MagicElement.Metal,
        WeakElement = MagicElement.Earth // 328
    };

    public static CharacterData Blue1 = new CharacterData()
    {
        CharacterId = CharacterId.Blue1,
        NameKey = "Blue1Name",
        Faction = Faction.Blue,
        Amity = 0,
        Hp = 48,
        Mp = 58,
        MaxHp = 48,
        MaxMp = 58,
        PhysAttack = 30,
        PhysDefense = 38,
        MagicAttack = 60,
        MagicDefense = 58,
        Speed = 56,
        StrongElement = MagicElement.Ice,
        WeakElement = MagicElement.Fire // 348
    };

    public static CharacterData Blue2 = new CharacterData()
    {
        CharacterId = CharacterId.Blue2,
        NameKey = "Blue2Name",
        Faction = Faction.Blue,
        Amity = 0,
        Hp = 60,
        Mp = 48,
        MaxHp = 60,
        MaxMp = 48,
        PhysAttack = 56,
        PhysDefense = 60,
        MagicAttack = 34,
        MagicDefense = 42,
        Speed = 30,
        StrongElement = MagicElement.Earth,
        WeakElement = MagicElement.Ice // 330
    };

    public static CharacterData Blue3 = new CharacterData()
    {
        CharacterId = CharacterId.Blue3,
        NameKey = "Blue3Name",
        Faction = Faction.Blue,
        Amity = 0,
        Hp = 40,
        Mp = 56,
        MaxHp = 40,
        MaxMp = 56,
        PhysAttack = 28,
        PhysDefense = 36,
        MagicAttack = 58,
        MagicDefense = 52,
        Speed = 50,
        StrongElement = MagicElement.Wood,
        WeakElement = MagicElement.Metal // 320
    };

    public static CharacterData Blue4 = new CharacterData()
    {
        CharacterId = CharacterId.Blue4,
        NameKey = "Blue4Name",
        Faction = Faction.Blue,
        Amity = 0,
        Hp = 60,
        Mp = 40,
        MaxHp = 60,
        MaxMp = 40,
        PhysAttack = 58,
        PhysDefense = 50,
        MagicAttack = 34,
        MagicDefense = 30,
        Speed = 44,
        StrongElement = MagicElement.Wind,
        WeakElement = MagicElement.Wind // 316
    };

    public static CharacterData Red1 = new CharacterData()
    {
        CharacterId = CharacterId.Red1,
        NameKey = "Red1Name",
        Faction = Faction.Red,
        Amity = 0,
        Hp = 60,
        Mp = 50,
        MaxHp = 60,
        MaxMp = 50,
        PhysAttack = 60,
        PhysDefense = 56,
        MagicAttack = 38,
        MagicDefense = 38,
        Speed = 46,
        StrongElement = MagicElement.Fire,
        WeakElement = MagicElement.Ice // 348
    };

    public static CharacterData Red2 = new CharacterData()
    {
        CharacterId = CharacterId.Red2,
        NameKey = "Red2Name",
        Faction = Faction.Red,
        Amity = 0,
        Hp = 54,
        Mp = 52,
        MaxHp = 54,
        MaxMp = 52,
        PhysAttack = 48,
        PhysDefense = 58,
        MagicAttack = 44,
        MagicDefense = 40,
        Speed = 34,
        StrongElement = MagicElement.Earth,
        WeakElement = MagicElement.Fire // 330
    };

    public static CharacterData Red3 = new CharacterData()
    {
        CharacterId = CharacterId.Red3,
        NameKey = "Red3Name",
        Faction = Faction.Red,
        Amity = 0,
        Hp = 50,
        Mp = 52,
        MaxHp = 50,
        MaxMp = 52,
        PhysAttack = 54,
        PhysDefense = 34,
        MagicAttack = 50,
        MagicDefense = 38,
        Speed = 42,
        StrongElement = MagicElement.Wind,
        WeakElement = MagicElement.Wood // 320
    };

    public static CharacterData Red4 = new CharacterData()
    {
        CharacterId = CharacterId.Red4,
        NameKey = "Red4Name",
        Faction = Faction.Red,
        Amity = 0,
        Hp = 52,
        Mp = 46,
        MaxHp = 52,
        MaxMp = 46,
        PhysAttack = 38,
        PhysDefense = 30,
        MagicAttack = 50,
        MagicDefense = 52,
        Speed = 48,
        StrongElement = MagicElement.Wood,
        WeakElement = MagicElement.Metal // 316
    };

    public static Dictionary<CharacterId, CharacterData> CharactersStartingData = new Dictionary<CharacterId, CharacterData>()
    {
        {CharacterId.MainCharacter, MainCharacter },
        {CharacterId.Blue1, Blue1 },
        {CharacterId.Blue2, Blue2 },
        {CharacterId.Blue3, Blue3 },
        {CharacterId.Blue4, Blue4 },
        {CharacterId.Red1, Red1 },
        {CharacterId.Red2, Red2 },
        {CharacterId.Red3, Red3 },
        {CharacterId.Red4, Red4 }
    };
}
