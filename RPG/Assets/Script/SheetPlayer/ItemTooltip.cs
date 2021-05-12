using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class ItemTooltip : MonoBehaviour
{
    [SerializeField] Text ItemNameText;
    [SerializeField] Text ItemSlotText;
    [SerializeField] Text ItemStatsText;

    private StringBuilder sb = new StringBuilder();



    public void ShowTooltip(EquippableItem item)
    {
        ItemNameText.text = item.ItemName;
        ItemSlotText.text = item.EquipamentType.ToString();

        sb.Length = 0;
        AddStat(item.StrengthBonus, "Strength");
        AddStat(item.AgilityBonus, "Agility");
        AddStat(item.IntelligenceBonus, "Intelligence");
        AddStat(item.VitalityBonus, "Vitality");

        ItemStatsText.text = sb.ToString();

        gameObject.SetActive(true);
    }
    public void HideTooltip()
    {
        gameObject.SetActive(false);

    }

    private void AddStat(float value, string statName)
    {

        if(value != 0)
        {
            if(sb.Length > 0)
            {
                sb.AppendLine();
            }
            if(value > 0 )
            {
                sb.Append("+");
            }

            sb.Append(value);
            sb.Append(" ");

            sb.Append(statName);
        }
    }
}
