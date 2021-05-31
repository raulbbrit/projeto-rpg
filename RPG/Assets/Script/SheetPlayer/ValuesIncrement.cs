using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValuesIncrement : MonoBehaviour
{
    public GameObject script;
    public GameObject statScript;
    public GameObject skillScript;
    public GameObject infoScript;
    [SerializeField] Inventory inventory;
    [SerializeField] EquipmentPanel equipmentPanel;
    [SerializeField] StatPanel statPanel;
    [SerializeField] SkillPanel skillPanel;
    [SerializeField] InfoPanel infoPanel;
    [SerializeField] NamePanel namePanel;
    private Character charac;


    private void Awake()
    {
        charac = Instantiate(script).GetComponent<Character>();
        charac.Inventory = inventory;
        charac.EquipmentPanel = equipmentPanel;
        charac.StatPanel = statPanel;
        charac.SkillPanel = skillPanel;
        charac.InfoPanel = infoPanel;
        charac.NamePanel = namePanel;

        charac.SetFieldsAndUI();
    }

    public void IncremetValues(int button)
    {
        //Character charac = script.GetComponent<Character>();
        

        StatDisplay[] stat = statScript.GetComponentsInChildren<StatDisplay>();
        SkillDisplay[] skill = skillScript.GetComponentsInChildren<SkillDisplay>();
        InfoDisplay[] info = infoScript.GetComponentsInChildren<InfoDisplay>();
        
        if (button != 0) {
            
            switch (button)
            {
                case 1: charac.Strenght.BaseValue += 1; break;
                case -1: if (charac.Strenght.BaseValue > 0){ charac.Strenght.BaseValue -= 1; } else { } break;

                case 2: charac.Agility.BaseValue += 1; break;
                case -2: if (charac.Agility.BaseValue > 0){ charac.Agility.BaseValue -= 1; } else { } break;

                case 3: charac.Intelligence.BaseValue += 1; break;
                case -3: if (charac.Intelligence.BaseValue > 0){ charac.Intelligence.BaseValue -= 1; } else { } break;

                case 4: charac.Vitality.BaseValue += 1; break;
                case -4: if (charac.Vitality.BaseValue > 0) { charac.Vitality.BaseValue -= 1; } else { } break;

                case 5: charac.Fight.skillValue += 1; break;
                case -5: if (charac.Fight.skillValue > 0) { charac.Fight.skillValue-= 1; } else { } break;

                case 6: charac.Shoot.skillValue += 1; break;
                case -6: if (charac.Shoot.skillValue > 0) { charac.Shoot.skillValue -= 1; } else { } break;

                case 7: charac.Brawl.skillValue += 1; break;
                case -7: if (charac.Brawl.skillValue > 0) { charac.Brawl.skillValue -= 1; } else { } break;

                case 8: charac.Dodge.skillValue += 1; break;
                case -8: if (charac.Dodge.skillValue > 0) { charac.Dodge.skillValue -= 1; } else { } break;

                case 9: charac.Block.skillValue += 1; break;
                case -9: if (charac.Block.skillValue > 0) { charac.Block.skillValue -= 1; } else { } break;

                case 10: charac.Athletics.skillValue += 1; break;
                case -10: if (charac.Athletics.skillValue > 0) { charac.Athletics.skillValue -= 1; } else { } break;

                case 11: charac.Physique.skillValue += 1; break;
                case -11: if (charac.Physique.skillValue > 0) { charac.Physique.skillValue -= 1; } else { } break;

                case 12: charac.Sneak.skillValue += 1; break;
                case -12: if (charac.Sneak.skillValue > 0) { charac.Sneak.skillValue -= 1; } else { } break;

                case 13: charac.Investigate.skillValue += 1; break;
                case -13: if (charac.Investigate.skillValue > 0) { charac.Investigate.skillValue -= 1; } else { } break;

                case 14: charac.Perception.skillValue += 1; break;
                case -14: if (charac.Perception.skillValue > 0) { charac.Perception.skillValue -= 1; } else { } break;

                case 15: charac.Language.skillValue += 1; break;
                case -15: if (charac.Language.skillValue > 0) { charac.Language.skillValue -= 1; } else { } break;

                case 16: charac.Knowledge.skillValue += 1; break;
                case -16: if (charac.Knowledge.skillValue > 0) { charac.Knowledge.skillValue -= 1; } else { } break;

                case 17: charac.Resources.skillValue += 1; break;
                case -17: if (charac.Resources.skillValue > 0) { charac.Resources.skillValue -= 1; } else { } break;

                case 18: charac.Intimidation.skillValue += 1; break;
                case -18: if (charac.Intimidation.skillValue > 0) { charac.Intimidation.skillValue -= 1; } else { } break;

                case 19: charac.Deceive.skillValue += 1; break;
                case -19: if (charac.Deceive.skillValue > 0) { charac.Deceive.skillValue -= 1; } else { } break;

                case 20: charac.Health.characterInfo += 1; break;
                case -20: if (charac.Health.characterInfo > 0) { charac.Health.characterInfo -= 1; } else { } break;

                case 21: charac.Mana.characterInfo += 1; break;
                case -21: if (charac.Mana.characterInfo > 0) { charac.Mana.characterInfo -= 1; } else { } break;

                case 22: charac.Level.characterInfo += 1; break;
                case -22: if (charac.Level.characterInfo > 0) { charac.Level.characterInfo -= 1; } else { } break;
            }


            if (button > -5 && button < 0||button > 0 && button < 5) {
                foreach (StatDisplay stats in stat)
                {
                    stats.UpdateStatValue();
                }
            }
            else if(button > -20 && button < -4 || button > 4 && button < 20)
            {
                foreach (SkillDisplay skills in skill)
                {
                    skills.UpdateStatValue();
                }
            }
            else
            {
                foreach (InfoDisplay infos in info)
                {
                    infos.UpdateStatValue();
                }
            }
        }
        

    }

}
