using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameDisplay : MonoBehaviour
{
    private CharacterName _charName;
    public CharacterName CharName
    {
        get { return _charName; }
        set
        {
            _charName = value;
            UpdateStatValue();
        }
    }

    private string _name;
    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
            nameText.text = _name;
        }
    }

    [SerializeField] Text nameText;
    [SerializeField] Text valueText;

    private void OnValidate()
    {
        Text[] texts = GetComponentsInChildren<Text>();
        nameText = texts[0];
        valueText = texts[1];
    }

    public void UpdateStatValue()
    {
        valueText.text = CharName.Value.ToString();
    }
}
