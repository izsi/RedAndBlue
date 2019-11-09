using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneFinder
{
    public static ISceneClass GetSceneFromName(string name)
    { 

        switch (name)
        {
            case "TestScene":
                return new TestScene();
            case "Dialogue_InitialMonologue":
                return new Dialogue_InitialMonologue();
            case "Narration_Intro":
                return new Narration_Intro();
            case "TeamManagementScene":
                return new TeamManagementScene();
            case "Town_Initial":
                return new Town_Initial();
            case "Town_InitialChild1":
                return new Town_InitialChild1();
            case "TitleScene":
                return new TitleScene();
            default:
                Debug.Log($"Unrecognised scene name: {name}");
                throw new ArgumentException($"Unrecognised scene name: {name}");
        }

    }

    public static DialogueSceneBase GetDialogueSceneFromName(string name)
    {
        switch (name)
        {
            case "Dialogue_InitialMonologue":
                return new Dialogue_InitialMonologue();
            default:
                Debug.Log($"Unrecognised scene name: {name}");
                throw new ArgumentException($"Unrecognised scene name: {name}");
        }
    }

    public static NarrationSceneBase GetNarrationSceneFromName(string name)
    {
        switch (name)
        {
            case "Narration_Intro":
                return new Narration_Intro();
            default:
                Debug.Log($"Unrecognised scene name: {name}");
                throw new ArgumentException($"Unrecognised scene name: {name}");
        }
    }

    public static TownSceneBase GetTownSceneFromName(string name)
    {
        switch (name)
        {
            case "Town_Initial":
                return new Town_Initial();
            case "Town_InitialChild1":
                return new Town_InitialChild1();
            default:
                Debug.Log($"Unrecognised scene name: {name}");
                throw new ArgumentException($"Unrecognised scene name: {name}");
        }
    }

    public static BattleSceneBase GetBattleSceneFromName(string name)
    {
        switch (name)
        {
            case "Battle_Blue1":
                return new Battle_Blue1();
            default:
                Debug.Log($"Unrecognised scene name: {name}");
                throw new ArgumentException($"Unrecognised scene name: {name}");
        }
    }
}
