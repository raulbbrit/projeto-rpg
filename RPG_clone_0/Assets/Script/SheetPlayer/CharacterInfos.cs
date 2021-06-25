using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
[Serializable]
public class CharacterInfos
{
    public int characterInfo;

    public virtual int Value
    {
        get
        {
            _value = characterInfo;
            return _value;
        }
    }

    protected int _value;

    public CharacterInfos(int characterInfo)
    {
        this.characterInfo = characterInfo;
    }

}
