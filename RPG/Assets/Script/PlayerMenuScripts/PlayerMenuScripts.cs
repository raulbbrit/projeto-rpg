using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMenuScripts : MonoBehaviour
{
    private void Awake()
    {
        Screen.fullScreen = true;
    }

    void JoinGame()
    {

    }

    public void HostGame()
    {
        SceneManager.LoadScene("PlayerScene");
    }

    public void PlayerInfo()
    {
        SceneManager.LoadScene("UserSettings");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
