using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class DisplayAmityUp : MonoBehaviour
{
    private Image CurrentImage
    {
        get { return GetComponent<Image>(); }
    }

    void Start()
    {
        if (CurrentImage.sprite != null)
        {
            Debug.Log("Rogue AmityUp sprite found, removing");
            CurrentImage.sprite = null;
        }            
    }

    void Update()
    {
        if (CurrentImage.sprite != null)
        {
            // Have set the image to start out transparent
            var tempColour = CurrentImage.color;
            tempColour.a = 1f;
            CurrentImage.color = tempColour;
            StartCoroutine(FadeOutAndRemoveSprite());
        }
    }

    private IEnumerator FadeOutAndRemoveSprite()
    {
        yield return new WaitForSeconds(2);
        CurrentImage.CrossFadeAlpha(0, 1.0f, false);
        yield return new WaitForSeconds(4);
        CurrentImage.sprite = null;
    }
}
