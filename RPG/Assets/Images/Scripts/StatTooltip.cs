using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class StatTooltip : MonoBehaviour
{
    [SerializeField] Text StatNameText;
    [SerializeField] Text StatModifiersLabelText;
    [SerializeField] Text StatModifiersText;

    private StringBuilder sb = new StringBuilder();

    public void ShowTooltip(CharacterStat stat, string statName)
    {

        StatNameText.text = GetStatTopText(stat, statName);
        StatModifiersText.text = GetStatModifiersText(stat);

        gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    private string GetStatTopText(CharacterStat stat, string statName)
    {
        sb.Length = 0;

        return statName.ToUpper();
    }
    private string GetStatModifiersText(CharacterStat stat)
    {
        
        foreach  (StatModifier mod in stat.StatModifiers)
        {
           
            if(sb.Length > 0)
            {
                sb.AppendLine();
            }

            if(mod.Value > 0)
            {
                sb.Append("+");
            }

            sb.Append(mod.Value);

            EquippableItem item = mod.Source as EquippableItem;

            if(item != null)
            {
                sb.Append(" ");
                sb.Append(item.ItemName);
            } else
            {
                Debug.Log("Modifier is not an EquippableItem!");
            }
           
        }
        return sb.ToString();
        
    }
}
