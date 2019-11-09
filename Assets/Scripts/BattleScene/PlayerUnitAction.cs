using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUnitAction : MonoBehaviour
{
    [SerializeField]
    private GameObject physicalAttack;

    [SerializeField]
    private GameObject magicalAttack;

    private GameObject currentAttack;

    private void Awake()
    {
        physicalAttack = Instantiate(physicalAttack, transform) as GameObject;
        magicalAttack = Instantiate(magicalAttack, transform) as GameObject;

        physicalAttack.GetComponent<AttackTarget>().owner = gameObject;
        magicalAttack.GetComponent<AttackTarget>().owner = gameObject;

        currentAttack = physicalAttack;
    }

    public void SelectAttack(bool physical)
    {
        currentAttack = (physical) ? physicalAttack : magicalAttack;
    }

    public void Act(GameObject target)
    {
        BattleSceneController.instance.RestorePlayerUnitColours();
        currentAttack.GetComponent<AttackTarget>().Hit(target);
        GameObject.Find("TurnSystem").GetComponent<TurnSystem>().StartNextTurn();
    }

    public void UpdateHud()
    {
        GameObject playerUnitFace = GameObject.Find("PlayerUnitFace") as GameObject;
        string currentCharacter = gameObject.GetComponent<UnitStats>().CurrentCharacterData.CharacterId.ToString();
        playerUnitFace.GetComponent<Image>().sprite = Resources.Load<Sprite>($"BattleScene/FaceIcon{currentCharacter}");

        GameObject playerUnitHealthBar = GameObject.Find("PlayerUnitHealthBar") as GameObject;
        playerUnitHealthBar.GetComponent<ShowUnitHealth>().ChangeUnit(gameObject);

        GameObject playerUnitManaBar = GameObject.Find("PlayerUnitManaBar") as GameObject;
        playerUnitManaBar.GetComponent<ShowUnitMana>().ChangeUnit(gameObject);
    }
}
