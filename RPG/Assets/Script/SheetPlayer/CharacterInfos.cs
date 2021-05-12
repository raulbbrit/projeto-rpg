using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterInfos
{
    public string characterInfo;

    public virtual string Value
    {
        get
        {
            _value = characterInfo;
            return _value;
        }
    }

    protected string _value;

    public CharacterInfos(string characterInfo)
    {
        this.characterInfo = characterInfo;
    }

}
