using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupManager : MonoBehaviour
{
    private IEnumerator Start()
    {
        while (LocalisationManager.instance == null)
        {
            Debug.Log("LocalisationManager doesn't exist");
            yield return null;
        }

        while (!LocalisationManager.instance.GetIsReady())
        {
            Debug.Log("Waiting for LocalisationManager");
            yield return null;
        }

        SceneManager.LoadScene("Title");
    }
}

