using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class ValuesIncrement : MonoBehaviour
{
    public GameObject characterPreFab;
    public GameObject statScript;
    public GameObject skillScript;
    public GameObject infoScript;
    [SerializeField] Inventory inventory;
    [SerializeField] EquipmentPanel equipmentPanel;
    [SerializeField] StatPanel statPanel;
    [SerializeField] SkillPanel skillPanel;
    [SerializeField] InfoPanel infoPanel;
    [SerializeField] NamePanel namePanel;
    private Character characterScript;
    private NetworkPlayer networkPlayer;
    [SerializeField] Character CharacterScript;


    private void Start()
    {
        Instantiate(characterPreFab).GetComponent<Character>();
        CharacterScript = GameObject.Find("CharacterLocal(Clone)").GetComponent<Character>();
        CharacterScript.Inventory = inventory;
        CharacterScript.EquipmentPanel = equipmentPanel;
        CharacterScript.StatPanel = statPanel;
        CharacterScript.SkillPanel = skillPanel;
        CharacterScript.InfoPanel = infoPanel;
        CharacterScript.NamePanel = namePanel;
        
        CharacterScript.SetFieldsAndUI();
        inventory.StartInventory();
        equipmentPanel.StartEquipmentPanel();

    }

    public  Character CreateCharacter(GameObject netCharacterPrefab)
    {
        CharacterScript = netCharacterPrefab.GetComponent<Character>();
        CharacterScript.Inventory = inventory;
        CharacterScript.EquipmentPanel = equipmentPanel;
        CharacterScript.StatPanel = statPanel;
        CharacterScript.SkillPanel = skillPanel;
        CharacterScript.InfoPanel = infoPanel;
        CharacterScript.NamePanel = namePanel;
        CharacterScript.SetFieldsAndUI();
        return characterScript;

    }

    public void IncremetValues(int button)
    {
        //Character charac = script.GetComponent<Character>();

        //NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        //networkPlayer = networkIdentity.GetComponent<NetworkPlayer>();

        StatDisplay[] stat = statScript.GetComponentsInChildren<StatDisplay>();
        SkillDisplay[] skill = skillScript.GetComponentsInChildren<SkillDisplay>();
        InfoDisplay[] info = infoScript.GetComponentsInChildren<InfoDisplay>();
        
        if (button != 0) {
            
            switch (button)
            {
                  case 1: CharacterScript.Strenght.BaseValue += 1; break;
               // case 1: networkPlayer.Character.GetComponent<Character>().Strenght.BaseValue += 1; break;
                case -1: if (CharacterScript.Strenght.BaseValue > 0){ CharacterScript.Strenght.BaseValue -= 1; } else { } break;

                case 2: CharacterScript.Agility.BaseValue += 1; break;
                case -2: if (CharacterScript.Agility.BaseValue > 0){ CharacterScript.Agility.BaseValue -= 1; } else { } break;

                case 3: CharacterScript.Intelligence.BaseValue += 1; break;
                case -3: if (CharacterScript.Intelligence.BaseValue > 0){ CharacterScript.Intelligence.BaseValue -= 1; } else { } break;

                case 4: CharacterScript.Vitality.BaseValue += 1; break;
                case -4: if (CharacterScript.Vitality.BaseValue > 0) { CharacterScript.Vitality.BaseValue -= 1; } else { } break;

                case 5: CharacterScript.Fight.skillValue += 1; break;
                case -5: if (CharacterScript.Fight.skillValue > 0) { CharacterScript.Fight.skillValue-= 1; } else { } break;

                case 6: CharacterScript.Shoot.skillValue += 1; break;
                case -6: if (CharacterScript.Shoot.skillValue > 0) { CharacterScript.Shoot.skillValue -= 1; } else { } break;

                case 7: CharacterScript.Brawl.skillValue += 1; break;
                case -7: if (CharacterScript.Brawl.skillValue > 0) { CharacterScript.Brawl.skillValue -= 1; } else { } break;

                case 8: CharacterScript.Dodge.skillValue += 1; break;
                case -8: if (CharacterScript.Dodge.skillValue > 0) { CharacterScript.Dodge.skillValue -= 1; } else { } break;

                case 9: CharacterScript.Block.skillValue += 1; break;
                case -9: if (CharacterScript.Block.skillValue > 0) { CharacterScript.Block.skillValue -= 1; } else { } break;

                case 10: CharacterScript.Athletics.skillValue += 1; break;
                case -10: if (CharacterScript.Athletics.skillValue > 0) { CharacterScript.Athletics.skillValue -= 1; } else { } break;

                case 11: CharacterScript.Physique.skillValue += 1; break;
                case -11: if (CharacterScript.Physique.skillValue > 0) { CharacterScript.Physique.skillValue -= 1; } else { } break;

                case 12: CharacterScript.Sneak.skillValue += 1; break;
                case -12: if (CharacterScript.Sneak.skillValue > 0) { CharacterScript.Sneak.skillValue -= 1; } else { } break;

                case 13: CharacterScript.Investigate.skillValue += 1; break;
                case -13: if (CharacterScript.Investigate.skillValue > 0) { CharacterScript.Investigate.skillValue -= 1; } else { } break;

                case 14: CharacterScript.Perception.skillValue += 1; break;
                case -14: if (CharacterScript.Perception.skillValue > 0) { CharacterScript.Perception.skillValue -= 1; } else { } break;

                case 15: CharacterScript.Language.skillValue += 1; break;
                case -15: if (CharacterScript.Language.skillValue > 0) { CharacterScript.Language.skillValue -= 1; } else { } break;

                case 16: CharacterScript.Knowledge.skillValue += 1; break;
                case -16: if (CharacterScript.Knowledge.skillValue > 0) { CharacterScript.Knowledge.skillValue -= 1; } else { } break;

                case 17: CharacterScript.Resources.skillValue += 1; break;
                case -17: if (CharacterScript.Resources.skillValue > 0) { CharacterScript.Resources.skillValue -= 1; } else { } break;

                case 18: CharacterScript.Intimidation.skillValue += 1; break;
                case -18: if (CharacterScript.Intimidation.skillValue > 0) { CharacterScript.Intimidation.skillValue -= 1; } else { } break;

                case 19: CharacterScript.Deceive.skillValue += 1; break;
                case -19: if (CharacterScript.Deceive.skillValue > 0) { CharacterScript.Deceive.skillValue -= 1; } else { } break;

                case 20: CharacterScript.Health.characterInfo += 1; break;
                case -20: if (CharacterScript.Health.characterInfo > 0) { CharacterScript.Health.characterInfo -= 1; } else { } break;

                case 21: CharacterScript.Mana.characterInfo += 1; break;
                case -21: if (CharacterScript.Mana.characterInfo > 0) { CharacterScript.Mana.characterInfo -= 1; } else { } break;

                case 22: CharacterScript.Level.characterInfo += 1; break;
                case -22: if (CharacterScript.Level.characterInfo > 0) { CharacterScript.Level.characterInfo -= 1; } else { } break;
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
