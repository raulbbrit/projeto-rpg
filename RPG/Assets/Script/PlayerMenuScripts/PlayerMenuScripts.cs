using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMenuScripts : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    private void Update()
    {
        
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
        StartCoroutine(SeeYouNextTime());
    }

    
    IEnumerator SeeYouNextTime()
    {
        audioSource.Play();
        yield return new WaitForSeconds(3.3f);
        Debug.Log("Fechou o programa");
        Application.Quit();
    }
}
