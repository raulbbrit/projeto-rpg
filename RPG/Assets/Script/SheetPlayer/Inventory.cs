using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items;
    [SerializeField] GameObject prefab;
    [SerializeField] Transform itemsParent;
    [SerializeField] ItemSlot[] itemSlots;

    public event Action<Item> OnItemLeftClickedEvent;
    public event Action<Item> OnItemRightClickedEvent;

    private void Start()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].OnRightClickEvent += OnItemRightClickedEvent;
            itemSlots[i].OnLeftClickEvent += OnItemLeftClickedEvent;

        }
        OnLoadInventory();
        RefreshUI();
    }

    private void RefreshUI()
    {
        Debug.Log(items);
        int i = 0;
        for (; i < items.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = items[i];
        }
        for (; i < itemSlots.Length; i++)
        {
            //Debug.Log("Item " + itemSlots[i].Item.ItemName + " no slot " + i + " agora é null");
            itemSlots[i].Item = null;
          
        }
    }

    private void OnValidate()
    {
        if(itemsParent != null)
        {
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
        }
        RefreshUI();
    }

 

    public bool AddItem(Item item)
    {
        if (IsFull())
            return false;

        items.Add(item);
        RefreshUI();
        return true;
    }

    public bool RemoveItems(Item item)
    {
        if (items.Remove(item))
        {
            RefreshUI();
            return true;
        }
        return false;
    }

    public bool IsFull()
    {
        return items.Count >= itemSlots.Length;
    }

    /*public void LoadInventory()
    {
        EquipmentData data = SaveSystem.LoadInventory();

       
    }*/

    public void OnLoadInventory()
    {
        string path = Application.persistentDataPath + "/saves/inventory.sheet";
        if (File.Exists(path))
        {
            SaveData.equipments = (List<EquipmentData>)SerializationManager.Load(Application.persistentDataPath + "/saves/inventory.sheet");
            //Debug.Log("Qunatidadede items no save: " + SaveData.equipments.Count);

            for (int i = 0; i < SaveData.equipments.Count; i++)
            {

                EquipmentData currentEquip = SaveData.equipments[i];
                Debug.Log("Nome item no save: " + currentEquip.itemName);
                //Debug.Log($"Equipment atual {i}");
                //EquipmentData currentEquip = SaveData.equipments[i];
                //Debug.Log("Index: " + i + " Array Save: "+SaveData.equipments.Count+" Array items: "+items.Count);
                GameObject obj = Instantiate(prefab);
                //Debug.Log("Passou do gameobject");
                EquippableItem equipItem = obj.GetComponent<EquippableItem>();
                equipItem.id = currentEquip.id;
                equipItem.ItemName = currentEquip.itemName;
                equipItem.StrengthBonus = currentEquip.strength;
                equipItem.IntelligenceBonus = currentEquip.intelligence;
                equipItem.VitalityBonus = currentEquip.vitality;
                equipItem.AgilityBonus = currentEquip.agility;
                equipItem.EquipamentType = currentEquip.equipType;
                items.Add(equipItem);

            }
        }

    }
}
