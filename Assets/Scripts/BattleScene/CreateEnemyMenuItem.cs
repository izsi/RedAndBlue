using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateEnemyMenuItem : MonoBehaviour
{
    [SerializeField]
    private GameObject targetEnemyUnitPrefab;

    [SerializeField]
    private Sprite menuItemSprite;

    [SerializeField]
    private Vector2 initialPosition, itemDimensions;

    [SerializeField]
    private KillEnemy killEnemyScript;

    private void Awake()
    {
        GameObject enemyUnitsMenu = GameObject.Find("EnemyUnitsMenu");
        GameObject[] existingItems = GameObject.FindGameObjectsWithTag("TargetEnemyUnit");
        Vector2 nextPosition = new Vector2(initialPosition.x + (existingItems.Length * itemDimensions.x), initialPosition.y);

        GameObject targetEnemyUnit = Instantiate(targetEnemyUnitPrefab, enemyUnitsMenu.transform) as GameObject;
        targetEnemyUnit.name = "Target" + gameObject.name;
        targetEnemyUnit.transform.localPosition = nextPosition;
        targetEnemyUnit.transform.localScale = new Vector2(0.7f, 0.7f);
        targetEnemyUnit.GetComponent<Button>().onClick.AddListener(() => SelectEnemyTarget());
        targetEnemyUnit.GetComponent<Image>().sprite = menuItemSprite;

        killEnemyScript.menuItem = targetEnemyUnit;
    }

    public void SelectEnemyTarget()
    {
        BattleSceneController.instance.AttackEnemyTarget(gameObject);
    }

}
