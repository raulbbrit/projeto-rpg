using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcManager : MonoBehaviour
{
    [SerializeField] Text errormessage;
    [SerializeField] NpcList npcScript;
    [SerializeField] MonsterList monsterScript;
    [SerializeField] InputField npcNameInput;
    [SerializeField] InputField npcHealthInput;
    [SerializeField] InputField npcManaInput;
    [SerializeField] InputField monsterNameInput;
    [SerializeField] InputField monsterHealthInput;
    [SerializeField] InputField monsterManaInput;
    [SerializeField] InputField strengthInput;
    [SerializeField] InputField intelligenceInput;
    [SerializeField] InputField vitalityInput;
    [SerializeField] InputField agilityInput;

    public void AddNpc(int type)
    {
        
        if (type == 1) {
            
            if (!npcScript.IsFull()) {
                NpcData data = new NpcData();
                if (!npcNameInput.text.Trim(' ').Equals("") && !npcHealthInput.text.Trim(' ').Equals("") && !npcManaInput.text.Trim(' ').Equals("")) {
                    GameObject _object = (GameObject)Instantiate(GameManager.Instance.SelectedObject.ObjectPrefab);
                    SimpleNpc npc = _object.GetComponent<SimpleNpc>();

                    npc.id = DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString() + UnityEngine.Random.Range(0, int.MaxValue).ToString();
                    npc.npcName = npcNameInput.text;
                    npc.health = int.Parse(npcHealthInput.text);
                    npc.mana = int.Parse(npcManaInput.text);

                    npcScript.AddNpc(npc);

                    data.id = npc.id;
                    data.name = npcNameInput.text;
                    data.health = int.Parse(npcHealthInput.text);
                    data.mana = int.Parse(npcManaInput.text);
                    SaveData.Npc.Add(data);


                    npcNameInput.text = "";
                    npcManaInput.text = "";
                    npcHealthInput.text = "";
                    errormessage.enabled = false;
                }
                else
                {
                    errormessage.enabled = true;
                }
            }
        }
        else
        {
            
            if (!monsterScript.IsFull()) {
                MonsterData data = new MonsterData();
                if (!monsterNameInput.text.Trim(' ').Equals("") && !strengthInput.text.Trim(' ').Equals("") && !agilityInput.text.Trim(' ').Equals("") && !intelligenceInput.text.Trim(' ').Equals("") && !vitalityInput.text.Trim(' ').Equals(""))
                {
                    GameObject _object = (GameObject)Instantiate(GameManager.Instance.SelectedObject.ObjectPrefab);
                    MonsterNpc npc = _object.GetComponent<MonsterNpc>();

                    npc.id = DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString() + UnityEngine.Random.Range(0, int.MaxValue).ToString();
                    npc.npcName = monsterNameInput.text;
                    npc.health = int.Parse(monsterHealthInput.text);
                    npc.mana = int.Parse(monsterManaInput.text);
                    npc.strength = int.Parse(strengthInput.text);
                    npc.intelligence = int.Parse(intelligenceInput.text);
                    npc.vitality = int.Parse(vitalityInput.text);
                    npc.agility = int.Parse(agilityInput.text);

                    monsterScript.AddMonster(npc);

                    data.id = npc.id;
                    data.name = monsterNameInput.text;
                    data.health = int.Parse(monsterHealthInput.text);
                    data.mana = int.Parse(monsterManaInput.text);
                    data.strength = int.Parse(strengthInput.text);
                    data.intelligence = int.Parse(intelligenceInput.text);
                    data.vitality = int.Parse(vitalityInput.text);
                    data.agility = int.Parse(agilityInput.text);
                    SaveData.Monster.Add(data);

                    monsterNameInput.text = "";
                    monsterHealthInput.text = "";
                    monsterManaInput.text = "";
                    strengthInput.text = "";
                    intelligenceInput.text = "";
                    vitalityInput.text = "";
                    agilityInput.text = "";
                    errormessage.enabled = false;
                }
                else
                {
                    errormessage.enabled = true;
                }
            }
        }
    }
}
