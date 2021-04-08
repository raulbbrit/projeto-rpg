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
        StatNameText.text = GetStartTopText(stat, statName);
        gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    private string GetStartTopText(CharacterStat stat, string statName)
    {
        sb.Length = 0;
        sb.Append(statName);

        return sb.ToString();
    }
    private string GetStatModifiersText(CharacterStat stat, string statName)
    {
        
        foreach  (StatModifier mod in stat.StatModifiers)
        {

        }

        return sb.ToString();
    }
}
