using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterData
{
    public CharacterId CharacterId;
    public string NameKey;

    public Faction Faction;

    public int Amity;

    public IBattleMove[] BattleMoves;

    public float Hp;
    public float Mp;

    public float MaxHp;
    public float MaxMp;
    public float PhysAttack;
    public float PhysDefense;
    public float MagicAttack;
    public float MagicDefense;
    public float Speed;

    public MagicElement StrongElement;
    public MagicElement WeakElement;
}

[Serializable]
public enum Faction
{
    Blue,
    Red,
    MainCharacter,
    King, 
    Other
}

[Serializable]
public enum MagicElement
{
    Wood,
    Fire,
    Earth,
    Metal,
    Ice,
    Wind
}
