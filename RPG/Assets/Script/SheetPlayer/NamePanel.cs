using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamePanel : MonoBehaviour
{
    [SerializeField] NameDisplay[] nameDisplays;

    private CharacterName[] info;
    [SerializeField] string[] infoName;

    private void OnValidate()
    {
        nameDisplays = GetComponentsInChildren<NameDisplay>();
        UpadeStatNames();
    }

    public void SetName(params CharacterName[] charName)
    {
        info = charName;

        if (info.Length > nameDisplays.Length)
        {
            Debug.LogError("Not Enough Stat Displays!");
            return;
        }

        for (int i = 0; i < nameDisplays.Length; i++)
        {
            nameDisplays[i].gameObject.SetActive(i < info.Length);

            if (i < info.Length)
            {
                nameDisplays[i].CharName = info[i];
            }
        }
    }

    public void UpadeStatValues()
    {
        for (int i = 0; i < info.Length; i++)
        {
            nameDisplays[i].UpdateStatValue();
        }
    }

    public void UpadeStatNames()
    {
        for (int i = 0; i < infoName.Length; i++)
        {
            nameDisplays[i].Name = infoName[i];
        }
    }
}
