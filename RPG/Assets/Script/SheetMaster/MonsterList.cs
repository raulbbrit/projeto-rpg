using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterList : MonoBehaviour
{
    [SerializeField] List<Npc> npcs;
    [SerializeField] Transform npcsParent;
    [SerializeField] MonsterDisplay[] npcsSlots;

    private void Start()
    {
        /*for (int i = 0; i < npcsSlots.Length; i++)
        {
            npcsSlots[i].OnRightClickEvent += OnItemRightClickedEvent;
        }*/
        RefreshUI();
    }

    private void RefreshUI()
    {
        int i = 0;
        for (; i < npcs.Count && i < npcsSlots.Length; i++)
        {
            npcsSlots[i].NPC = npcs[i];
        }
        for (; i < npcsSlots.Length; i++)
        {
            //Debug.Log("Item " + itemSlots[i].Item.ItemName + " no slot " + i + " agora é null");
            npcsSlots[i].NPC = null;

        }
    }

    private void OnValidate()
    {
        if (npcsParent != null)
        {
            npcsSlots = npcsParent.GetComponentsInChildren<MonsterDisplay>();
        }
        RefreshUI();
    }



    public bool AddMonster(Npc npc)
    {
        if (IsFull())
            return false;

        npcs.Add(npc);
        RefreshUI();
        return true;
    }

    public bool RemoveNpcs(Npc npc)
    {
        if (npcs.Remove(npc))
        {
            RefreshUI();
            return true;
        }
        return false;
    }

    public bool IsFull()
    {
        return npcs.Count >= npcsSlots.Length;
    }

}
