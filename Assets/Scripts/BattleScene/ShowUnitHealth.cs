using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUnitHealth : ShowUnitStat
{
    protected override float NewStatValue()
    {
        if (unit != null)
        {
            return unit.GetComponent<UnitStats>().health;
        }
        else
        {
            return 0f;
        }
    }
}
