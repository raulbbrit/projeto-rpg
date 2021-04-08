using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("PlayerMenu");
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToOptions()
    {
        
    }

    public void ExitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("PlayerMenu");
    }
}
