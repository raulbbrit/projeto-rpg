using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ItemSlot : MonoBehaviour, IPointerClickHandler//, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Text Text;
   // [SerializeField] ItemTooltip tooltip; 

    public event Action<Item> OnRightClickEvent;

    private Item _item;
    public Item Item
    {
        get {return _item;}
        set
        {
          
            _item = value;
            
           
          
            if (_item == null)
            {
                Text.enabled = false;
            }
            else
            {
                Text.text = _item.ItemName;
                Text.enabled = true;
            }
         
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Left)
        {

            if (Item != null && OnRightClickEvent != null)
            {
                OnRightClickEvent(Item);
            }
        }
    }


    protected virtual void OnValidate()    {
        if (Text == null)
        {
            Text = GetComponent<Text>();
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
