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


  /*  private void Start()
    {
         saveCharacter = GameObject.Find(NetworkClient.connection.identity.gameObject.name + " Character's").GetComponent<Character>();
    }*/
    public void FindSaveCharcter()
    {
        Debug.Log("NO SAVE: " + NetworkClient.connection.identity.gameObject.name);
        try
        {
            saveCharacter = GameObject.Find(NetworkClient.connection.identity.gameObject.name + " Character's");
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
        /*for (int i = 0; i < SaveData.equipments.Count; i++)
        {
            Debug.Log(SaveData.equipments[i].itemName);
        }*/
        //SaveData.equipmentsaux = (List<EquipmentData>)SerializationManager.Load(Application.persistentDataPath + "/saves/inventory.sheet");


        //SaveData.equipmentsaux = SaveData.equipments; //atribuindo lista duplicada na aux
        //Debug.Log("Save lista: " + SaveData.equipments.Count);

        /*if (SaveData.equipments.Count==1)
        {
            int ActualSaveSize = SaveData.equipments.Count / 2;  //pegando o tamanho que realmente precisamos do save
            SaveData.equipments.Clear();  //limpando a lista duplicada
            for (int i = 0; i < ActualSaveSize; i++)
            {

                foreach (EquipmentData item in SaveData.equipmentsaux)
                {

                    /** if (item.id == SaveData.equipments[i].id)
                     {
                         SaveData.equipments.RemoveAt(i);
                         Debug.Log("Copia encontrada");
                     }
                    SaveData.equipments.Add(item);
                }
            }

        }*/
        //Debug.Log("Saveaux lista: " + SaveData.equipmentsaux.Count);

        /*if (File.Exists(Application.persistentDataPath + "/saves/inventory.sheet"))
        {
            for (int i = 0; i < SaveData.equipments.Count; i++) {
                
                foreach (EquipmentData item in SaveData.equipmentsaux) {

                    if (item.id == SaveData.equipments[i].id)
                    {
                        SaveData.equipments.RemoveAt(i);
                        Debug.Log("Copia encontrada");
                    }
                }
            }*/
        /* if (File.Exists(Application.persistentDataPath + "/saves/inventory.sheet"))
         {
             Debug.Log("Entrou aqui delete");
             SerializationManager.DeleteOldSave(Application.persistentDataPath + "/saves/inventory.sheet");
         }*/
        /*}
        else
        {
            SerializationManager.Save(SaveData.equipments);
            Debug.Log("nada");
        }*/
    }

    public void SaveMaster()
    {
        SerializationManager.Save(SaveData.Npc);
        SerializationManager.Save(SaveData.Monster);
    }

}

   



