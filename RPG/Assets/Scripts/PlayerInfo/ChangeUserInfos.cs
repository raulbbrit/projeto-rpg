using AnotherFileBrowser.Windows;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class ChangeUserInfos : MonoBehaviour
{
    public RawImage staticRawImage;
    public RawImage rawImage;
    public InputField input;  

    void Start()
    {
        RefreshUser();
    }

    public void OpenFileBrowser()
    {
        var bp = new BrowserProperties();
        bp.filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
        bp.filterIndex = 0;

        new FileBrowser().OpenFileBrowser(bp, path =>
        {
            //Load image from local path with UWR
            StartCoroutine(LoadImage(path));
        });
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
                var uwrTexture = DownloadHandlerTexture.GetContent(uwr);
                rawImage.texture = uwrTexture;
                staticRawImage.texture = uwrTexture;
                UserInfos.path = path;
                PlayerPrefs.SetString("path", path);
            }
        }
    }

    public void ChangeUsername(Text newUsername)
    {
        if (!newUsername.text.Equals(""))
        {
            PlayerPrefs.SetString("userName", newUsername.text);
        }
    }

    public void ResetInfos()
    {
        PlayerPrefs.SetString("path", "");
        PlayerPrefs.SetString("userName", null);
    }

    void RefreshUser()
    {
        input.text = PlayerPrefs.GetString("userName");
        StartCoroutine(LoadImage(PlayerPrefs.GetString("path")));
    }
}
