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
            if (!npcNameInput.text.Trim(' ').Equals("") && !npcHealthInput.text.Trim(' ').Equals("") && !npcManaInput.text.Trim(' ').Equals("")) {
                GameObject _object = (GameObject)Instantiate(GameManager.Instance.SelectedObject.ObjectPrefab);
                SimpleNpc npc = _object.GetComponent<SimpleNpc>();

                npc.npcName = npcNameInput.text;
                npc.health = int.Parse(npcHealthInput.text);
                npc.mana = int.Parse(npcManaInput.text);

                npcScript.AddNpc(npc);

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
        else
        {
            if (!monsterNameInput.text.Trim(' ').Equals("") && !strengthInput.text.Trim(' ').Equals("") && !agilityInput.text.Trim(' ').Equals("") && !intelligenceInput.text.Trim(' ').Equals("") && !vitalityInput.text.Trim(' ').Equals(""))
            {
                GameObject _object = (GameObject)Instantiate(GameManager.Instance.SelectedObject.ObjectPrefab);
                MonsterNpc npc = _object.GetComponent<MonsterNpc>();

                npc.npcName = monsterNameInput.text;
                npc.health = int.Parse(monsterHealthInput.text);
                npc.mana = int.Parse(monsterManaInput.text);
                npc.strength = int.Parse(strengthInput.text);
                npc.intelligence = int.Parse(intelligenceInput.text);
                npc.vitality = int.Parse(vitalityInput.text);
                npc.agility = int.Parse(agilityInput.text);

                monsterScript.AddMonster(npc);

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
