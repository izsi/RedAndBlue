using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TownDialogueSprite : TownSpriteBase
{
    public DialogueSceneBase DialogueScene;
    public string[][] TalkedToDialogue; // [ [speakerNameKey, dialogueKey], [speakerNameKey, dialogueKey] ]
    public override bool TalkedTo { get; set; }

    private Button ButtonComponent
    {
        get { return gameObject.GetComponent<Button>(); }
    }

    public void SetUpDialogue(DialogueSceneBase dialogueScene, string[][] talkedToDialogue)
    {
        DialogueScene = dialogueScene;
        TalkedToDialogue = talkedToDialogue;
    }

    public void ActionsOnClick()
    {
        if (Controller.IsRunningDialogue == true)
            return;

        if (TalkedTo == false)
        {
            TalkedTo = true;
            SpeechBubbleImageTalkedTo(true);
            Controller.SaveTownState();
            DataManager.instance.LoadNextScene(DialogueScene);
        }
        else
        {
            StartCoroutine(TownDialogueBox.RunDialogue(TalkedToDialogue));
        }
    }
}
