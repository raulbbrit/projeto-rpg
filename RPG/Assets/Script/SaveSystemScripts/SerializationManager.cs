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

        string path = Application.persistentDataPath + "/saves/" + "inventory.sheet";

        FileStream file = File.Create(path);

        formatter.Serialize(file, saveData);

        file.Close();

        return true;
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
    

    public static BinaryFormatter GetBinaryFormatter()
    {
        BinaryFormatter formater = new BinaryFormatter();

        return formater;
    }
}
