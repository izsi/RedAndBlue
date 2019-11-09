using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharacterSelector : MonoBehaviour
{
    public CharacterId CurrentCharacterId { get; private set; }

    private GameObject TextObject
    {
        get { return transform.Find("Text").gameObject; }
    }

    private GameObject PartyIndicator
    {
        get { return transform.Find("PartyIndicator").gameObject; }
    }

    public void SetCharacter(CharacterId characterId)
    {
        Debug.Log($"Setting character ID: {characterId}");
        CurrentCharacterId = characterId;
        string nameKey = DataManager.instance.CurrentState.Characters[characterId].NameKey;
        TextObject.GetComponent<LocalisedText>().Key = nameKey;

        if (DataManager.instance.CurrentState.PartyMembers.Contains(characterId))
        {
            PartyIndicator.SetActive(true);
        }
        else
        {
            PartyIndicator.SetActive(false);
        }

    }

    public void ApplyCharacterToPanel()
    {
        TeamManageSceneController.instance.SetCharacterInPanel(CurrentCharacterId);
    }
}
