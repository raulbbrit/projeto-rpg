using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public Character saveCharacter;
    public GameObject[] item;


    private void Start()
    {
         saveCharacter = GameObject.Find("Character(Clone)").GetComponent<Character>();
           

        if (saveCharacter==null)
        {
            Debug.Log("saveCharacter==null");
        }
    }

    private void Update()
    {
        
    }

    public void Save()
    {
        SaveSystem.SaveCharacter(saveCharacter);

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

        
    SerializationManager.Save(SaveData.equipments);

    /*}
    else
    {
        SerializationManager.Save(SaveData.equipments);
        Debug.Log("nada");
    }*/
    }

}

   



