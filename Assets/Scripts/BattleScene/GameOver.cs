using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void ReturnToTitleWithSkipText()
    {
        LocalisedText childText = gameObject.transform.Find("Text").gameObject.GetComponent<LocalisedText>();
        if (childText.IsCurrentlyAnimating == true)
        {
            childText.SkipAnimation();
        }
        else
        {
            SceneManager.LoadScene("InitialLoad");
        }        
    }
}
