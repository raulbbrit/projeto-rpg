using System.Collections;
using System.Collections.Generic;
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
        SerializationManager.Save(SaveData.equipments); 
    }

   


}
