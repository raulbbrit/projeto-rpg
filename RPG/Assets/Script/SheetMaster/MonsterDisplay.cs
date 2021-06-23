using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MonsterDisplay : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Text text;

    public event Action<Npc> OnRightClickEvent;

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
                text.text = "Name: " + _npc.npcName + "\t" + "\t" + " Health: " + monsterNpc.health + "\t" + "\t" + " Mana: " + monsterNpc.mana 
                    + "\n" + "Str: " + monsterNpc.strength + "\t" + "\t" + "\t" + " Int: " + monsterNpc.intelligence + "\t" + "\t" + "\t" + " Vit: " + monsterNpc.vitality + "\t" + "\t" + "\t" + " Agi: " + monsterNpc.agility;
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("OnRightClickEvent " + OnRightClickEvent);
            if (NPC != null && OnRightClickEvent != null)
            {
                OnRightClickEvent(NPC);
            }
        }
    }
}
