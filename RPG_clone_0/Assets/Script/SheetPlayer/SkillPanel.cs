using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPanel : MonoBehaviour
{
    [SerializeField] SkillDisplay[] skillDisplays;
    
    private CharacterSkill[] skill;
    [SerializeField] string[] skillName;

    private void OnValidate()
    {
        skillDisplays = GetComponentsInChildren<SkillDisplay>();
        UpadeSkillNames();
    }

    public void SetSkills(params CharacterSkill[] charStats)
    {
        skill = charStats;

        if (skill.Length > skillDisplays.Length)
        {
            Debug.LogError("Not Enough Stat Displays!");
            return;
        }

        for (int i = 0; i < skillDisplays.Length; i++)
        {
            skillDisplays[i].gameObject.SetActive(i < skill.Length);

            if (i < skill.Length)
            {
                skillDisplays[i].Skill = skill[i];
            }
        }
    }

    public void UpadeSkillValues()
    {
        for (int i = 0; i < skill.Length; i++)
        {
            skillDisplays[i].UpdateStatValue();
        }
    }

    public void UpadeSkillNames()
    {
        for (int i = 0; i < skillName.Length; i++)
        {
            skillDisplays[i].Name = skillName[i];
        }
    }
}
