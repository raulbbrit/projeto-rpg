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
       RpcDebugMessage(playerIdentity);

        StatDisplay[] stat = statScript.GetComponentsInChildren<StatDisplay>();
        SkillDisplay[] skill = skillScript.GetComponentsInChildren<SkillDisplay>();
        InfoDisplay[] info = infoScript.GetComponentsInChildren<InfoDisplay>();
        if (button != 0)
        {

            switch (button)
            {
                case 1: playerCharacter.SyncStrenght += 1; break;
                // case 1: networkPlayer.Character.GetComponent<Character>().Strenght.BaseValue += 1; break;
                case -1: if (playerCharacter.SyncStrenght > 0) { playerCharacter.SyncStrenght -= 1; } else { } break;

                case 2: playerCharacter.SyncAgility += 1; break;
                case -2: if (playerCharacter.SyncAgility > 0) { playerCharacter.SyncAgility -= 1; } else { } break;

                case 3: playerCharacter.SyncIntelligence += 1; break;
                case -3: if (playerCharacter.SyncIntelligence > 0) { playerCharacter.SyncIntelligence -= 1; } else { } break;

                case 4: playerCharacter.SyncVitality += 1; break;
                case -4: if (playerCharacter.SyncVitality > 0) { playerCharacter.SyncVitality -= 1; } else { } break;

                case 5: playerCharacter.SyncFight += 1; break;
                case -5: if (playerCharacter.SyncFight > 0) { playerCharacter.SyncFight -= 1; } else { } break;

                case 6: playerCharacter.SyncShoot += 1; break;
                case -6: if (playerCharacter.SyncShoot > 0) { playerCharacter.SyncShoot -= 1; } else { } break;

                case 7: playerCharacter.SyncBrawl += 1; break;
                case -7: if (playerCharacter.SyncBrawl > 0) { playerCharacter.SyncBrawl -= 1; } else { } break;

                case 8: playerCharacter.SyncDodge += 1; break;
                case -8: if (playerCharacter.SyncDodge > 0) { playerCharacter.SyncDodge -= 1; } else { } break;

                case 9: playerCharacter.SyncBlock += 1; break;
                case -9: if (playerCharacter.SyncBlock > 0) { playerCharacter.SyncBlock -= 1; } else { } break;

                case 10: playerCharacter.SyncAthletics += 1; break;
                case -10: if (playerCharacter.SyncAthletics > 0) { playerCharacter.SyncAthletics -= 1; } else { } break;

                case 11: playerCharacter.SyncPhysique += 1; break;
                case -11: if (playerCharacter.SyncPhysique > 0) { playerCharacter.SyncPhysique -= 1; } else { } break;

                case 12: playerCharacter.SyncSneak += 1; break;
                case -12: if (playerCharacter.SyncSneak > 0) { playerCharacter.SyncSneak -= 1; } else { } break;

                case 13: playerCharacter.SyncInvestigate += 1; break;
                case -13: if (playerCharacter.SyncInvestigate > 0) { playerCharacter.SyncInvestigate -= 1; } else { } break;

                case 14: playerCharacter.SyncPerception += 1; break;
                case -14: if (playerCharacter.SyncPerception > 0) { playerCharacter.SyncPerception -= 1; } else { } break;

                case 15: playerCharacter.SyncLanguage += 1; break;
                case -15: if (playerCharacter.SyncLanguage > 0) { playerCharacter.SyncLanguage -= 1; } else { } break;

                case 16: playerCharacter.SyncKnowledge += 1; break;
                case -16: if (playerCharacter.SyncKnowledge > 0) { playerCharacter.SyncKnowledge -= 1; } else { } break;

                case 17: playerCharacter.SyncResources += 1; break;
                case -17: if (playerCharacter.SyncResources > 0) { playerCharacter.SyncResources -= 1; } else { } break;

                case 18: playerCharacter.SyncIntimidation += 1; break;
                case -18: if (playerCharacter.SyncIntimidation > 0) { playerCharacter.SyncIntimidation -= 1; } else { } break;

                case 19: playerCharacter.SyncDeceive += 1; break;
                case -19: if (playerCharacter.SyncDeceive > 0) { playerCharacter.SyncDeceive -= 1; } else { } break;

                case 20: playerCharacter.SyncHealth += 1; break;
                case -20: if (playerCharacter.SyncHealth > 0) { playerCharacter.SyncHealth -= 1; } else { } break;

                case 21: playerCharacter.SyncMana += 1; break;
                case -21: if (playerCharacter.SyncMana > 0) { playerCharacter.SyncMana -= 1; } else { } break;

                case 22: playerCharacter.SyncLevel += 1; break;
                case -22: if (playerCharacter.SyncLevel > 0) { playerCharacter.SyncLevel -= 1; } else { } break;
            }

              if (button > -5 && button < 0 || button > 0 && button < 5)
              {
                  foreach (StatDisplay stats in stat)
                  {
                  stats.UpdateStatValue();
                  }
              }
              else if (button > -20 && button < -4 || button > 4 && button < 20)
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

    [ClientRpc]
    public void RpcDebugMessage(NetworkIdentity playerid)
    {
        try
        {
            Character playerCharacter = playerid.gameObject.GetComponent<NetworkPlayer>().CharacterIdentity.gameObject.GetComponent<Character>();
            Debug.Log("Personagem = " + playerCharacter.gameObject.name);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
     
    }

}
