using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class TownSceneBase : ISceneClass
{
    public SceneType SceneType
    {
        get { return SceneType.Town; }
    }

    public abstract string SceneName { get; }

    public abstract void SetupScene();

    public abstract ISceneClass NextScene { get; set; }

    public TownSceneController Controller
    {
        get { return TownSceneController.instance; }
    }

    public List<TownDialogueSprite> GetTownSprites()
    {
        List<TownDialogueSprite> townSprites = new List<TownDialogueSprite>();
        foreach (var sprite in Controller.Sprites)
        {
            townSprites.Add(sprite.GetComponent<TownDialogueSprite>());
        }
        return townSprites;
    }

    public Transform CentreSprite(TownSpriteBase sprite)
    {
        Transform transform = sprite.GetComponent<Transform>();
        transform.localPosition = new Vector3(0f, 0f);
        transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        return transform;
    }

    public Transform TopLeftSprite(TownSpriteBase sprite)
    {
        Transform transform = sprite.GetComponent<Transform>();
        transform.localPosition = new Vector3(-630f, 370f);
        transform.localScale = new Vector3(0.4f, 0.4f, 1f);
        return transform;
    }

    public Transform TopRightSprite(TownSpriteBase sprite)
    {
        Transform transform = sprite.GetComponent<Transform>();
        transform.localPosition = new Vector3(590f, -350f);
        transform.localScale = new Vector3(0.4f, 0.4f, 1f);
        return transform;
    }

    public Transform BottomRightSprite(TownSpriteBase sprite)
    {
        Transform transform = sprite.GetComponent<Transform>();
        transform.localPosition = new Vector3(590f, -350f);
        transform.localScale = new Vector3(0.6f, 0.6f, 1f);
        return transform;
    }

    public Transform BottomLeftSprite(TownSpriteBase sprite)
    {
        Transform transform = sprite.GetComponent<Transform>();
        transform.localPosition = new Vector3(-630f, -350f);
        transform.localScale = new Vector3(0.6f, 0.6f, 1f);
        return transform;
    }
}
