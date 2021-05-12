using UnityEngine;

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
    public CharacterInfos Name;
    public CharacterInfos Level;

    
    [SerializeField] Inventory inventory;
    [SerializeField] EquipmentPanel equipmentPanel;
    [SerializeField] StatPanel statPanel;
    [SerializeField] SkillPanel skillPanel;
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

    public void SetFieldsAndUI()
    {
        statPanel.SetStats(Strenght, Agility, Intelligence, Vitality);
        statPanel.UpadeStatValues();

        skillPanel.SetSkills(Fight, Shoot, Brawl, Dodge, Block, Athletics, Physique, Sneak, Investigate, Perception, Language,
            Knowledge, Resources, Intimidation, Deceive);
        skillPanel.UpadeStatValues();

        inventory.OnItemRightClickedEvent += EquipFromInventory;
        equipmentPanel.OnItemRightClickedEvent += UnequipFromEquipPanel;
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
                    statPanel.UpadeStatValues();
                }
                item.Equip(this);
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
            item.Unequip(this);
            statPanel.UpadeStatValues();
            inventory.AddItem(item);
        }
    }
}
