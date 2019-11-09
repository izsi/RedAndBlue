using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NarrationSceneController : MonoBehaviour
{
    public Image BackgroundImage;
    public Text NarrationText;

    public static NarrationSceneController instance;

    private ISceneClass currentScene;

    void Awake()
    {
        Debug.Log("Loading NarrationSceneController");
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        if (DataManager.instance.CurrentState.CurrentScene == null)
        {
            currentScene = new Narration_Intro();
            DataManager.instance.CurrentState.CurrentScene = currentScene.SceneName;
        }
        else
        {
            currentScene = SceneFinder.GetSceneFromName(DataManager.instance.CurrentState.CurrentScene);
        }
    }

    private IEnumerator Start()
    {
        Debug.Log($"Loading scene. Name: {currentScene.GetType().ToString()}, Type: {currentScene.SceneType.ToString()}");
        //var scene = NarrationSceneSelector.GetNarrationScene(currentScene.Name);
        //yield return StartCoroutine(scene.RunScene());
        var scene = (NarrationSceneBase)currentScene;
        yield return StartCoroutine(scene.RunScene());

        DataManager.instance.LoadNextScene(scene.NextScene);
    }
}
