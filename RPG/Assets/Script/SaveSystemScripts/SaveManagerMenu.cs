using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManagerMenu : MonoBehaviour
{
    [SerializeField] GameObject text;
    public void DeleteCharMenu()
    {
        text.SetActive(false);
        SaveSystem.DeleteCharacter();
        foreach (EquipmentData equip in SaveData.equipments.ToArray())
        {
            SaveData.equipments.Remove(equip);
        }
        SerializationManager.DeleteOldSave(1);
        StartCoroutine(DeletedTextAppear());
    }

    public void DeleteMasterMenu()
    {
        text.SetActive(false);
        foreach (NpcData npc in SaveData.Npc.ToArray())
        {
            SaveData.Npc.Remove(npc);
        }
        foreach (MonsterData monster in SaveData.Monster.ToArray())
        {
            SaveData.Monster.Remove(monster);
        }
        SerializationManager.DeleteOldSave(2);
        
            StartCoroutine(DeletedTextAppear());
    }

    IEnumerator DeletedTextAppear()
    {
        text.SetActive(true);
        yield return new WaitForSeconds(5);
        text.SetActive(false);
    }
}
