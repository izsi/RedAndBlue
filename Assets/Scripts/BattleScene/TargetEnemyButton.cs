using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEnemyButton : MonoBehaviour
{
    public GameObject TargetUnit;

    public void SelectEnemyTarget()
    {
        BattleSceneController.instance.AttackEnemyTarget(TargetUnit);
    }
}
