using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SerializationManager
{
    public static bool Save(object saveData)
    {
        BinaryFormatter formatter =  GetBinaryFormatter();

        if (!Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves/");
        }

        if (saveData is List<EquipmentData>) {
            string path = Application.persistentDataPath + "/saves/" + "inventory.sheet";

            FileStream file = File.Create(path);

            formatter.Serialize(file, saveData);

            file.Close();

            return true;
        }
        if (saveData is List<NpcData>)
        {
            string path = Application.persistentDataPath + "/saves/" + "npc.sheet";

            FileStream file = File.Create(path);

            formatter.Serialize(file, saveData);

            file.Close();
            Debug.Log("Salvou!!!NPC");
            return true;
        }
        if (saveData is List<MonsterData>)
        {
            string path = Application.persistentDataPath + "/saves/" + "monster.sheet";

            FileStream file = File.Create(path);

            formatter.Serialize(file, saveData);

            file.Close();

            return true;
        }
        return false;
    }

    public static object Load(string path)
    {
        if (!File.Exists(path))
        {
            return null;
        }

        BinaryFormatter formatter = GetBinaryFormatter();

        FileStream file = File.Open(path, FileMode.Open);

        try
        {
            object save = formatter.Deserialize(file);
            file.Close();
            return save;
        }
        catch
        {
            Debug.Log("Erro ao recuperar inventário");
            file.Close();
            return null;
        }
    }

    public static void DeleteOldSave(int i)
    {
        string path;
        if (i == 1) {
            path = Application.persistentDataPath + "/saves/inventory.sheet";
            if (File.Exists(path))
            {

                File.Delete(path);
                
            }
            else
            {
                Debug.Log("Arquivo nao encontrado");
                
            }
        }
        if (i == 2)
        {
            path = Application.persistentDataPath + "/saves/npc.sheet";
            if (File.Exists(path))
            {

                File.Delete(path);
               
            }
            else
            {
                Debug.Log("Arquivo nao encontrado");
                
            }

            path = Application.persistentDataPath + "/saves/monster.sheet";
            if (File.Exists(path))
            {

                File.Delete(path);
                
            }
            else
            {
                Debug.Log("Arquivo nao encontrado");
                
            }

        }
        
    }
    

    public static BinaryFormatter GetBinaryFormatter()
    { 
        BinaryFormatter formater = new BinaryFormatter();

        return formater;
    }
}
