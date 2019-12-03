using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_InitialBlue1 : DialogueSceneBase
{
    private readonly string _sceneTextPrefix = "Dialogue_InitialBlue1_";

    private ISceneClass _newNextScene;

    public override string SceneName { get { return "Dialogue_InitialBlue1"; } }

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
        SetDialogueSprites("", "DialogueBlue1Normal", "");
        SetDialogueAndSpeaker("Blue1Name", $"{_sceneTextPrefix}1");
        yield return WaitForPlayerNextWithTextSkip();

        SetDialogueAndSpeaker("MainCharacterName", $"{_sceneTextPrefix}2");
        yield return WaitForPlayerNextWithTextSkip();

        SetDialogueAndSpeaker("Blue1Name", $"{_sceneTextPrefix}3");
        yield return WaitForPlayerNextWithTextSkip();

        SetDialogueAndSpeaker("MainCharacterName", $"{_sceneTextPrefix}4");
        yield return WaitForPlayerNextWithTextSkip();

        SetUpChoices($"{_sceneTextPrefix}FirstOption", $"{_sceneTextPrefix}SecondOption", $"{_sceneTextPrefix}ThirdOption");
        yield return WaitForChoiceSelected();
        DeactivateAllChoices();
        int choiceMade = Controller.ChoiceMade;
        Controller.ChoiceMade = -1;

        if (choiceMade == 1)
        {
            SetDialogueAndSpeaker("MainCharacterName", $"{_sceneTextPrefix}5");
            yield return WaitForPlayerNextWithTextSkip();

            Controller.AmityUp.GetComponent<Image>().sprite = Resources.Load<Sprite>($"DialogueScene/AmityUpBlue1");

            SetDialogueAndSpeaker("Blue1Name", $"{_sceneTextPrefix}6");
            yield return WaitForPlayerNextWithTextSkip();
        }
        else if (choiceMade == 2 || choiceMade == 3)
        {
            SetDialogueAndSpeaker("MainCharacterName", $"{_sceneTextPrefix}7");
            yield return WaitForPlayerNextWithTextSkip();
            SetDialogueAndSpeaker("Blue1Name", $"{_sceneTextPrefix}8");
            yield return WaitForPlayerNextWithTextSkip();
        }

        SetDialogueAndSpeaker("Blue1Name", $"{_sceneTextPrefix}9");
        yield return WaitForPlayerNextWithTextSkip();

    }
}
