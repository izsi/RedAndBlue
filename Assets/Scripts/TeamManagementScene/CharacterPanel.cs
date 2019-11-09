using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanel : MonoBehaviour
{
    public GameObject Portrait;

    private CharacterId _currentCharacter;

    public void SetCharacterToDisplay(CharacterId character)
    {
        _currentCharacter = character;
        Debug.Log($"Displaying character info for {_currentCharacter.ToString()}");
        
        DisplayPortrait();


    }

    private void DisplayPortrait()
    {
        string imageName = $"FullPortrait{_currentCharacter.ToString()}";
        Portrait.GetComponent<Image>().sprite = Resources.Load<Sprite>($"TeamManageScene/{imageName}");
    }

    void Start()
    {
        SetCharacterToDisplay(CharacterId.MainCharacter);
    }
}
