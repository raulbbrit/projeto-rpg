using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PinScript : MonoBehaviour
{
    public SpriteRenderer bg;
    private Sprite sprites;

    private void Start()
    {
        bg = GetComponentInChildren<SpriteRenderer>();
        StartCoroutine(LoadImage(PlayerPrefs.GetString("path")));
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
                change(uwrTexture);
            }
        }


    }
    private void change(Texture2D sprite)
    {
        if (sprite.width <= 300 && sprite.height <= 300)
        {
            Rect rec = new Rect(0, 0, sprite.width, sprite.height);
            //Sprite.Create(sprite, rec, new Vector2(0, 0), 1);
            sprites = Sprite.Create(sprite, rec, new Vector2(0.52f, 0.6f), 90);
        }
        if (sprite.width > 400 && sprite.height > 400)
        {
            Rect rec = new Rect(0, 0, sprite.width, sprite.height);
            //Sprite.Create(sprite, rec, new Vector2(0, 0), 1);
            sprites = Sprite.Create(sprite, rec, new Vector2(0.52f, 0.6f), 150);
        }


        bg.sprite = sprites;
    }
}
