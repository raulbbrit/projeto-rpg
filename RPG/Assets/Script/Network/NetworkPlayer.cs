using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class NetworkPlayer : NetworkBehaviour
{
    private bool isHost = false;
    GameObject masterPanel, playerPanel;
    private GameNetworkManager gameNetwork;

    public bool IsHost
    {
        get { return isHost; }
        set
        {
            isHost = value;
            Debug.Log("isHost= " + isHost.ToString());
            if (isHost == false)
            {
                masterPanel.SetActive(false);
                playerPanel.SetActive(true);
            }
            if (isHost == true)
            {
               playerPanel.SetActive(false);
               masterPanel.SetActive(true);
            }
            //Insira lógica do host aqui com base no value
        }
    }

    private GameNetworkManager GameNetwork
    {
        get
        {
            if (gameNetwork != null) { return gameNetwork; }
            return gameNetwork = NetworkManager.singleton as GameNetworkManager;
        }
    }

    private void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        playerPanel = GameObject.Find("Character Panel");
        //chamar o método de autoridade aqui.
        masterPanel = GameObject.Find("Master Panel");
    }

   /* private void GiveAuthorityInPanel(NetworkConnection conn)
    {
        playerPanel.AssignClientAuthority(conn);
    }*/

  
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
