using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narration_Intro : NarrationSceneBase
{
    private ISceneClass _nextScene = new Dialogue_InitialMonologue();

    public override ISceneClass NextScene
    {
        get { return _nextScene; }
        set { _nextScene = value; }
    }

    public override string SceneName
    {
        get { return "Narration_Intro"; }
    }

    public override IEnumerator RunScene()
    {
        SetBackground("Narration_Intro_B1");
        SetNarrationText("Narration_Intro_1");
        yield return WaitForPlayerNextWithTextSkip();
        SetBackground("Narration_Intro_B1_2");
        SetNarrationText("Narration_Intro_2");
        yield return WaitForPlayerNextWithTextSkip();

        SetBackground("Narration_Intro_B2");
        SetNarrationText("Narration_Intro_3");
        yield return WaitForPlayerNextWithTextSkip();
        SetNarrationText("Narration_Intro_4");
        yield return WaitForPlayerNextWithTextSkip();
    }

}
