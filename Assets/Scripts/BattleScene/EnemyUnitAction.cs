using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitAction : MonoBehaviour
{
    [SerializeField]
    private GameObject physicalAttack;

    [SerializeField]
    private GameObject magicalAttack;

    [SerializeField]
    private string targetsTag;

    private void Awake()
    {
        physicalAttack = Instantiate(physicalAttack, transform) as GameObject;
        magicalAttack = Instantiate(magicalAttack, transform) as GameObject;

        physicalAttack.GetComponent<AttackTarget>().owner = gameObject;
        magicalAttack.GetComponent<AttackTarget>().owner = gameObject;
    }

    private GameObject FindRandomTarget()
    {
        GameObject[] possibleTargets = GameObject.FindGameObjectsWithTag(targetsTag);

        if (possibleTargets.Length > 0)
        {
            int targetIndex = Random.Range(0, possibleTargets.Length);
            GameObject target = possibleTargets[targetIndex];
            return target;
        }
        return null;
    }

    public void Act()
    {
        GameObject target = FindRandomTarget();
        Debug.Log($"{gameObject.name} targeting {target.name}");
        int num = Random.Range(1, 2);
        if (num == 1)
        {
            physicalAttack.GetComponent<AttackTarget>().Hit(target);
        }
        else
        {
            magicalAttack.GetComponent<AttackTarget>().Hit(target);
        }      
    }

}
