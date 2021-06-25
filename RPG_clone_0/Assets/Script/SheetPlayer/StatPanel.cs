using UnityEngine;

public class StatPanel : MonoBehaviour
{
    public StatDisplay[] statDisplays;

    private CharacterStat[] stats;
    [SerializeField] string[] statName;

    private void OnValidate()
    {
        statDisplays = GetComponentsInChildren<StatDisplay>();
        UpdateStatNames();
    }

    public void SetStats(params CharacterStat[] charStats)
    {
        stats = charStats;

        if (stats.Length > statDisplays.Length)
        {
            Debug.LogError("Not Enough Stat Displays!");
            return;
        }

        for (int i = 0; i < statDisplays.Length; i++)
        {
            statDisplays[i].gameObject.SetActive(i < stats.Length);

            if( i < stats.Length)
            {
                statDisplays[i].Stat = stats[i];
            }
        }
    }

    public void UpdateStatValues()
    {
        for (int i = 0; i < stats.Length; i++)
        {
            Debug.Log("UPDATE NO STATPANEL");
            statDisplays[i].UpdateStatValue();
        }
    }

    public void UpdateStatNames()
    {
        for (int i = 0; i < statName.Length; i++)
        {
            statDisplays[i].Name = statName[i];
        }
    }
}
