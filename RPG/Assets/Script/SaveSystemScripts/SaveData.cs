using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    private static List<EquipmentData> _equipments;
    public static List<EquipmentData> equipments
    {
        get
        {
            if (_equipments == null)
            {
                _equipments = new List<EquipmentData>();
            }
            return _equipments;
        }
        set
        {
            if (value != null)
            {
                _equipments = value;
            }
        }
    }

    private static List<NpcData> _npc;
    public static List<NpcData> Npc
    {
        get
        {
            if (_npc == null)
            {
                _npc = new List<NpcData>();
            }
            return _npc;
        }
        set
        {
            if (value != null)
            {
                _npc= value;
            }
        }
    }

    private static List<MonsterData> _monster;
    public static List<MonsterData> Monster
    {
        get
        {
            if (_monster == null)
            {
                _monster = new List<MonsterData>();
            }
            return _monster;
        }
        set
        {
            if (value != null)
            {
                _monster = value;
            }
        }
    }


    /*private static List<EquipmentData> _equipmentsaux;
    public static List<EquipmentData> equipmentsaux
    {
        get
        {
            if (_equipmentsaux == null)
            {
                _equipmentsaux = new List<EquipmentData>();
            }
            return _equipmentsaux;
        }
        set
        {
            if (value != null)
            {
               
                _equipmentsaux = value;

            }
        }
    }*/

}
