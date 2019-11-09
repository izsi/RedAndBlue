using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneSprite : TownSpriteBase
{
    public override bool TalkedTo { get; set; }
    public string[][] Dialogue;
    public ISceneClass NextScene;

    public void SetUpOnClick(ISceneClass nextScene, string[][] dialogue)
    {
        NextScene = nextScene;
        Dialogue = dialogue;
    }

    public void ActionsOnClick()
    {
        if (Controller.IsRunningDialogue == true)
            return;
        else
            StartCoroutine(RunDialogueAndWaitForConfirmation());
    }

    public IEnumerator RunDialogueAndWaitForConfirmation()
    {
        yield return StartCoroutine(TownDialogueBox.RunDialogue(Dialogue, false));
        Controller.Confirmation.SetActive(true);
        yield return StartCoroutine(WaitForConfirmation());

        string choiceMade = Controller.ConfirmationChoice;
        Controller.ConfirmationChoice = "";
        if (choiceMade == "Yes")
        {
            DataManager.instance.LoadNextScene(NextScene);
        }
        else if (choiceMade == "No")
        {
            Controller.Confirmation.SetActive(false);
            Controller.TextBoxBackground.SetActive(false);
        }
        else
        {
            Debug.Log("Confirmation choice not Yes or No");
            Controller.Confirmation.SetActive(false);
            Controller.TextBoxBackground.SetActive(false);
        }
    }

    public IEnumerator WaitForConfirmation()
    {
        bool done = false;
        while (!done)
        {
            if (Controller.ConfirmationChoice == "Yes" || Controller.ConfirmationChoice == "No")
            {
                done = true;
            }
            yield return null;
        }
    }
}
