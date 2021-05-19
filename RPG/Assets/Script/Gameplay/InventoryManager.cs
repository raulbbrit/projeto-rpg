using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private InputField nameInput;
    [SerializeField] private InputField strengthInput;
    [SerializeField] private InputField agilityInput;
    [SerializeField] private InputField intelligenceInput;
    [SerializeField] private InputField vitalityInput;
    [SerializeField] private Dropdown equipmentType;


    public void AddItem()
    {
        GameObject _object = (GameObject)Instantiate(GameManager.Instance.SelectedObject.ObjectPrefab);
        EquippableItem item = _object.GetComponent<EquippableItem>();
        item.ItemName = nameInput.text;
        item.StrengthBonus = int.Parse(strengthInput.text);
        item.AgilityBonus = int.Parse(agilityInput.text);
        item.IntelligenceBonus = int.Parse(intelligenceInput.text);
        item.VitalityBonus = int.Parse(vitalityInput.text);
       item.EquipamentType = (EquipmentType) equipmentType.value;
        inventory.AddItem(item);
    }

   /* public void RemoveItem()
    {
        inventory.RemoveItems();
    }*/
}

}
