using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class NetworkPlayer : NetworkBehaviour
{
    private bool isHost = false;
    [SerializeField] GameObject masterPanel, playerPanel;
    [SerializeField] CharacterSpawn characterSpawn;
    private GameNetworkManager gameNetwork;
    public GameObject MasterPanel { get => masterPanel; set => masterPanel = value; }
    public GameObject PlayerPanel { get => playerPanel; set => playerPanel = value; }
    public CharacterSpawn CharacterSpawn { get => characterSpawn; set => characterSpawn = value; }

    public bool IsHost
    {
        get { return isHost; }
        set
        {
           isHost = value;
            Debug.Log("isHost= " + isHost.ToString());
            if (isLocalPlayer)
            {
                if (isHost == false)
                {

                    PlayerPanel.SetActive(true);
                    MasterPanel.SetActive(false);

                }
                if (isHost == true)
                {

                    PlayerPanel.SetActive(false);
                    MasterPanel.SetActive(true);
                }

            }


            /*   if (isHost == false)
               {
                   MasterPanel.SetActive(false);
                   if (hasAuthority)
                   {
                       PlayerPanel.SetActive(true);
                       MasterPanel.SetActive(false);
                   }

               }
               if (isHost == true)
               {
                   if(hasAuthority)
                   {
                       PlayerPanel.SetActive(false);
                       MasterPanel.SetActive(true);
                   }

               }
               //Insira lógica do host aqui com base no value*/
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


    [Client]
    private void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        PlayerPanel = GameObject.Find("Character Panel");
        //chamar o método de autoridade aqui.
        MasterPanel = GameObject.Find("Master Panel");
    }

    /* private void GiveAuthorityInPanel(NetworkConnection conn)
     {
         playerPanel.AssignClientAuthority(conn);
     }*/


    public override void OnStartClient()
    {
        DontDestroyOnLoad(gameObject);
        GameNetwork.PlayersList.Add(this);
        characterSpawn.Spawn(connectionToClient);
    }

    public override void OnStopClient()
    {
        GameNetwork.PlayersList.Remove(this);
    }

}
