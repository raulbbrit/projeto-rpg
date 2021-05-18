using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkPlayer : NetworkBehaviour
{
    private bool isHost;
    public bool IsHost
    {
        set
        {
            isHost = value;
            //Insira lógica do host aqui com base no value
        }
    }
    private GameNetworkManager gameNetwork;
    private GameNetworkManager GameNetwork
    {
        get
        {
            if (gameNetwork!=null) { return gameNetwork; }
            return gameNetwork = NetworkManager.singleton as GameNetworkManager;
        }
    }

    public override void OnStartClient()
    {
        DontDestroyOnLoad(gameObject);
        GameNetwork.PlayersList.Add(this);

    }
    public override void OnStopClient()
    {
        GameNetwork.PlayersList.Remove(this);
    }
}
