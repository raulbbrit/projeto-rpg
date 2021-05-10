using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HostConnect : NetworkManager
{

    NetworkManager manager;
    [SerializeField] private InputField ip_InputField;


    void Awake()
    {
        manager = GetComponent<NetworkManager>();
    }

    public void HostFunction()
    {
        manager.OnStartHost();
        SceneManager.LoadScene("PlayerScene");
        NetworkClient.Ready();

        if (NetworkClient.localPlayer == null)
        {
            NetworkClient.AddPlayer();
        }
    }

    public void ConnectFunction()
    {
        manager.networkAddress = ip_InputField.text;
        manager.StartClient();
        SceneManager.LoadScene("PlayerScene");
        NetworkClient.Ready();

        if (NetworkClient.localPlayer == null)
        {
            NetworkClient.AddPlayer();
        }
    }
}

