using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddButtonCallBack : MonoBehaviour
{
    [SerializeField]
    private bool physical;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => AddCallBack());
    }

    private void AddCallBack()
    {
        BattleSceneController.instance.SelectAttack(physical);
    }
}
