using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    private static SaveData _current;
    public static SaveData current
    {
        get
        {
            if (_current == null)
            {
                _current = new SaveData();
            }
            return _current;
        }
        set
        {
            if (value != null)
            {
                _current = value;
                
            }
        }
    }

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

}
