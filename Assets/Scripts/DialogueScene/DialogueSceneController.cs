using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueSceneController : MonoBehaviour
{
    public static DialogueSceneController instance;

    public Image BackgroundImage;
    public Text TextBox;
    public Text SpeakerNameText;
    public GameObject DialogueSpriteCentre;
    public GameObject DialogueSpriteLeft;
    public GameObject DialogueSpriteRight;
    public GameObject MultipleChoice;
    public GameObject AmityUp;

    public int ChoiceMade = -1;

    private ISceneClass _currentScene;

    public void Awake()
    {
        Debug.Log("Loading DialogueSceneController");
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
            //Debug.Log("No scene to play. Returning to Title.");
            //DataManager.instance.LoadNextScene(new TitleScene());
            Debug.Log("Playing test scene");
            _currentScene = SceneFinder.GetSceneFromName("TestScene");
        }
        else
        {
            _currentScene = SceneFinder.GetSceneFromName(DataManager.instance.CurrentState.CurrentScene);
        }
    }

    private IEnumerator Start()
    {
        Debug.Log($"Loading scene. Name: {_currentScene.GetType().ToString()}, Type: {_currentScene.SceneType.ToString()}");
        DialogueSceneBase scene = (DialogueSceneBase)_currentScene;
        yield return StartCoroutine(scene.RunScene());

        DataManager.instance.LoadNextScene(scene.NextScene);
    }
}
