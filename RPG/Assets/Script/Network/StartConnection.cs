using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartConnection : MonoBehaviour
{

    
    [SerializeField] private InputField ip_InputField;
    [SerializeField] private GameNetworkManager gameNetworkManager;

    public void HostFunction()
    {
        gameNetworkManager.StartHost();
        
    }

    public void ConnectFunction()
    {
        gameNetworkManager.networkAddress = ip_InputField.text;
        gameNetworkManager.StartClient();
    }
}

