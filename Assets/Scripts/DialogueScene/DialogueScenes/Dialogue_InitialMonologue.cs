using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_InitialMonologue : DialogueSceneBase
{
    private readonly string _sceneTextPrefix = "Dialogue_InitialMonologue_";

    // Cannot instantiate NextScene immediately because circular relationships
    // will cause stack overflows
    private ISceneClass _newNextScene;

    public override string SceneName { get { return "Dialogue_InitialMonologue"; } }

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
        SetDialogueAndSpeaker("", $"{_sceneTextPrefix}1");
        yield return WaitForPlayerNextWithTextSkip();

        SetDialogueSprites("", "DialogueMainCharacterNormal", "");
        SetDialogueAndSpeaker("MainCharacterName", $"{_sceneTextPrefix}2");
        yield return WaitForPlayerNextWithTextSkip();
    }
}
