using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcDisplay : MonoBehaviour
{
    [SerializeField] Text text;

    private Npc _npc;
    private SimpleNpc _simpleNpc;
    public Npc NPC
    {
        get { return _npc; }
        set
        {
            _npc = value;
            _simpleNpc = (SimpleNpc)value;

            if (_npc == null)
            {
                text.enabled = false;
            }
            else
            {
                text.text = " Name: " + _npc.npcName + "\n" + " Health: " + _simpleNpc.health + " Mana: " + _simpleNpc.mana;
                text.enabled = true;
            }
        }


    }

    protected virtual void OnValidate()
    {
        if (text == null)
        {
            text = GetComponent<Text>();
        }
    }
}
