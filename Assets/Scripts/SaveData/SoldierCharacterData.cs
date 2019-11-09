using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierCharacterData
{
    public static CharacterData PhysSoldier = new CharacterData()
    {
        Hp = 50,
        Mp = 34,
        MaxHp = 50,
        MaxMp = 34,
        PhysAttack = 50,
        PhysDefense = 50,
        MagicAttack = 28,
        MagicDefense = 32,
        Speed = 36 
    }; // 280

    public static CharacterData MagicSoldier = new CharacterData()
    {
        Hp = 42,
        Mp = 48,
        MaxHp = 42,
        MaxMp = 48,
        PhysAttack = 20,
        PhysDefense = 30,
        MagicAttack = 50,
        MagicDefense = 50,
        Speed = 40 
    }; // 280

    public static CharacterData AttackSoldier = new CharacterData()
    {
        Hp = 44,
        Mp = 46,
        MaxHp = 44,
        MaxMp = 46,
        PhysAttack = 50,
        PhysDefense = 30,
        MagicAttack = 50,
        MagicDefense = 28,
        Speed = 32
    }; // 280

    public static CharacterData DefenseSoldier = new CharacterData()
    {
        Hp = 46,
        Mp = 48,
        MaxHp = 46,
        MaxMp = 48,
        PhysAttack = 28,
        PhysDefense = 50,
        MagicAttack = 30,
        MagicDefense = 50,
        Speed = 28
    }; // 280

    public static CharacterData ApplyElementsToSoldier(CharacterData soldierData, MagicElement weak, MagicElement strong)
    {
        CharacterData soldier = soldierData;
        soldier.WeakElement = weak;
        soldier.StrongElement = strong;
        // TODO: Add appropriate moves
        return soldier;
    }

}
