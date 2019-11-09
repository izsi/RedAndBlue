using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownDialogue : MonoBehaviour
{
    private TownSceneController Controller
    {
        get { return TownSceneController.instance; }
    }

    private LocalisedText SpeakerName
    {
        get { return gameObject.transform.Find("SpeakerName").GetComponent<LocalisedText>(); }
    }

    private LocalisedText DialogueText
    {
        get { return gameObject.transform.Find("DialogueText").GetComponent<LocalisedText>(); }
    }

    // [ [speakerNameKey, dialogueKey], [speakerNameKey, dialogueKey] ]
    public IEnumerator RunDialogue(string[][] dialogue, bool disableWhenDone = true)
    {
        Controller.IsRunningDialogue = true;

        Controller.TextBoxBackground.SetActive(true);
        foreach (string[] text in dialogue)
        {
            SpeakerName.Key = text[0];
            DialogueText.Key = text[1];
            yield return WaitForPlayerNextWithTextSkip();
        }

        if (disableWhenDone == true)
        {
            Controller.TextBoxBackground.SetActive(false);
        }
        Controller.IsRunningDialogue = false;
    }

    private IEnumerator WaitForPlayerNextWithTextSkip()
    {
        bool done = false;
        while (!done)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                if (DialogueText.IsCurrentlyAnimating == true)
                {
                    DialogueText.SkipAnimation();
                }
                else
                {
                    done = true;
                }
            }
            yield return null;
        }
    }
}
