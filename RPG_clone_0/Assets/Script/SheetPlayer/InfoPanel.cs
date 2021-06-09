using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] InfoDisplay[] infoDisplays;

    private CharacterInfos[] info;
    [SerializeField] string[] infoName;

    private void OnValidate()
    {
        infoDisplays = GetComponentsInChildren<InfoDisplay>();
        UpadeStatNames();
    }

    public void SetInfos(params CharacterInfos[] charStats)
    {
        info = charStats;

        if (info.Length > infoDisplays.Length)
        {
            Debug.LogError("Not Enough Stat Displays!");
            return;
        }

        for (int i = 0; i < infoDisplays.Length; i++)
        {
            infoDisplays[i].gameObject.SetActive(i < info.Length);

            if (i < info.Length)
            {
                infoDisplays[i].Info = info[i];
            }
        }
    }

    public void UpadeStatValues()
    {
        for (int i = 0; i < info.Length; i++)
        {
            infoDisplays[i].UpdateStatValue();
        }
    }

    public void UpadeStatNames()
    {
        for (int i = 0; i < infoName.Length; i++)
        {
            infoDisplays[i].Name = infoName[i];
        }
    }

}
