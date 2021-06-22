using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

[Serializable]
public class CharacterSkill
{
    public int skillValue;

    public virtual int Value
    {
        get
        {
            _value = skillValue;
            return _value;
        }
    }

    protected int _value;

    public CharacterSkill(int skillValue)
    {
        this.skillValue = skillValue;
    }



}
