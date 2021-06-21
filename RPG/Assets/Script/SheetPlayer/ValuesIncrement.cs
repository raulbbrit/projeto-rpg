using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using System;

public class ValuesIncrement:NetworkBehaviour
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
    [SerializeField] Character characterScript;
    private NetworkPlayer networkPlayer;
    public Character CharacterScript { get => characterScript; set => characterScript = value; }

    private void Awake()
    {

    }
    public Character CreateCharacter(GameObject netCharacterPrefab)
    {

        Debug.Log("ENTROU NO CREATE CHARACTER");
        CharacterScript = netCharacterPrefab.GetComponent<Character>();
        //Server
        CharacterScript.Inventory = inventory;
        CharacterScript.EquipmentPanel = equipmentPanel;
        CharacterScript.StatPanel = statPanel;
        CharacterScript.SkillPanel = skillPanel;
        CharacterScript.InfoPanel = infoPanel;
        CharacterScript.NamePanel = namePanel;
        //SYNCVARS 
        CharacterScript.InventorySyncString = inventory.gameObject.name;
        CharacterScript.EquipmentPanelSyncString = equipmentPanel.gameObject.name;
        CharacterScript.StatPanelSyncString = statPanel.gameObject.name;
        CharacterScript.SkillPanelSyncString = skillPanel.gameObject.name;
        CharacterScript.InfoPanelSyncString = infoPanel.gameObject.name;
        CharacterScript.NamePanelSyncString = namePanel.gameObject.name;

        Debug.Log("FieldsCheck" + CharacterScript.FieldsCheck);
        CharacterScript.SetFieldsAndUI();
        return characterScript;
    }

 /**   public void IncremmentCalled(int buttonID)
    {
        NetworkIdentity playerObject = NetworkClient.connection.identity;
        networkPlayer = playerObject.GetComponent<NetworkPlayer>();
        IncremetValues(buttonID,networkPlayer);


    }*/
    

    

    

    [Command]
    public void CmdIncrementValues(int button, NetworkIdentity playerIdentity)
    {
             
       Character playerCharacter = playerIdentity.gameObject.GetComponent<NetworkPlayer>().CharacterIdentity.gameObject.GetComponent<Character>();


        StatDisplay[] stat = statScript.GetComponentsInChildren<StatDisplay>();
        SkillDisplay[] skill = skillScript.GetComponentsInChildren<SkillDisplay>();
        InfoDisplay[] info = infoScript.GetComponentsInChildren<InfoDisplay>();
        if (button != 0)
        {

            switch (button)
            {
                case 1: playerCharacter.Strenght.BaseValue += 1; break;
                // case 1: networkPlayer.Character.GetComponent<Character>().Strenght.BaseValue += 1; break;
                case -1: if (playerCharacter.Strenght.BaseValue > 0) { playerCharacter.Strenght.BaseValue -= 1; } else { } break;

                case 2: playerCharacter.Agility.BaseValue += 1; break;
                case -2: if (playerCharacter.Agility.BaseValue > 0) { playerCharacter.Agility.BaseValue -= 1; } else { } break;

                case 3: playerCharacter.Intelligence.BaseValue += 1; break;
                case -3: if (playerCharacter.Intelligence.BaseValue > 0) { playerCharacter.Intelligence.BaseValue -= 1; } else { } break;

                case 4: playerCharacter.Vitality.BaseValue += 1; break;
                case -4: if (playerCharacter.Vitality.BaseValue > 0) { playerCharacter.Vitality.BaseValue -= 1; } else { } break;

                case 5: playerCharacter.Fight.skillValue += 1; break;
                case -5: if (playerCharacter.Fight.skillValue > 0) { playerCharacter.Fight.skillValue -= 1; } else { } break;

                case 6: playerCharacter.Shoot.skillValue += 1; break;
                case -6: if (playerCharacter.Shoot.skillValue > 0) { playerCharacter.Shoot.skillValue -= 1; } else { } break;

                case 7: playerCharacter.Brawl.skillValue += 1; break;
                case -7: if (playerCharacter.Brawl.skillValue > 0) { playerCharacter.Brawl.skillValue -= 1; } else { } break;

                case 8: playerCharacter.Dodge.skillValue += 1; break;
                case -8: if (playerCharacter.Dodge.skillValue > 0) { playerCharacter.Dodge.skillValue -= 1; } else { } break;

                case 9: playerCharacter.Block.skillValue += 1; break;
                case -9: if (playerCharacter.Block.skillValue > 0) { playerCharacter.Block.skillValue -= 1; } else { } break;

                case 10: playerCharacter.Athletics.skillValue += 1; break;
                case -10: if (playerCharacter.Athletics.skillValue > 0) { playerCharacter.Athletics.skillValue -= 1; } else { } break;

                case 11: playerCharacter.Physique.skillValue += 1; break;
                case -11: if (playerCharacter.Physique.skillValue > 0) { playerCharacter.Physique.skillValue -= 1; } else { } break;

                case 12: playerCharacter.Sneak.skillValue += 1; break;
                case -12: if (playerCharacter.Sneak.skillValue > 0) { playerCharacter.Sneak.skillValue -= 1; } else { } break;

                case 13: playerCharacter.Investigate.skillValue += 1; break;
                case -13: if (playerCharacter.Investigate.skillValue > 0) { playerCharacter.Investigate.skillValue -= 1; } else { } break;

                case 14: playerCharacter.Perception.skillValue += 1; break;
                case -14: if (playerCharacter.Perception.skillValue > 0) { playerCharacter.Perception.skillValue -= 1; } else { } break;

                case 15: playerCharacter.Language.skillValue += 1; break;
                case -15: if (playerCharacter.Language.skillValue > 0) { playerCharacter.Language.skillValue -= 1; } else { } break;

                case 16: playerCharacter.Knowledge.skillValue += 1; break;
                case -16: if (playerCharacter.Knowledge.skillValue > 0) { playerCharacter.Knowledge.skillValue -= 1; } else { } break;

                case 17: playerCharacter.Resources.skillValue += 1; break;
                case -17: if (playerCharacter.Resources.skillValue > 0) { playerCharacter.Resources.skillValue -= 1; } else { } break;

                case 18: playerCharacter.Intimidation.skillValue += 1; break;
                case -18: if (playerCharacter.Intimidation.skillValue > 0) { playerCharacter.Intimidation.skillValue -= 1; } else { } break;

                case 19: playerCharacter.Deceive.skillValue += 1; break;
                case -19: if (playerCharacter.Deceive.skillValue > 0) { playerCharacter.Deceive.skillValue -= 1; } else { } break;

                case 20: playerCharacter.Health.characterInfo += 1; break;
                case -20: if (playerCharacter.Health.characterInfo > 0) { playerCharacter.Health.characterInfo -= 1; } else { } break;

                case 21: playerCharacter.Mana.characterInfo += 1; break;
                case -21: if (playerCharacter.Mana.characterInfo > 0) { playerCharacter.Mana.characterInfo -= 1; } else { } break;

                case 22: playerCharacter.Level.characterInfo += 1; break;
                case -22: if (playerCharacter.Level.characterInfo > 0) { playerCharacter.Level.characterInfo -= 1; } else { } break;
            }

            foreach (StatDisplay stats in stat)
            {
                stats.UpdateStatValue();
            }
            foreach (SkillDisplay skills in skill)
            {
                skills.UpdateStatValue();
            }
            foreach (InfoDisplay infos in info)
            {
                infos.UpdateStatValue();
            }
          /*  if (button > -5 && button < 0 || button > 0 && button < 5)
            {
                
            }
            else if (button > -20 && button < -4 || button > 4 && button < 20)
            {
                
            }
            else
            {
               
            }*/
        }


    }

}
