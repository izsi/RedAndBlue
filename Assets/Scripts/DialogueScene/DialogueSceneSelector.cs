using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class DialogueSceneSelector
{
    public static DialogueSceneBase GetDialogueScene(string sceneName)
    {
        switch (sceneName)
        {
            case "TestScene":
                return new TestScene();
            default:
                Debug.Log("Unrecognised dialogue scene name!");
                return null;
        }
    }
}
