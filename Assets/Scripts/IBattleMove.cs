using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBattleMove
{
    string Name { get; }
    string Description { get; }

    int UnlockCost { get; }
    bool Unlocked { get; }
}

[Serializable]
public class Attack : IBattleMove
{
    public Attack(string name, string description, int damage, AttackElement element, int unlockCost, bool unlocked, 
        StatusEffect statusEffect = null, float statusEffectProbability = 0f)
    {
        Name = name;
        Description = description;
        Damage = damage;
        Element = element;
        StatusEffect = statusEffect;
        StatusEffectProbability = statusEffectProbability;
        UnlockCost = unlockCost;
        Unlocked = unlocked;
    }

    public string Name { get; }
    public string Description { get; }
    public int UnlockCost { get; } = 0;
    public bool Unlocked { get; } = false;

    public int Damage;
    public AttackElement Element;
    public StatusEffect StatusEffect;
    public float StatusEffectProbability;
}

[Serializable]
public class BuffDebuff : IBattleMove
{
    public BuffDebuff(string name, string description, BuffTargetStat targetStat, int buffAmount, int duration, 
        int unlockCost, bool unlocked)
    {
        Name = name;
        Description = description;
        TargetStat = targetStat;
        BuffAmount = buffAmount;
        Duration = duration;
        UnlockCost = unlockCost;
        Unlocked = unlocked;
    }

    public string Name { get; }
    public string Description { get; }
    public int UnlockCost { get; } = 0;
    public bool Unlocked { get; } = false;

    public BuffTargetStat TargetStat; 
    public int BuffAmount;
    public int Duration; // number of turns
}

[Serializable]
public class StatusEffect
{
    public StatusEffectType SeType;
    public int Duration;
}

public enum AttackElement
{
    Physical,
    Ice,
    Fire,
    Metal,
    Plant,
    Wind,
    Earth
}

public enum StatusEffectType
{
    Frozen, // Can't move
    Poison, // HP reduces
    Bound, // Can't do physical attacks
    ArmourBreak, // Reduced defense
    Dizzy, // Attack friends
    Shock, // Can't do magic attacks
    Smokescreen, // Miss rate raised
    Falter // Reduced attack
}

public enum BuffTargetStat
{
    PhysAttack,
    PhysDefense,
    MagicAttack,
    MagicDefense
}
