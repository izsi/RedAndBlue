using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Town_Initial : TownSceneBase, ISceneClass
{
    // Cannot instantiate NextScene immediately because circular relationships will cause stack overflows
    private ISceneClass _newNextScene;

    public override string SceneName { get { return "Town_Initial"; } }

    public override ISceneClass NextScene
    {
        get
        {
            if (_newNextScene == null)
            {
                return new TestScene();
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

    public override void SetupScene()
    {
        // Testing
        //DataManager.instance.CurrentState.Faction = PlayerFaction.Blue;

        var townSprites = GetTownSprites();

        TownDialogueSprite dialogueSprite = townSprites[0];
        var dialogueSpriteDialogue = new string[][] { new string[] { "Blue1Name", "Town_InitialBlue1TalkedTo1" }, new string[] { "Blue1Name", "Town_InitialBlue1TalkedTo2" } };        
        dialogueSprite.SetUpDialogue(new TestScene(), dialogueSpriteDialogue);
        dialogueSprite.SetUpImages("TownBlue1", TopLeftSprite(dialogueSprite).localPosition, TopLeftSprite(dialogueSprite).localScale);

        NextSceneSprite nextSceneSprite = Controller.NextSceneSprite.GetComponent<NextSceneSprite>();
        var nextSceneConfirmation = new string[][] { new string[] { "SoldierName", "Town_InitialSoldierConfirmation1" }, new string[] { "SoldierName", "Town_InitialSoldierConfirmation2" } };
        nextSceneSprite.SetUpOnClick(new Narration_Intro(), nextSceneConfirmation);
        nextSceneSprite.SetUpImages("TownSoldierBlue", BottomRightSprite(nextSceneSprite).localPosition, BottomRightSprite(nextSceneSprite).localScale);

    }
    
}

public class Town_InitialChild1 : TownSceneBase
{
    private ISceneClass _nextScene = new Town_Initial();
    public override ISceneClass NextScene
    {
        get { return _nextScene; }
        set { _nextScene = value; }
    }
    public override string SceneName { get { return "Town_InitialChild1"; } }

    public override void SetupScene()
    {
        var townSprites = GetTownSprites();

        TownDialogueSprite dialogueSprite = townSprites[0];
        dialogueSprite.DialogueScene = new TestScene();
    }
}
