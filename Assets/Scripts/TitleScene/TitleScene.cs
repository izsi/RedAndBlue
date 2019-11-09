using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : ISceneClass
{
    public SceneType SceneType
    {
        get { return SceneType.Title; }
    }

    public string SceneName { get { return "TitleScene"; } }
}
