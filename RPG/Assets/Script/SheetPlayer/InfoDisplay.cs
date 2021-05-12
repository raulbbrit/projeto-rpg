using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoDisplay : MonoBehaviour
{
    private CharacterInfos _info;
    public CharacterInfos Info
    {
        get { return _info; }
        set
        {
            _info = value;
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
        valueText.text = Info.Value.ToString();
    }
}
