using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class DialogueSceneBase : ISceneClass
{
    public SceneType SceneType
    {
        get { return SceneType.Dialogue; }
    }

    public abstract string SceneName { get; }    

    public abstract IEnumerator RunScene();

    public abstract ISceneClass NextScene { get; set; }

    public DialogueSceneController Controller
    {
        get { return DialogueSceneController.instance; }
    }

    public LocalisedText SpeakerNameScript
    {
        get { return Controller.SpeakerNameText.GetComponent<LocalisedText>(); }
    }

    public LocalisedText DialogueScript
    {
        get { return Controller.TextBox.GetComponent<LocalisedText>(); }
    }    

    public IEnumerator WaitForPlayerNextWithTextSkip()
    {
        bool done = false;
        while (!done)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                if (DialogueScript.IsCurrentlyAnimating == true)
                {
                    DialogueScript.SkipAnimation();
                }
                else
                {
                    done = true;
                }   
            }
            yield return null;
        }
    }

    public void SetDialogueAndSpeaker(string speakerNameKey, string dialogueTextKey)
    {
        if (speakerNameKey == SpeakerNameScript.Key)
        {
            // do nothing
        }
        else
        {
            SpeakerNameScript.Key = speakerNameKey;
        }

        DialogueScript.Key = dialogueTextKey;
    }

    /// <summary>
    /// string for resource image name, null to clear it out, empty string to leave it as is
    /// </summary>
    public void SetDialogueSprites(string leftSpriteImage, string centreSpriteImage, string rightSpriteImage)
    {
        SetSprite(Controller.DialogueSpriteLeft, leftSpriteImage);
        SetSprite(Controller.DialogueSpriteCentre, centreSpriteImage);
        SetSprite(Controller.DialogueSpriteRight, rightSpriteImage);
    }

    /// <summary>
    /// string for resource image name, null to clear out sprite, empty string to leave it as is
    /// </summary>
    public void SetSprite(GameObject spriteObject, string imageName)
    {
        if (imageName == "")
        {
            // do nothing
        }
        else if (imageName == null)
        {
            spriteObject.GetComponent<SpriteRenderer>().sprite = null;
        }
        else
        {
            var spriteResource = LoadSpriteResource(imageName);
            spriteObject.GetComponent<SpriteRenderer>().sprite = spriteResource;
        }      
    }

    private Sprite LoadSpriteResource(string imageName)
    {
        return Resources.Load<Sprite>($"DialogueScene/CharacterSprites/{imageName}");
    }

    public void SetUpChoices(params string[] choices)
    {
        Controller.ChoiceMade = -1;

        if (choices.Length > Controller.MultipleChoice.transform.childCount)
        {
            Debug.Log("More choices coded than are available in the scene!");
        }

        for (int i = 0; i < choices.Length; i++)
        {
            var choiceButton = Controller.MultipleChoice.transform.Find($"ChoiceButton{i + 1}");
            choiceButton.Find("Text").GetComponent<LocalisedText>().Key = choices[i];
            choiceButton.gameObject.SetActive(true);
        }       
    }

    public IEnumerator WaitForChoiceSelected()
    {
        bool done = false;
        while (!done)
        {
            if (Controller.ChoiceMade != -1)
            {
                done = true;
            }
            yield return null;
        }
    }

    public void DeactivateAllChoices()
    {
        for (int i = 0; i < Controller.MultipleChoice.transform.childCount; i++)
        {
            var choiceButton = Controller.MultipleChoice.transform.Find($"ChoiceButton{i + 1}");
            choiceButton.gameObject.SetActive(false);
        }
    }
}

