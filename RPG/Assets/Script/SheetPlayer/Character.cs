using UnityEngine;
using System.IO;

public class Character : MonoBehaviour
{
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

    /*
    private Inventory inventory;
    private EquipmentPanel equipmentPanel;
    private StatPanel statPanel;
    private SkillPanel skillPanel;
    */


    public Inventory Inventory { get => inventory; set => inventory = value; }
    public EquipmentPanel EquipmentPanel { get => equipmentPanel; set => equipmentPanel = value; }
    public StatPanel StatPanel { get => statPanel; set => statPanel = value; }
    public SkillPanel SkillPanel { get => skillPanel; set => skillPanel = value; }
    public InfoPanel InfoPanel { get => infoPanel; set => infoPanel = value; }
    public NamePanel NamePanel { get => namePanel; set => namePanel = value; }

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
        string path = Application.persistentDataPath + "/character.sheet";
        if (File.Exists(path)) {
            LoadCharacter();  
        }
        Name.characterName =  PlayerPrefs.GetString("userName");
        statPanel.SetStats(Strenght, Agility, Intelligence, Vitality);
        statPanel.UpadeStatValues();

        skillPanel.SetSkills(Fight, Shoot, Brawl, Dodge, Block, Athletics, Physique, Sneak, Investigate, Perception, Language,
            Knowledge, Resources, Intimidation, Deceive);
        skillPanel.UpadeSkillValues();

        infoPanel.SetInfos(Level, Health, Mana);
        infoPanel.UpadeStatValues();

        namePanel.SetName(Name);
        namePanel.UpadeStatValues();

        inventory.OnItemLeftClickedEvent += EquipFromInventory;
        Debug.Log("Passou no equipfrom");
        inventory.OnItemRightClickedEvent += DeleteFromInventory;

        equipmentPanel.OnItemRightClickedEvent += UnequipFromEquipPanel;

    }


    private void EquipFromInventory(Item item)
    {
        Debug.Log("Equipfrom entrou");
        if (item is EquippableItem)
        {
            Debug.Log("passou do if");
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
                    statPanel.UpadeStatValues();
                }
                item.Equip(this);

                //Deletar do save quando equipar
                foreach (EquipmentData data in SaveData.equipments.ToArray())
                {
                    if (data.id == item.id)
                    {
                        Debug.Log("Entrou no if Delete");
                        SaveData.equipments.Remove(data);
                    }
                }
                statPanel.UpadeStatValues();
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
            EquipmentData equip = new EquipmentData();
            item.Unequip(this);
            statPanel.UpadeStatValues();
            inventory.AddItem(item);
            //recolocar o item na lista de save
            equip.id = item.id;
            equip.itemName = item.ItemName;
            equip.strength = item.StrengthBonus;
            equip.intelligence = item.IntelligenceBonus;
            equip.agility = item.AgilityBonus;
            equip.vitality = item.VitalityBonus;
            equip.equipType = item.EquipamentType;

            SaveData.equipments.Add(equip);
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


        

        
    }
}
