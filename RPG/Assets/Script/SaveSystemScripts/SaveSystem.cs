using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public static class SaveSystem
{

    public static void SaveCharacter(Character charac)
    {
        Debug.Log("Charac Save: " + charac);
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/character.sheet";
        Debug.Log("Caminho: " + path);

        FileStream stream = new FileStream(path, FileMode.Create);

        CharacterData data = new CharacterData(charac);

        formatter.Serialize(stream, data);
        stream.Close();

        Debug.Log("Salvou");
    }

    public static CharacterData LoadCharacter()
    {
        string path = Application.persistentDataPath + "/character.sheet";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CharacterData data = formatter.Deserialize(stream) as CharacterData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save not found");
            return null;
        }
    }

    public static void DeleteCharacter()
    {
        string path = Application.persistentDataPath + "/character.sheet";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else
        {
            Debug.Log("Save not found");
        }
    }


}
