using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NpcDisplay : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Text text;

    public event Action<Npc> OnRightClickEvent;

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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if (NPC != null && OnRightClickEvent != null)
            {
                OnRightClickEvent(NPC);
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
