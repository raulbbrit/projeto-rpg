using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMenuScripts : MonoBehaviour
{
    private int holdSec = 0;

    void JoinGame()
    {

    }

    public void HostGame()
    {
        SceneManager.LoadScene("DiceTest");
    }

    public void PlayerInfo()
    {
        SceneManager.LoadScene("UserSettings");
    }

    public void ExitGame(AudioClip audio)
    {
        Debug.Log("Saiu");
        Application.Quit();
    }
}
