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

                if (uwr.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.Log(uwr.error);
                }
                else
                {
                    Debug.Log("IEnumeraotr deu certo");
                    var uwrTexture = DownloadHandlerTexture.GetContent(uwr);
                    image.texture = uwrTexture;

                    if (uwrTexture.height > 2000 && uwrTexture.width > 2000 &&
                    (image.transform.rotation.z >= -1 || image.transform.rotation.z <= 1))
                    {
                        
                     image.transform.Rotate(new Vector3(0, 0, -100));
                    image.transform.rotation = Quaternion.Euler(0, 0, -100);
                    /*
                    Debug.Log("Entrou no vector3 h (ADD) " + uwrTexture.height.ToString());
                    Debug.Log("Entrou no vector3 w (ADD) " + uwrTexture.width.ToString());
                    Debug.Log("Entrou no vector3 r (ADD) " + image.transform.rotation.z.ToString());
                    */
                }
                    if (uwrTexture.height < 2000 && uwrTexture.width < 2000 &&
                    (image.transform.rotation.z >= 99 || image.transform.rotation.z <= 101))
                    {
                    image.transform.Rotate(new Vector3(0, 0, 0));
                    image.transform.rotation = Quaternion.Euler(0, 0, 0);
                    /*
                    Debug.Log("Entrou no vector3 h (ADD) " + uwrTexture.height.ToString());
                    Debug.Log("Entrou no vector3 w (ADD) " + uwrTexture.width.ToString());
                    Debug.Log("Entrou no vector3 r (ADD) " + image.transform.rotation.z.ToString());
                    */
                }

                }
            }
        
    }

    public void RefreshUser()
    {
        if (PlayerPrefs.GetString("userName").Trim(' ').Equals("") || PlayerPrefs.GetString("userName") == null)
        {
            int rnd = 0;
            rnd = Random.Range(1000, 10001);
            PlayerPrefs.SetString("userName", "Guest" + rnd);
            name.text = PlayerPrefs.GetString("userName");
        }
        else
        {
            name.text = PlayerPrefs.GetString("userName");
        }

        if (!PlayerPrefs.GetString("path").Equals("")) {
            StartCoroutine(LoadImage(PlayerPrefs.GetString("path")));
        }
        else
        {
            image.texture = null;
        }
    }

}
