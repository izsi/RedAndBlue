using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTarget : MonoBehaviour
{
    public GameObject owner;

    [SerializeField]
    private string attackAnimation;

    [SerializeField]
    private bool magicAttack;
        
    public float manaCost;

    [SerializeField]
    private float minAttackMultiplier;

    [SerializeField]
    private float maxAttackMultiplier;


    public void Hit(GameObject target)
    {
        UnitStats ownerStats = owner.GetComponent<UnitStats>();
        UnitStats targetStats = target.GetComponent<UnitStats>();

        if (ownerStats.mana >= manaCost)
        {
            float attackMultiplier = (Random.value * (maxAttackMultiplier - minAttackMultiplier)) + minAttackMultiplier;
            float damage = (magicAttack) ? attackMultiplier * ownerStats.magicAttack : attackMultiplier * ownerStats.attack;
           
            if (magicAttack)
            {
                damage = Mathf.Max(0, damage - targetStats.magicDefense);
            }
            else
            {
                damage = Mathf.Max(0, damage - targetStats.defense);
            }
            if (damage < 1)
            {
                damage = 1;
            }
            damage = Mathf.Round(damage);
            //owner.GetComponent<Animator>().Play(attackAnimation);
            targetStats.ReceiveDamage(damage);
            ownerStats.mana -= manaCost;
        }

    }

}
