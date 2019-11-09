using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalisedText : MonoBehaviour
{
    public string Key;
    public bool AnimatedText = false;
    public bool IsCurrentlyAnimating { get; private set; }

    private string _lastProcessedKey;
    private Text _textComponent { get { return GetComponent<Text>(); } }
    private IEnumerator _coroutine;

    private string GetFullText(string key)        
    {
        if (key == null)
        {
            Debug.Log("No key specified for text");
            return "No key specified for text";
        }
        else if (key == "")
        {
            return "";
        }
        else
        {
            return LocalisationManager.instance.GetLocalisedValue(key);
        }            
    }

    private void Start()
    {
        if (AnimatedText == false)
        {
            _textComponent.text = GetFullText(Key);
        }
    }

    private void Update()
    {
        if (_lastProcessedKey == null || _lastProcessedKey != Key)
        {
            if (AnimatedText == false)
            {
                _textComponent.text = GetFullText(Key);
                _lastProcessedKey = Key;
            }
            else
            {
                _coroutine = AnimateText(GetFullText(Key));
                StartCoroutine(_coroutine);
                _lastProcessedKey = Key;
            }
        }
    }

    public void SkipAnimation()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            IsCurrentlyAnimating = false;
            _textComponent.text = GetFullText(Key);
            _lastProcessedKey = Key;
        }
    }

    IEnumerator AnimateText(string strComplete)
    {
        IsCurrentlyAnimating = true;
        int i = 0;
        _textComponent.text = "";
        while (i < strComplete.Length)
        {
            _textComponent.text += strComplete[i++];
            yield return new WaitForSeconds(0.05F);
        }
        IsCurrentlyAnimating = false;        
    }
}
