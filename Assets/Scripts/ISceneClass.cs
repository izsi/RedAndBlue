using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISceneClass
{
    SceneType SceneType { get; }
    string SceneName { get; } // Remember to add to SceneFinder

}
