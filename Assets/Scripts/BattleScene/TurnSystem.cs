using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    private List<UnitStats> unitsStats;

    private BattleSceneController Controller
    {
        get { return BattleSceneController.instance; }
    }

    [SerializeField]
    private GameObject actionsMenu, enemyUnitsMenu;

    public void StartTurns()
    {
        unitsStats = new List<UnitStats>();
        GameObject[] playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
        foreach (GameObject playerUnit in playerUnits)
        {
            UnitStats currentUnitStats = playerUnit.GetComponent<UnitStats>();
            currentUnitStats.CalculateNextActTurn(0);
            unitsStats.Add(currentUnitStats);
        }

        GameObject[] enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
        foreach (GameObject enemyUnit in enemyUnits)
        {
            UnitStats currentUnitStats = enemyUnit.GetComponent<UnitStats>();
            currentUnitStats.CalculateNextActTurn(0);
            unitsStats.Add(currentUnitStats);
        }

        unitsStats.Sort();

        actionsMenu.SetActive(false);
        enemyUnitsMenu.SetActive(false);
        StartNextTurn();
    }

    public void StartNextTurn()
    {
        StartCoroutine(NextTurn());
    }

    public IEnumerator NextTurn()
    {
        Debug.Log("Turn start");
        GameObject[] remainingEnemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
        if (remainingEnemyUnits.Length == 0)
        {
            //enemyEncounter.GetComponent<CollectReward>().collectReward();
            Debug.Log("No enemies left; leaving battle.");
            Controller.LoadNextScene();
        }

        GameObject[] remainingPlayerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
        if (remainingPlayerUnits.Length == 0)
        {
            Debug.Log("No player units. Game over.");
            Controller.GameOver();
            yield break;
        }
        Debug.Log($"Number of units: {unitsStats.Count}");
        UnitStats currentUnitStats = unitsStats[0];
        unitsStats.Remove(currentUnitStats);

        if (!currentUnitStats.IsDead())
        {
            GameObject currentUnit = currentUnitStats.gameObject;
            Debug.Log($"Current unit is {currentUnit.name}");

            currentUnitStats.CalculateNextActTurn(currentUnitStats.NextActTurn);
            unitsStats.Add(currentUnitStats);
            //unitsStats.Sort();

            if (currentUnit.tag == "PlayerUnit")
            {
                Debug.Log("PlayerUnit acting");
                Controller.DarkenOtherPlayerUnits(currentUnit);
                Controller.SelectCurrentUnit(currentUnit);
                Controller.ActionsMenu.SetActive(true);
                CheckManaAvailability(currentUnit.GetComponent<UnitStats>());
                currentUnit.GetComponent<PlayerUnitAction>().UpdateHud();
                yield break;
            }
            else if (currentUnit.tag == "EnemyUnit")
            {
                Debug.Log("EnemyUnit acting");
                currentUnit.GetComponent<EnemyUnitAction>().Act();
                yield return new WaitForSeconds(3);
                Debug.Log("EnemyUnit action finished");
            }
            else
            {
                Debug.Log($"Unrecognised unit! {currentUnit.tag}");
            }
        }
        Debug.Log($"Next turn: {unitsStats[0]}");
        yield return NextTurn();
    }

    private void CheckManaAvailability(UnitStats currentUnit)
    {
        float manaCost = GameObject.Find("MagicalAttack").GetComponent<AttackTarget>().manaCost;
        Button magicAttackButton = Controller.ActionsMenu.transform.Find("MagicAttackIcon").gameObject.GetComponent<Button>();
        if (currentUnit.mana < manaCost)
        {
            magicAttackButton.interactable = false;
        }
        else
        {
            magicAttackButton.interactable = true;
        }

    }


}
