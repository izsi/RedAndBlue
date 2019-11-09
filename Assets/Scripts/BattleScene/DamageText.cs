using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SelfDestructAfterWait(2));
    }

    private void Update()
    {
        // Quick fix for it appearing on top of the Game Over overlay
        if (GameObject.Find("GameOverOverlay") != null)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator SelfDestructAfterWait(int waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        Destroy(gameObject);
    }
}
