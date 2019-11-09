using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NarrationSceneBase : ISceneClass
{
    public SceneType SceneType
    {
        get { return SceneType.Narration; }
    }

    public abstract string SceneName { get; }

    public abstract IEnumerator RunScene();

    public abstract ISceneClass NextScene { get; set; }

    public NarrationSceneController Controller
    {
        get { return NarrationSceneController.instance; }
    }

    public LocalisedText NarrationScript
    {
        get { return Controller.NarrationText.GetComponent<LocalisedText>(); }
    }

    public IEnumerator WaitForPlayerNextWithTextSkip()
    {
        bool done = false;
        while (!done)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                if (NarrationScript.IsCurrentlyAnimating == true)
                {
                    NarrationScript.SkipAnimation();
                }
                else
                {
                    done = true;
                }
            }
            yield return null;
        }
    }

    public void SetNarrationText(string textKey)
    {
        NarrationScript.Key = textKey;
    }

    public void SetBackground(string imageName)
    {
        Controller.BackgroundImage.sprite = Resources.Load<Sprite>($"NarrationScene/{SceneName}/{imageName}");
    }
}
