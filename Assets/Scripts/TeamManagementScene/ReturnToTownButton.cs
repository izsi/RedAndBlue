using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToTownButton : MonoBehaviour
{
    public void ReturnToTown()
    {
        DataManager.instance.LoadNextScene(DataManager.instance.TownSceneState.Scene);
    }

}
