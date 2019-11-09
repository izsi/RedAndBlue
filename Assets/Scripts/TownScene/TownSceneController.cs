using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TownSceneController : MonoBehaviour
{
    public Image BackgroundImage;
    public Image[] Sprites;
    public Button ArrowUp;
    public Button ArrowDown;
    public Button ArrowLeft;
    public Button ArrowRight;
    public GameObject TextBoxBackground;
    public GameObject Confirmation;
    public Image NextSceneSprite;
    public GameObject ModalBlocker;

    public static TownSceneController instance;

    // TODO: Make sure this is used everywhere
    public bool IsRunningDialogue { get; set; }

    public string ConfirmationChoice { get; set; }

    private TownSceneBase currentScene;

    private void Awake()
    {
        Debug.Log("Loading TownSceneController");
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
            // Testing
            currentScene = new Town_Initial();
        }
        else
        {
            currentScene = (TownSceneBase)SceneFinder.GetSceneFromName(DataManager.instance.CurrentState.CurrentScene);
        }
     
        IsRunningDialogue = false;
    }

    private void Start()
    {
        Debug.Log($"Loading scene. Name: {currentScene.GetType().ToString()}, Type: {currentScene.SceneType.ToString()}");
        var scene = currentScene;
        scene.SetupScene();
        if (DataManager.instance.TownSceneState != null)
            LoadTownState();
    }

    public void SaveTownState()
    {
        int numOfSprites = Sprites.Length;
        bool[] talkedTo = new bool[numOfSprites];
        int counter = 0;
        foreach (var sprite in Sprites)
        {
            talkedTo[counter] = sprite.GetComponent<TownDialogueSprite>().TalkedTo;
            counter += 1;
        }

        var townState = new TownSceneState
        {
            Scene = currentScene,
            SpritesTalkedTo = talkedTo
        };

        Debug.Log("Saving town state to memory");
        DataManager.instance.TownSceneState = townState;
    }

    public void LoadTownState()
    {
        if (DataManager.instance.TownSceneState.Scene == null)
        {
            return;
        }
        else if (DataManager.instance.TownSceneState.Scene.GetType() == currentScene.GetType())
        {
            Debug.Log("Loading town state from memory");
            TownSceneState state = DataManager.instance.TownSceneState;
            int counter = 0;
            foreach (var talkedTo in state.SpritesTalkedTo)
            {
                Sprites[counter].GetComponent<TownDialogueSprite>().TalkedTo = talkedTo;
                Sprites[counter].GetComponent<TownDialogueSprite>().SpeechBubbleImageTalkedTo(talkedTo);
                counter += 1;
            }
            DataManager.instance.TownSceneState = null;
        }
    }
}
