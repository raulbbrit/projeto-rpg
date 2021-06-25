using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MonsterList : MonoBehaviour
{
    [SerializeField] List<Npc> npcs;
    [SerializeField] Transform npcsParent;
    [SerializeField] GameObject monsterPrefab;
    [SerializeField] MonsterDisplay[] npcsSlots;

    private void Start()
    {
        for (int i = 0; i < npcsSlots.Length; i++)
        {
            npcsSlots[i].OnRightClickEvent += OnItemRightClickedEvent;
        }
        OnLoadMonster();
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

    private void OnItemRightClickedEvent(Npc npc)
    {
        if (npc is MonsterNpc)
        {
            DeleteFromList((MonsterNpc)npc);
        }
    }

    private void DeleteFromList(MonsterNpc npc)
    {
        if (RemoveNpcs(npc))
        {
            foreach (MonsterData data in SaveData.Monster.ToArray())
            {
                if (data.id == npc.id)
                {
                    Debug.Log("Entrou no if DeleteNPC");
                    SaveData.Monster.Remove(data);
                }
            }
            Destroy(npc.gameObject);
        }
    }

    public void OnLoadMonster()
    {
        string path = Application.persistentDataPath + "/saves/monster.sheet";
        if (File.Exists(path)) {
            SaveData.Monster.Clear();
            SaveData.Monster = (List<MonsterData>)SerializationManager.Load(Application.persistentDataPath + "/saves/monster.sheet");

            for (int i = 0; i < SaveData.Monster.Count; i++)
            {
                MonsterData currentNpc = SaveData.Monster[i];
                GameObject obj = Instantiate(monsterPrefab);
                MonsterNpc npc = obj.GetComponent<MonsterNpc>();
                npc.id = currentNpc.id;
                npc.npcName = currentNpc.name;
                npc.health = currentNpc.health;
                npc.mana = currentNpc.mana;
                npc.strength = currentNpc.strength;
                npc.intelligence = currentNpc.intelligence;
                npc.agility = currentNpc.agility;
                npc.vitality = currentNpc.vitality;
                npcs.Add(npc);
            }
        }
    }

}
