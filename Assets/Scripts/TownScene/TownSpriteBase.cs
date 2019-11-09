using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class TownSpriteBase : MonoBehaviour
{
    // Initialises to false
    public abstract bool TalkedTo { get; set; }

    public TownSceneController Controller
    {
        get { return TownSceneController.instance; }
    }

    public Image SpeechBubble
    {
        get { return gameObject.transform.Find("SpeechBubble").gameObject.GetComponent<Image>(); }
    }
    
    private Transform Transform
    {
        get { return gameObject.GetComponent<Transform>(); }
    }

    public TownDialogue TownDialogueBox
    {
        get { return Controller.TextBoxBackground.GetComponent<TownDialogue>(); }
    }

    public void SetUpImages(string imageName, Vector3 position, Vector3 scale)
    {
        gameObject.GetComponent<Image>().sprite = LoadTownSpriteResource(imageName);

        Transform.localPosition = position;
        Transform.localScale = scale;

        SpeechBubbleImageTalkedTo(TalkedTo);

        gameObject.SetActive(true);
    }

    private Sprite LoadTownSpriteResource(string imageName)
    {
        return Resources.Load<Sprite>($"TownScene/Sprites/{imageName}");
    }

    public void SpeechBubbleImageTalkedTo(bool talkedTo)
    {
        if (talkedTo == true)
        {
            SpeechBubble.sprite = Resources.Load<Sprite>("TownScene/TownSpriteSpeechBubbleTalkedTo");
        }
        else if (talkedTo == false)
        {
            SpeechBubble.sprite = Resources.Load<Sprite>("TownScene/TownSpriteSpeechBubble");
        }
    }
}
