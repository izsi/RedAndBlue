using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class BattleSceneController : MonoBehaviour
{
    public GameObject TurnSystem;
    public GameObject ActionsMenu;
    public GameObject EnemyUnitsMenu;
    public GameObject ModalBlocker;

    public static BattleSceneController instance; 

    public BattleSceneBase CurrentScene { get; set; }

    private GameObject currentUnit;

    private void Awake()
    {
        Debug.Log("Loading BattleSceneController");
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        ModalBlocker.SetActive(true);
        ModalBlocker.transform.Find("LoadingOverlay").gameObject.SetActive(true);
    }

    private void Start()
    {
        // TESTING
        Debug.Log("Starting Battle Scene with test data");
        DataManager.instance.LoadDataFromSlot(1, loadScene: false);
        DataManager.instance.CurrentState.CurrentScene = "Battle_Blue1";
        // TESTING END

        CurrentScene = SceneFinder.GetBattleSceneFromName(DataManager.instance.CurrentState.CurrentScene);
        CurrentScene.SetUpScene();

        Debug.Log("Set up done, starting Turn System");
        ModalBlocker.transform.Find("LoadingOverlay").gameObject.SetActive(false);
        ModalBlocker.SetActive(false);
        TurnSystem.GetComponent<TurnSystem>().StartTurns();
    }

    public void LoadNextScene()
    {
        DataManager.instance.LoadNextScene(CurrentScene.NextScene);
    }

    public void SelectCurrentUnit(GameObject unit)
    {
        currentUnit = unit;
        ActionsMenu.SetActive(true);
        currentUnit.GetComponent<PlayerUnitAction>().UpdateHud();
    }

    public void SelectAttack(bool physical)
    {
        currentUnit.GetComponent<PlayerUnitAction>().SelectAttack(physical);
        ActionsMenu.SetActive(false);
        EnemyUnitsMenu.SetActive(true);
    }

    public void AttackEnemyTarget(GameObject target)
    {
        ActionsMenu.SetActive(false);
        EnemyUnitsMenu.SetActive(false);

        currentUnit.GetComponent<PlayerUnitAction>().Act(target);
    }

    public void DarkenOtherPlayerUnits(GameObject currentUnit)
    {
        GameObject[] playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
        foreach (var unit in playerUnits)
        {
            if (unit.name != currentUnit.name)
            {
                Color newcolor = unit.GetComponent<SpriteRenderer>().color;
                newcolor.r = newcolor.r - 0.3f;
                newcolor.g = newcolor.g - 0.3f;
                newcolor.b = newcolor.b - 0.3f;
                unit.GetComponent<SpriteRenderer>().color = newcolor;
            }
        }
    }

    public void RestorePlayerUnitColours()
    {
        GameObject[] playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
        foreach (var unit in playerUnits)
        {
            unit.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public void GameOver()
    {
        ModalBlocker.SetActive(true);
        ModalBlocker.transform.Find("GameOverOverlay").gameObject.SetActive(true);
    }

}
