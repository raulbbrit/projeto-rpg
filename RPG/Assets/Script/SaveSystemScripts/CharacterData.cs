using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData 
{
    public int strenght;
    public int agility;
    public int intelligence;
    public int vitality;

    public int fight;
    public int shoot;
    public int brawl;
    public int dodge;
    public int block;
    public int athletics;
    public int physique;
    public int sneak;
    public int investigate;
    public int perception;
    public int language;
    public int knowledge;
    public int resources;
    public int intimidation;
    public int deceive;

    public int level;
    public int health;
    public int mana;

    public string name;

    public List<EquipmentData> equipment;

    public CharacterData(Character charac)
    {
        Debug.Log("Charac: " + charac);
        Debug.Log("Entrou no construtor");
        strenght = (int)charac.Strenght.BaseValue;
        Debug.Log(charac.Strenght.BaseValue + " teste " + strenght);
        agility = (int)charac.Agility.BaseValue;
        intelligence = (int)charac.Intelligence.BaseValue;
        vitality = (int)charac.Vitality.BaseValue;
        fight = (int)charac.Fight.skillValue;
        shoot = (int)charac.Shoot.skillValue;
        brawl = (int)charac.Brawl.skillValue;
        dodge = (int)charac.Dodge.skillValue;
        block = (int)charac.Block.skillValue;
        athletics = (int)charac.Athletics.skillValue;
        physique = (int)charac.Physique.skillValue;
        sneak = (int)charac.Sneak.skillValue;
        investigate = (int)charac.Investigate.skillValue;
        perception = (int)charac.Perception.skillValue;
        language = (int)charac.Language.skillValue;
        knowledge = (int)charac.Knowledge.skillValue;
        resources = (int)charac.Resources.skillValue;
        intimidation = (int)charac.Intimidation.skillValue;
        deceive = (int)charac.Deceive.skillValue;
        level = (int)charac.Level.characterInfo;
        health = (int)charac.Health.characterInfo;
        mana = (int)charac.Mana.characterInfo;
        name = charac.Name.characterName;



       /* inventory = new EquippableItem[equip.Length];

        for (int i = 0; i < equip.Length; i++)
        {
            if (equip[i] != null)
            {
                
                    inventory[i] = (Seriali)GameObject.Instantiate(equip[i]);
                
                Debug.Log($"{i} = {inventory.GetType()}");
            }
            Criar Classe EquipData e passar dado por dado igual o Character Data
        }*/

        /*foreach (EquippableItem item in equip) {
            if (item != null)
            {
                Debug.Log("Item: " + item);
                inventory = item;
            }
            
        }*/
        
    }
}
