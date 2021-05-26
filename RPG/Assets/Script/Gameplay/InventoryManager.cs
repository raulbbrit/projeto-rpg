using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
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


