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
        RefreshUser();
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

    public void RefreshUser()
    {
        name.text = PlayerPrefs.GetString("userName");
        StartCoroutine(LoadImage(PlayerPrefs.GetString("path")));
    }

}
