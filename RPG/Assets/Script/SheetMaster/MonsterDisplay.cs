using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterDisplay : MonoBehaviour
{
    [SerializeField] Text text;

    private Npc _npc;
    private MonsterNpc monsterNpc;
    public Npc NPC
    {
        get { return _npc; }
        set
        {
            _npc = value;
            monsterNpc = (MonsterNpc)value;

            if (_npc == null)
            {
                text.enabled = false;
            }
            else
            {
                text.text = "Name: " + _npc.npcName + "\t" + " Health: " + monsterNpc.health + "\t" + " Mana: " + monsterNpc.mana 
                    + "\n" + "Str: " + monsterNpc.strength + "\t" + " Int: " + monsterNpc.intelligence + "\t" + " Vit: " + monsterNpc.vitality + "\t" + " Agi: " + monsterNpc.agility;
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
