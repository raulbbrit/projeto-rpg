using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NpcList : MonoBehaviour
{
    [SerializeField] List<Npc> npcs;
    [SerializeField] Transform npcsParent;
    [SerializeField] GameObject npcPrefab;
    [SerializeField] NpcDisplay[] npcsSlots;


    private void Start()
    {
        for (int i = 0; i < npcsSlots.Length; i++)
        {
            npcsSlots[i].OnRightClickEvent += OnItemRightClickedEvent;
        }
        OnLoadNpc();
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
            npcsSlots = npcsParent.GetComponentsInChildren<NpcDisplay>();
        }
        RefreshUI();
    }



    public bool AddNpc(Npc npc)
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

    private void OnItemRightClickedEvent(Npc npc)
    {
        if (npc is SimpleNpc)
        {
            DeleteFromList((SimpleNpc)npc);
        }
    }

    private void DeleteFromList(SimpleNpc npc)
    {
        if (RemoveNpcs(npc))
        {
            foreach (NpcData data in SaveData.Npc.ToArray())
            {
                if (data.id == npc.id)
                {
                    Debug.Log("Entrou no if DeleteNPC");
                    SaveData.Npc.Remove(data);
                }
            }
            Destroy(npc.gameObject);
        }
    }

    public void OnLoadNpc()
    {
        string path = Application.persistentDataPath + "/saves/npc.sheet";
        if (File.Exists(path)) {
            SaveData.Npc.Clear();
            SaveData.Npc = (List<NpcData>)SerializationManager.Load(Application.persistentDataPath + "/saves/npc.sheet");

            for (int i = 0; i < SaveData.Npc.Count; i++)
            {
                NpcData currentNpc = SaveData.Npc[i];
                GameObject obj = Instantiate(npcPrefab);
                SimpleNpc npc = obj.GetComponent<SimpleNpc>();
                npc.id = currentNpc.id;
                npc.npcName = currentNpc.name;
                npc.health = currentNpc.health;
                npc.mana = currentNpc.mana;
                npcs.Add(npc);
            }
        }
    }

}
