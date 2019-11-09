using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class UnitStats : MonoBehaviour, IComparable
{
    public float health;
    public float mana;
    public float attack;
    public float magicAttack;
    public float defense;
    public float magicDefense;
    public float speed;

    public Animator animator;
    public GameObject damageTextPrefab;

    public int NextActTurn;
    public GameObject Selector;
    public CharacterData CurrentCharacterData;

    private bool dead = false; 
    
    public void SetUpUnitCharacter(CharacterId characterId)
    {
        CurrentCharacterData = DataManager.instance.CurrentState.Characters[characterId];
        SetUpUnit();
    }

    public void SetUpUnitCharacter(CharacterData characterData)
    {
        CurrentCharacterData = characterData;
        SetUpUnit();
    }

    private void SetUpUnit()
    {
        health = CurrentCharacterData.Hp * 2; // Health multiplier
        mana = CurrentCharacterData.Mp * 2; // Mana multiplier
        attack = CurrentCharacterData.PhysAttack;
        magicAttack = CurrentCharacterData.MagicAttack;
        defense = CurrentCharacterData.PhysDefense;
        magicDefense = CurrentCharacterData.MagicDefense;
        speed = CurrentCharacterData.Speed;

        if (gameObject.GetComponent<PlayerUnitAction>() != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"BattleScene/PlayerUnit{CurrentCharacterData.CharacterId.ToString()}");
        }
        else if (gameObject.GetComponent<EnemyUnitAction>() != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"BattleScene/EnemyUnit{CurrentCharacterData.CharacterId.ToString()}");
        }
        else
        {
            Debug.Log($"Broken unit for character {CurrentCharacterData.CharacterId.ToString()}");
        }
    }

    public void CalculateNextActTurn(int currentTurn)
    {
        NextActTurn = currentTurn + (int)Math.Ceiling(100.0f / speed);
    }

    public int CompareTo(object otherStats)
    {
        return NextActTurn.CompareTo(((UnitStats)otherStats).NextActTurn);
    }

    public bool IsDead() { return dead; }

    public void ReceiveDamage(float damage)
    {
        health -= damage;
        //animator.Play("Hit");

        GameObject HudCanvas = GameObject.Find("HudCanvas");
        GameObject damageText = Instantiate(damageTextPrefab, HudCanvas.transform) as GameObject;
        damageText.GetComponent<Text>().text = damage.ToString();
        Vector3 position = gameObject.transform.position;       
        position.y = position.y + gameObject.GetComponent<SpriteRenderer>().bounds.extents.y * 0.6f;
        // extents.y is centre to top. Multiply by 0.6 to bring down closer to head of character
        damageText.transform.position = position;
        damageText.transform.localScale = new Vector2(1.0f, 1.0f);

        if (health <= 0)
        {
            Debug.Log($"Removing {gameObject.name}, {CurrentCharacterData.CharacterId}");
            SelfDestruct();
        }
    }

    public void SelfDestruct()
    {
        dead = true;
        gameObject.tag = "DeadUnit";
        if (Selector != null)
        {
            Destroy(Selector);
        }
        Destroy(gameObject);
    }
}
