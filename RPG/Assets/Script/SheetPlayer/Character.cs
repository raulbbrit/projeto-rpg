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
    public CharacterStat Agility;
    public CharacterStat Intelligence;
    public CharacterStat Vitality;

    [Space]
    [Header("Charecter Skills")]
    public CharacterSkill Fight;
    public CharacterSkill Shoot;
    public CharacterSkill Brawl;
    public CharacterSkill Dodge;
    public CharacterSkill Block;
    public CharacterSkill Athletics;
    public CharacterSkill Physique;
    public CharacterSkill Sneak;
    public CharacterSkill Investigate;
    public CharacterSkill Perception;
    public CharacterSkill Language;
    public CharacterSkill Knowledge;
    public CharacterSkill Resources;
    public CharacterSkill Intimidation;
    public CharacterSkill Deceive;

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

    /*
    private Inventory inventory;
    private EquipmentPanel equipmentPanel;
    private StatPanel statPanel;
    private SkillPanel skillPanel;
    */


  

    /*private void Awake()
    {
        statPanel.SetStats(Strenght, Agility, Intelligence, Vitality);
        statPanel.UpadeStatValues();

        skillPanel.SetSkills(Fight, Shoot, Brawl, Dodge, Block, Athletics, Physique, Sneak, Investigate, Perception, Language,
            Knowledge, Resources, Intimidation, Deceive);
        skillPanel.UpadeStatValues();
        
        inventory.OnItemRightClickedEvent += EquipFromInventory;
        equipmentPanel.OnItemRightClickedEvent += UnequipFromEquipPanel;
    }*/

    /*private void Start()
    {
        charin =  GetComponent<Character>();

    }*/

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
    // Hooks //

    public void HookObjectName(string currentObjectName, string newObjectName)
    {
        transform.name = newObjectName;
        Debug.Log("HookObjectName" + transform.name);
    }

}
