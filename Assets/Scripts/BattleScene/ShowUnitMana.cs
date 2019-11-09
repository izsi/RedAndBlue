using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUnitMana : ShowUnitStat
{
    protected override float NewStatValue()
    {
        if (unit != null)
        {
            return unit.GetComponent<UnitStats>().mana;
        }
        else
        {
            return 0f;
        }
    }

}
