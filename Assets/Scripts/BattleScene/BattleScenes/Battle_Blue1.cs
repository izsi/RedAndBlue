using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Battle_Blue1 : BattleSceneBase
{
    public override string SceneName
    {
        get { return "Battle_Blue1"; }
    }

    public override ISceneClass NextScene
    {
        get { throw new System.NotImplementedException(); }
        set { NextScene = value; }
    }

    public override void SetUpScene()
    {
        Debug.Log($"Setting up {this.ToString()}");
        SetUpPlayerUnits();

        CharacterData boss = DataManager.instance.CurrentState.Characters.Single(r => r.Key == CharacterId.Red3).Value;

        List<CharacterData> Soldiers = new List<CharacterData>
        {
            SoldierCharacterData.PhysSoldier,
            SoldierCharacterData.AttackSoldier,
            SoldierCharacterData.DefenseSoldier
        };
        foreach (var soldier in Soldiers)
        {
            soldier.CharacterId = CharacterId.RedSoldier;
            soldier.Faction = Faction.Red;
        }
        SetUpEnemyUnits(boss.CharacterId, Soldiers);

    }

}
