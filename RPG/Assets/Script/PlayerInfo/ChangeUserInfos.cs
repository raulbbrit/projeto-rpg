using AnotherFileBrowser.Windows;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ChangeUserInfos : MonoBehaviour
{
   
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
        //Debug.Log("Entrou no IEnumerator");
       using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(path))
       {
                yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
    
                Debug.Log("Error " + uwr.error);
            }
            else  /*Não toque! 
            Quando eu fiz, estava junto com o Raul e Deus. Agora só Deus sabe como a gente arrumou isso*/
            {

                 var uwrTexture = DownloadHandlerTexture.GetContent(uwr);
                 rawImage.texture = uwrTexture;

                 if (uwrTexture.height > 2000 && uwrTexture.width > 2000 &&
                   (rawImage.transform.rotation.z >= -1 || rawImage.transform.rotation.z <= 1))
                 {

                    rawImage.transform.Rotate(new Vector3(0, 0, -100));
                    rawImage.transform.rotation = Quaternion.Euler(0, 0, -100);
                    /*
                    Debug.Log("Entrou no vector3 h (CHANG) " + uwrTexture.height.ToString());
                    Debug.Log("Entrou no vector3 w (CHANG) " + uwrTexture.width.ToString());
                    Debug.Log("Entrou no vector3 r (CHANG) " + rawImage.transform.rotation.z.ToString());
                    */

                 }
                if (uwrTexture.height < 2000 && uwrTexture.width < 2000 &&
                    (rawImage.transform.rotation.z >= 99 || rawImage.transform.rotation.z <= 101))
                {
                    rawImage.transform.rotation = Quaternion.Euler(0, 0, 0);
                    /*
                    Debug.Log("Entrou no vector3 h else (CHANG) " + uwrTexture.height.ToString());
                    Debug.Log("Entrou no vector3 w else (CHANG) " + uwrTexture.width.ToString());
                    */
                    rawImage.transform.Rotate(new Vector3(0, 0, 0f));

                }

            }

            UserInfos.path = path;
            //Debug.Log("IEnumeator : " + path);
            PlayerPrefs.SetString("path", path);
       }
    }

    public void ChangeUsername(Text newUsername)
    {
        if (!newUsername.text.Equals(""))
        {
            PlayerPrefs.SetString("userName", newUsername.text);
           // Debug.Log($"ChangeUsername: newUsername.text = {newUsername.text}");
        }
    }

    public void ResetInfos()
    {
        int rnd = 0;
        rnd = Random.Range(1000, 10001);

        PlayerPrefs.SetString("path", "");
        rawImage.texture = null;
        PlayerPrefs.SetString("userName", "Guest" + rnd);

        /*Debug.Log($"ResetInfos:" +
            $"\nuserName = {PlayerPrefs.GetString("userName")}" +
            $"\nPath: {PlayerPrefs.GetString("path")}" +
            $"\nResetInfos: ID = {rnd}");*/
    }

    public void RefreshUser()
    {
        //Debug.Log(PlayerPrefs.GetString("path").GetType());
        StartCoroutine(LoadImage(PlayerPrefs.GetString("path")));
        input.text = PlayerPrefs.GetString("userName");

        /*Debug.Log($"RefreshUser:\n" +
            $"\nuserName = {PlayerPrefs.GetString("userName")}" +
            $"\nPath: {PlayerPrefs.GetString("path")}");*/
    }
}
