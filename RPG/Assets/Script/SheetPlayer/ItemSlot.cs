using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ItemSlot : MonoBehaviour, IPointerClickHandler//, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Text text;
   // [SerializeField] ItemTooltip tooltip; 

    public event Action<Item> OnRightClickEvent;
    public event Action<Item> OnLeftClickEvent;

    private Item _item;
    private EquippableItem equipItem;
    public Item Item
    {
        get {return _item;}
        set
        {
          
            _item = value;
            equipItem = (EquippableItem)value;
           
          
            if (_item == null)
            {
                text.enabled = false;
            }
            else
            {
                text.text = _item.ItemName.ToUpper() + "\n" +"Str: " + equipItem.StrengthBonus + " Int: " + equipItem.IntelligenceBonus + " Vit: " + equipItem.VitalityBonus + " Agi: " + equipItem.AgilityBonus;
                text.enabled = true;
            }
         
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Left)
        {

            if (Item != null && OnLeftClickEvent != null)
            {
                OnLeftClickEvent(Item);
            }
        }

        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {

            if (Item != null && OnRightClickEvent != null)
            {
                OnRightClickEvent(Item);
            }
        }
    }


    protected virtual void OnValidate()    {
        if (text == null)
        {
            text = GetComponent<Text>();
        }
        
       /* if(tooltip == null)
        {
            tooltip = FindObjectOfType<ItemTooltip>();
        }*/
    }

   /* public void OnPointerEnter(PointerEventData eventData)
    {
        if (Item is EquippableItem)
        {
            tooltip.ShowTooltip((EquippableItem)Item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideTooltip();
    }*/

  
}
