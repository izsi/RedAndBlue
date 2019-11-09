using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class BattleSceneBase : ISceneClass
{
    public SceneType SceneType
    {
        get { return SceneType.Battle; }
    }

    public abstract string SceneName { get; }

    public abstract ISceneClass NextScene { get; set; }

    public abstract void SetUpScene();

    public void SetUpPlayerUnits()
    {
        var partyMembers = DataManager.instance.CurrentState.PartyMembers;
        GameObject[] playerUnitObjects = GameObject.FindGameObjectsWithTag("PlayerUnit");
        UnitStats player1Stats = playerUnitObjects.Single(r => r.name == "PlayerUnit1").GetComponent<UnitStats>();
        UnitStats player2Stats = playerUnitObjects.Single(r => r.name == "PlayerUnit2").GetComponent<UnitStats>();
        UnitStats player3Stats = playerUnitObjects.Single(r => r.name == "PlayerUnit3").GetComponent<UnitStats>();
        UnitStats player4Stats = playerUnitObjects.Single(r => r.name == "PlayerUnit4").GetComponent<UnitStats>();

        player1Stats.SetUpUnitCharacter(partyMembers[0]);
        if (partyMembers.Count >= 2)
        {
            player2Stats.SetUpUnitCharacter(partyMembers[1]);
        }
        else
        {
            player2Stats.SelfDestruct();
        }

        if (partyMembers.Count >= 3)
        {
            player3Stats.SetUpUnitCharacter(partyMembers[2]);
        }
        else
        {
            player3Stats.SelfDestruct();
        }

        if (partyMembers.Count >= 4)
        {
            player4Stats.SetUpUnitCharacter(partyMembers[3]);
        }
        else
        {
            player4Stats.SelfDestruct();
        }

    }

    public void SetUpEnemyUnits(CharacterId bossId, List<CharacterData> soldiers)
    {
        GameObject[] enemyUnitObjects = GameObject.FindGameObjectsWithTag("EnemyUnit");

        var bossData = ApplyBossBonusToCharacter(DataManager.instance.CurrentState.Characters[bossId]);
        enemyUnitObjects.Single(r => r.name == "EnemyUnit1").GetComponent<UnitStats>().SetUpUnitCharacter(bossData);

        enemyUnitObjects.Single(r => r.name == "EnemyUnit2").GetComponent<UnitStats>().SetUpUnitCharacter(soldiers[0]);
        enemyUnitObjects.Single(r => r.name == "EnemyUnit3").GetComponent<UnitStats>().SetUpUnitCharacter(soldiers[1]);
        enemyUnitObjects.Single(r => r.name == "EnemyUnit4").GetComponent<UnitStats>().SetUpUnitCharacter(soldiers[2]);
    }

    private CharacterData ApplyBossBonusToCharacter(CharacterData characterData)
    {
        CharacterData newData = characterData;
        newData.MaxHp = Mathf.Round(newData.MaxHp * 1.4f); //RoundFloatToInteger(newData.MaxHp * 1.4f);
        newData.MaxMp = RoundFloatToInteger(newData.MaxMp * 2f);
        newData.Hp = newData.MaxHp;
        newData.Mp = newData.MaxMp;
        newData.PhysAttack = RoundFloatToInteger(newData.PhysAttack * 1.2f);
        newData.PhysDefense = RoundFloatToInteger(newData.PhysDefense * 1.2f);
        newData.MagicAttack = RoundFloatToInteger(newData.MagicAttack * 1.2f);
        newData.MagicDefense = RoundFloatToInteger(newData.MagicDefense * 1.2f);

        return newData;            
    }

    private float RoundFloatToInteger(float num)
    {
        return (float)Math.Round(num, 0);
    }

}

