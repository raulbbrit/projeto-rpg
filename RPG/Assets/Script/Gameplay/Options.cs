using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mirror;

public class Options : MonoBehaviour
{

    [SerializeField] GameObject menu;
    private bool isShow = false;


    private void Update()
    {
      
        if(!isShow && Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenu();
        }
    }

    public void ExitGame()
    {
        if (NetworkClient.localPlayer == null)
        {

            NetworkManager.singleton.StopClient();
            SceneTransitionManager.Return();

        }
        else if (NetworkClient.localPlayer.isServer)
        {
            NetworkManager.singleton.StopHost();
            SceneTransitionManager.Return();

        } 

        SceneManager.LoadScene("PlayerMenu");


    }

    public void OpenMenu()
    {
        isShow = true;
        menu.SetActive(true);
        Debug.Log("Abriu");
    }

    public void CloseMenu()
    {
        isShow = false;
        menu.SetActive(false);
        Debug.Log("Fechou");
    }
}
