using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Networking;
using AnotherFileBrowser.Windows;

public class AddUserInfos : MonoBehaviour
{
    public RawImage image;
    public Text name;

    void Start()
    {
        if (PlayerPrefs.GetString("userName") != null && PlayerPrefs.GetString("path") != null) {
           StartCoroutine(LoadImage(PlayerPrefs.GetString("path")));
           name.text = PlayerPrefs.GetString("userName");
           Debug.Log("Entrou If");          
        }
        else
        {
            name.text = "Guest";
        }
    }

    void Update()
    {
        StartCoroutine(LoadImage(PlayerPrefs.GetString("path")));
        name.text = PlayerPrefs.GetString("userName");
    }

    IEnumerator LoadImage(string path)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(path))
        {
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                Debug.Log("IEnumeraotr deu certo");
                var uwrTexture = DownloadHandlerTexture.GetContent(uwr);
                image.texture = uwrTexture;
                //UserInfos.SaveChanges();
            }
        }
    }
}
