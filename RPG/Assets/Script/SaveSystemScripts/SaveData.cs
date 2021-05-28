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

    private static List<EquipmentData> _equipmentsaux;
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
    }

}
