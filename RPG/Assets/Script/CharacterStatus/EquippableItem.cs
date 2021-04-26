﻿using UnityEngine;

public enum EquipmentType
{
    Helmet,
    Chest,
    Gloves,
    Boots,
    Weapon1,
    Weapon2,
    Accessory1,
    Accessory2,
}


public class EquippableItem : Item
{
    public int StrengthBonus;
    public int AgilityBonus;
    public int IntelligenceBonus;
    public int VitalityBonus;
    [Space]
    public float StrengthPercentBonus;
    public float AgilityPercentBonus;
    public float IntelligencePercentBonus;
    public float VitalityPercentBonus;
    [Space]
    public EquipmentType EquipamentType;

    //Verifica qual status é modificado no personagem
    public void Equip(Character c)
    {
        if(StrengthBonus != 0)
        {
            c.Strenght.AddModifier(new StatModifier(StrengthBonus, StatModType.Flat, this));
        }
        if (AgilityBonus != 0)
        {
            c.Agility.AddModifier(new StatModifier(AgilityBonus, StatModType.Flat, this));
        }
        if (IntelligenceBonus != 0)
        {
            c.Intelligence.AddModifier(new StatModifier(IntelligenceBonus, StatModType.Flat, this));
        }
        if (VitalityBonus != 0)
        {
            c.Vitality.AddModifier(new StatModifier(VitalityBonus, StatModType.Flat, this));
        }
    }
    public void Unequip(Character c)
    {
        c.Strenght.RemoveAllModifiersFromSource(this);
        c.Agility.RemoveAllModifiersFromSource(this);
        c.Intelligence.RemoveAllModifiersFromSource(this);
        c.Vitality.RemoveAllModifiersFromSource(this);
    }
}
