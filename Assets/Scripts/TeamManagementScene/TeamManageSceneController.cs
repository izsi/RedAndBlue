using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManageSceneController : MonoBehaviour
{
    public GameObject CharacterPanel;
    public GameObject ModalBlocker;
    public GameObject CharacterMenu;

    public static TeamManageSceneController instance;

    private void Awake()
    {
        Debug.Log("Loading TeamManagementScene Controller");
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        Debug.Log("Aspect ratio: " + Camera.main.aspect.ToString());
        if (Camera.main.aspect < 1.61)
        {
            Debug.Log("Aspect ratio smaller than 1.61");
            Vector3 charPanelScale = new Vector3(0.9f, 0.9f, 1);
            CharacterPanel.transform.localScale = charPanelScale;
        }
        
        // Testing 
        if (DataManager.instance.CurrentState.CurrentScene == null)
        {
            Debug.Log("DataManager has no CurrentScene. Loading from Slot 1.");
            DataManager.instance.LoadDataFromSlot(1);
        }

        if (DataManager.instance.CurrentState.CurrentScene != "TeamManagementScene")
        {
            Debug.Log($"Expected TeamManagementScene, got {DataManager.instance.CurrentState.CurrentScene} for current scene.");
        }

        // Assuming we only have one class of Team Management Scene
        TeamManagementScene scene = new TeamManagementScene();
        scene.SetupManagementScene();
    }

    public List<GameObject> CharacterSelectors
    {
        get
        {
            var list = new List<GameObject>();
            int counter = 0;
            while (counter < CharacterMenu.transform.childCount)
            {
                list.Add(CharacterMenu.transform.GetChild(counter).gameObject);
                counter += 1;
            }
            return list;
        }
    }

    public void SetCharacterInPanel(CharacterId characterId)
    {
        CharacterPanel.GetComponent<CharacterPanel>().SetCharacterToDisplay(characterId);
    }

}
