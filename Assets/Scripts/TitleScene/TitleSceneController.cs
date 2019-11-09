using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneController : MonoBehaviour
{
    public GameObject ModalBlocker;

    public static TitleSceneController instance;

    private void Awake()
    {
        Debug.Log("Loading TitleScene Controller");
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
