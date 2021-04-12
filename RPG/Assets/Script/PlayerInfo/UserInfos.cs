using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInfos
{
    //public static string userImage;
    public static string path;
    public static string userName = "Guest";

    public static void SaveChanges()
    {
        Debug.Log("entrou aqui");
        PlayerPrefs.SetString("path", path);
        PlayerPrefs.SetString("userName", userName);
    }
}
