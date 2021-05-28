using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public EquipmentData data;
    [SerializeField] Text errortext;
    [SerializeField] private Inventory inventory;
    [SerializeField] private InputField nameInput;
    [SerializeField] private InputField strengthInput;
    [SerializeField] private InputField agilityInput;
    [SerializeField] private InputField intelligenceInput;
    [SerializeField] private InputField vitalityInput;
    [SerializeField] private Dropdown equipmentType;
    private Character character;

    public void AddItem()
    {
        if (!strengthInput.text.Trim(' ').Equals("") && !agilityInput.text.Trim(' ').Equals("") && !intelligenceInput.text.Trim(' ').Equals("") && !vitalityInput.text.Trim(' ').Equals("")) {
            GameObject _object = (GameObject)Instantiate(GameManager.Instance.SelectedObject.ObjectPrefab);
            EquippableItem item = _object.GetComponent<EquippableItem>();
            if (!nameInput.text.Trim(' ').Equals("")) {
                item.ItemName = nameInput.text;
            }
            else { item.ItemName = "NoNameItem"; }
            try
            {

                item.StrengthBonus = int.Parse(strengthInput.text);
                item.AgilityBonus = int.Parse(agilityInput.text);
                item.IntelligenceBonus = int.Parse(intelligenceInput.text);
                item.VitalityBonus = int.Parse(vitalityInput.text);
                item.EquipamentType = (EquipmentType)equipmentType.value;
                inventory.AddItem(item);

                data.id = equipmentType.ToString() + nameInput.text;
                data.itemName = nameInput.text;
                data.strength = int.Parse(strengthInput.text);
                data.intelligence = int.Parse(intelligenceInput.text);
                data.agility = int.Parse(agilityInput.text);
                data.vitality = int.Parse(vitalityInput.text);
                data.equipType = (EquipmentType)equipmentType.value;
                SaveData.equipments.Add(data);//lista principal

                errortext.enabled = false;
                nameInput.text = "";
                strengthInput.text = "";
                intelligenceInput.text = "";
                vitalityInput.text = "";
                agilityInput.text = "";
            }
            catch
            {
                errortext.enabled = true;
            }
        }
        else
        {
            errortext.enabled = true;
        }
        }
    }


