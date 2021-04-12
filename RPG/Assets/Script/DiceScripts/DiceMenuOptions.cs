using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiceMenuOptions : MonoBehaviour
{
    public void BackMenu()
    {
        SceneManager.LoadScene("PlayerMenu");
    }
}
