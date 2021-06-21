using UnityEngine;
using System.IO;
using Mirror;
using System;

public class Character : NetworkBehaviour
{
    public Character charin;
    private int fieldCheck;
    public int FieldsCheck{
        get { return fieldCheck; }
        set
        {
            fieldCheck = value;
            if (fieldCheck==6)
            {
                Debug.Log("FIELDSCHECK==6");
                SetFieldsAndUI();
                fieldCheck = 0;
            }
        }
    }
    [SyncVar (hook= nameof (HookObjectName))]
    string currentobjectname;
    [Header("Character Stats")]
    public CharacterStat Strenght;
    [SyncVar(hook = nameof(HookStrenght))]public float SyncStrenght;

 

    public CharacterStat Agility;
    [SyncVar(hook = nameof(HookAgility))] float Sync;
    public CharacterStat Intelligence;
    [SyncVar(hook = nameof(HookIntelligence))] float SyncIntelligence;
    public CharacterStat Vitality;
    [SyncVar(hook = nameof(HookVitality))]
    float SyncVitality;

     [Space]
    [Header("Charecter Skills")]
    public CharacterSkill Fight;
    [SyncVar(hook = nameof(HookFight))]
    float SyncFight;

    private static object HookFight()
    {
        throw new NotImplementedException();
    }

    public CharacterSkill Shoot;
    [SyncVar(hook = nameof(HookShoot))]
    float SyncShoot;

    private static object HookShoot()
    {
        throw new NotImplementedException();
    }

    public CharacterSkill Brawl;
    [SyncVar(hook = nameof(HookBrawl))]
    float SyncBrawl;

    private static object HookBrawl()
    {
        throw new NotImplementedException();
    }

    public CharacterSkill Dodge;
    [SyncVar(hook = nameof(HookDodge))]
    float SyncDodge;

    private static object HookDodge()
    {
        throw new NotImplementedException();
    }

    public CharacterSkill Block;
    [SyncVar(hook = nameof(HookBlock))]
    float SyncBlock;

    private static object HookBlock()
    {
        throw new NotImplementedException();
    }

    public CharacterSkill Athletics;
    [SyncVar(hook = nameof(HookAthletics))]
    float SyncAthletics;

    private static object HookAthletics()
    {
        throw new NotImplementedException();
    }

    public CharacterSkill Physique;
    [SyncVar(hook = nameof(HookPhysique))]
    float SyncPhysique;

    private static object HookPhysique()
    {
        throw new NotImplementedException();
    }

    public CharacterSkill Sneak;
    [SyncVar(hook = nameof(HookSneak))]
    float SyncSneak;

    private static object HookSneak()
    {
        throw new NotImplementedException();
    }

    public CharacterSkill Investigate;
    [SyncVar(hook = nameof(HookInvestigate))]
    float SyncInvestigate;

    private static object HookInvestigate()
    {
        throw new NotImplementedException();
    }

    public CharacterSkill Perception;
    [SyncVar(hook = nameof(HookPerception))]
    float SyncPerception;

    private static object HookPerception()
    {
        throw new NotImplementedException();
    }

    public CharacterSkill Language;
    [SyncVar(hook = nameof(HookLanguage))]
    float SyncLanguage;

    private static object HookLanguage()
    {
        throw new NotImplementedException();
    }

    public CharacterSkill Knowledge;
    [SyncVar(hook = nameof(HookKnowledge))]
    float SyncKnowledge;

    private static object HookKnowledge()
    {
        throw new NotImplementedException();
    }

    public CharacterSkill Resources;
    [SyncVar(hook = nameof(HookResources))]
    float SyncResources;

    private static object HookResources()
    {
        throw new NotImplementedException();
    }

    public CharacterSkill Intimidation;
    [SyncVar(hook = nameof(HookIntimidation))]
    float SyncIntimidation;

    private static object HookIntimidation()
    {
        throw new NotImplementedException();
    }

    public CharacterSkill Deceive;
    [SyncVar(hook = nameof(HookDeceive))]
    float SyncDeceive;

    private static object HookDeceive()
    {
        throw new NotImplementedException();
    }

    [Space]
    [Header("Character Information")]
    public CharacterInfos Level;
    public CharacterInfos Health;
    public CharacterInfos Mana;

    [Space]
    [Header("Character Name")]
    public CharacterName Name;

    [Space]
    [Header("Panels to start the UI")]
    [SerializeField] Inventory inventory;
    [SerializeField] EquipmentPanel equipmentPanel;
    [SerializeField] StatPanel statPanel;
    [SerializeField] SkillPanel skillPanel;
    [SerializeField] InfoPanel infoPanel;
    [SerializeField] NamePanel namePanel;

    [Space]
    [Header("Panels Syncvars")]
    [SerializeField] [SyncVar(hook = nameof(HookInventorySyncString))] string inventorySyncString;
    [SerializeField] [SyncVar(hook = nameof(HookEquipmentPanelSyncString))] string equipmentPanelSyncString;
    [SerializeField] [SyncVar(hook = nameof(HookStatPanelSyncString))] string statPanelSyncString;
    [SerializeField] [SyncVar(hook = nameof(HookSkillPanelSyncString))] string skillPanelSyncString;
    [SerializeField] [SyncVar(hook = nameof(HookInfoPanelSyncString))] string infoPanelSyncString;
    [SerializeField] [SyncVar(hook = nameof(HookNamePanelSyncString))] string namePanelSyncString;

    public Inventory Inventory { get => inventory; set => inventory = value; }
    public EquipmentPanel EquipmentPanel { get => equipmentPanel; set => equipmentPanel = value; }
    public StatPanel StatPanel { get => statPanel; set => statPanel = value; }
    public SkillPanel SkillPanel { get => skillPanel; set => skillPanel = value; }
    public InfoPanel InfoPanel { get => infoPanel; set => infoPanel = value; }
    public NamePanel NamePanel { get => namePanel; set => namePanel = value; }
    public string Currentobjectname { get => currentobjectname; set => currentobjectname = value; }
    public string InventorySyncString { get => inventorySyncString; set => inventorySyncString = value; }
    public string EquipmentPanelSyncString { get => equipmentPanelSyncString; set => equipmentPanelSyncString = value; }
    public string StatPanelSyncString { get => statPanelSyncString; set => statPanelSyncString = value; }
    public string SkillPanelSyncString { get => skillPanelSyncString; set => skillPanelSyncString = value; }
    public string InfoPanelSyncString { get => infoPanelSyncString; set => infoPanelSyncString = value; }
    public string NamePanelSyncString { get => namePanelSyncString; set => namePanelSyncString = value; }

  
    //Hooks

    public void HookInventorySyncString(string oldstring, string stringReference)
    {
        Debug.Log("HookInventorySyncString "+ stringReference);
        Inventory = GameObject.Find(stringReference).GetComponent<Inventory>();
        FieldsCheck++;
    }



    public void HookEquipmentPanelSyncString(string oldstring, string stringReference)
    {
        Debug.Log("HookEquipmentPanelSyncString "+ stringReference);
        EquipmentPanel = GameObject.Find(stringReference).GetComponent<EquipmentPanel>();
        FieldsCheck++;
    }


    public void HookStatPanelSyncString(string oldstring, string stringReference)
    {
        Debug.Log("HookStatPanelSyncString "+ stringReference);
        StatPanel = GameObject.Find(stringReference).GetComponent<StatPanel>();
        FieldsCheck++;
    }



    public void HookSkillPanelSyncString(string oldstring, string stringReference)
    {
        Debug.Log("HookSkillPanelSyncString" + stringReference);
        SkillPanel = GameObject.Find(stringReference).GetComponent<SkillPanel>();
        FieldsCheck++;
    }



    public void HookInfoPanelSyncString(string oldstring, string stringReference)
    {
        Debug.Log("HookInfoPanelSyncString" + stringReference);
        InfoPanel = GameObject.Find(stringReference).GetComponent<InfoPanel>();
        FieldsCheck++;
    }



    public void HookNamePanelSyncString(string oldstring, string stringReference)
    {
        Debug.Log("HookNamePanelSyncString" + stringReference);
        NamePanel = GameObject.Find(stringReference).GetComponent<NamePanel>();
        FieldsCheck++;
    }

    public void HookObjectName(string currentObjectName, string newObjectName)
    {
        transform.name = newObjectName;
        Debug.Log("HookObjectName" + transform.name);
    }
    public void HookStrenght(float oldValue, float newValue)
    {
        Strenght.BaseValue = newValue;
    }
    public void HookAgility(float oldValue, float newValue)
    {
        Strenght.BaseValue = newValue;
    }
    public void HookIntelligence(float oldValue, float newValue)
    {
        Strenght.BaseValue = newValue;
    }
    public void HookVitality(float oldValue, float newValue)
    {
        Strenght.BaseValue = newValue;
    }
   

    public void SetFieldsAndUI()
    {
        Debug.Log("SET FIELDS AND UI");
        string path = Application.persistentDataPath + "/character.sheet";
        if (File.Exists(path)) {
            LoadCharacter();  
        }
        Name.characterName = PlayerPrefs.GetString("userName");
        try
        {
            statPanel.SetStats(Strenght, Agility, Intelligence, Vitality);
            statPanel.UpdateStatValues();

            skillPanel.SetSkills(Fight, Shoot, Brawl, Dodge, Block, Athletics, Physique, Sneak, Investigate, Perception, Language,
                Knowledge, Resources, Intimidation, Deceive);
            skillPanel.UpadeSkillValues();

            infoPanel.SetInfos(Level, Health, Mana);
            infoPanel.UpadeStatValues();

            namePanel.SetName(Name);
            namePanel.UpadeStatValues();

            inventory.OnItemLeftClickedEvent += EquipFromInventory;
            inventory.OnItemRightClickedEvent += DeleteFromInventory;

            equipmentPanel.OnItemRightClickedEvent += UnequipFromEquipPanel;
        }
        catch (Exception e)
        {
            Debug.LogError("SetFieldsAndUI erro: "+e.Message);
        }
     
    }


    private void EquipFromInventory(Item item)
    {
        if (item is EquippableItem)
        {
            Equip((EquippableItem)item);
        }
    }

    private void UnequipFromEquipPanel(Item item)
    {
        if (item is EquippableItem)
        {
            Unequip((EquippableItem)item);
        }
    }

    public void Equip(EquippableItem item)
    {
        if (inventory.RemoveItems(item))
        {
            EquippableItem previousItem;
            if (equipmentPanel.AddItem(item, out previousItem))
            {
                if (previousItem != null)
                {
                    inventory.AddItem(previousItem);
                    previousItem.Unequip(this);
                    statPanel.UpdateStatValues();
                }
                item.Equip(this);
                statPanel.UpdateStatValues();
            }
            else
            {
                inventory.AddItem(item);
            }
        }
    }

    public void Unequip(EquippableItem item)
    {
        if (!inventory.IsFull() && equipmentPanel.RemoveItem(item))
        {
            item.Unequip(this);
            statPanel.UpdateStatValues();
            inventory.AddItem(item);
        }
    }

    public void DeleteFromInventory(Item item)
    {
        if (item is EquippableItem)
        {
            Delete((EquippableItem)item);
        }
    }

    public void Delete(EquippableItem item)
    {
        if (inventory.RemoveItems(item))
        {
            foreach (EquipmentData data in SaveData.equipments.ToArray())
            {
                if (data.id == item.id)
                {
                    Debug.Log("Entrou no if Delete");
                    SaveData.equipments.Remove(data);
                }
            }
            Destroy(item.gameObject);
        }
    }

    /*public void SavePlayer()
    {
        SaveSystem.SaveCharacter(charin);
    }*/

    public void LoadCharacter()
    {
        CharacterData data = SaveSystem.LoadCharacter();

        Strenght.BaseValue = data.strenght;
        Intelligence.BaseValue = data.intelligence;
        Vitality.BaseValue = data.vitality;
        Agility.BaseValue = data.agility;
        Fight.skillValue = data.fight;
        Shoot.skillValue = data.shoot;
        Brawl.skillValue = data.brawl;
        Dodge.skillValue = data.dodge;
        Block.skillValue = data.block;
        Athletics.skillValue = data.athletics;
        Physique.skillValue = data.physique;
        Sneak.skillValue = data.sneak;
        Investigate.skillValue = data.investigate;
        Perception.skillValue = data.perception;
        Language.skillValue = data.language;
        Knowledge.skillValue = data.knowledge;
        Resources.skillValue = data.resources;
        Intimidation.skillValue = data.intimidation;
        Deceive.skillValue = data.deceive;
        Level.characterInfo = data.level;
        Mana.characterInfo = data.mana;
        Health.characterInfo = data.health;
      //  Name.characterName = PlayerPrefs.GetString("userName");

        

        
    }


}
