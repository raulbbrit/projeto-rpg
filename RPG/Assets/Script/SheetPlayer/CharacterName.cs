using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterName
{
    public string characterName;

    public virtual string Value
    {
        get
        {
            _value = characterName;
            return _value;
        }
    }

    protected string _value;

    public CharacterName(string characterName)
    {
        this.characterName = characterName;
    }
}
