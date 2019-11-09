using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScene : DialogueSceneBase
{
    private readonly string _sceneTextPrefix = "TestDialogueScene";

    // Cannot instantiate NextScene immediately because circular relationships
    // will cause stack overflows
    private ISceneClass _newNextScene;

    public override string SceneName { get { return "TestScene"; } }

    public override ISceneClass NextScene
    {
        get
        {
            if (_newNextScene == null)
            {
                return new Town_Initial();
            }
            else
            {
                return _newNextScene;
            }
        }
        set
        {
            _newNextScene = value;
        }
    }

    public override IEnumerator RunScene()
    {
        SetDialogueAndSpeaker("MainCharacterName", $"{_sceneTextPrefix}1");
        yield return WaitForPlayerNextWithTextSkip();

        SetDialogueAndSpeaker("MainCharacterName", $"{_sceneTextPrefix}2");
        yield return WaitForPlayerNextWithTextSkip();

        SetDialogueSprites(null, "DialogueBlue1Normal", null);
        SetDialogueAndSpeaker("Blue1Name", $"{_sceneTextPrefix}3");
        yield return WaitForPlayerNextWithTextSkip();

        SetDialogueSprites("DialogueBlue2Normal", null, "DialogueBlue1Normal");
        SetDialogueAndSpeaker("Blue2Name", $"{_sceneTextPrefix}4");
        yield return WaitForPlayerNextWithTextSkip();

        SetDialogueSprites("", "DialogueRed1Normal", "");
        SetDialogueAndSpeaker("Red1Name", $"{_sceneTextPrefix}5");
        yield return WaitForPlayerNextWithTextSkip();

        SetUpChoices($"{_sceneTextPrefix}FirstOption", $"{_sceneTextPrefix}SecondOption", $"{_sceneTextPrefix}ThirdOption");
        yield return WaitForChoiceSelected();
        DeactivateAllChoices();
        int choiceMade = Controller.ChoiceMade;
        Controller.ChoiceMade = -1;

        if (choiceMade == 1 || choiceMade == 2)
        {
            SetDialogueAndSpeaker("MainCharacterName", $"{_sceneTextPrefix}6");
            yield return WaitForPlayerNextWithTextSkip();
        }
        else if (choiceMade == 3)
        {
            Controller.AmityUp.GetComponent<Image>().sprite = Resources.Load<Sprite>($"DialogueScene/AmityUpBlue1");
            SetDialogueAndSpeaker("MainCharacterName", $"{_sceneTextPrefix}7");
            yield return WaitForPlayerNextWithTextSkip();
        }

        SetDialogueAndSpeaker("MainCharacterName", $"{_sceneTextPrefix}8");
        yield return WaitForPlayerNextWithTextSkip();
    }
}
