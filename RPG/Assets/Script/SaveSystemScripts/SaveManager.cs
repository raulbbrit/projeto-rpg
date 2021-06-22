using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Mirror;
using System;

public class SaveManager : MonoBehaviour
{
    public GameObject saveCharacter;
    //public GameObject[] item;


 
    public void FindSaveCharcter(NetworkIdentity characterId)
    {
       
        try
        {
            saveCharacter = characterId.gameObject;
        }
        catch(Exception ex)
        {
            Debug.LogError(ex.Message);
        }
       
    }
    public void SaveCharacter()
    {
        SaveSystem.SaveCharacter(saveCharacter.GetComponent<Character>());
        SerializationManager.Save(SaveData.equipments);
    }

    public void SaveMaster()
    {
        SerializationManager.Save(SaveData.Npc);
        SerializationManager.Save(SaveData.Monster);
    }

}

   



