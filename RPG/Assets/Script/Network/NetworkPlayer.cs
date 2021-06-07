using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;
using System;

public class NetworkPlayer : NetworkBehaviour
{
    private bool isHost = false;
    [SerializeField] private GameObject masterPanel, playerPanel;
    [SerializeField] private CharacterSpawn characterSpawn;
    private GameNetworkManager gameNetwork;
    private GameObject saveManager;
    private string newName;
    public GameObject MasterPanel { get => masterPanel; set => masterPanel = value; }
    public GameObject PlayerPanel { get => playerPanel; set => playerPanel = value; }
    public CharacterSpawn CharacterSpawn { get => characterSpawn; set => characterSpawn = value; }
    public GameObject SaveManager { get => saveManager; set => saveManager = value; }
    public string NewName { get => newName; set => newName = value; }


    public bool IsHost
    {
        get { return isHost; }
        
        set
        {
           
           isHost = value;
           Debug.Log("isHost= " + isHost.ToString());
               /** if (isHost == false && PlayerPanel.activeSelf==true)
                {

                    PlayerPanel.SetActive(true);
                    MasterPanel.SetActive(false);

                }
                if (isHost == true && MasterPanel.activeSelf==true)
                {
                    PlayerPanel.SetActive(false);
                    MasterPanel.SetActive(true);
                }*/

            
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


    public override void OnStartClient()
    {
        DontDestroyOnLoad(gameObject);
    }

    public override void OnStartLocalPlayer()
    {
        CharacterSpawn = GetComponent<CharacterSpawn>();
        GameNetwork.PlayersList.Add(this);
        ChangePlayerObjetcName();
        CharacterPrepares();
        base.OnStartLocalPlayer();
    }

    public override void OnStopClient()
    {
        GameNetwork.PlayersList.Remove(this);
    }

    // CLIENT //
    [Client]
    public void Start()
    {
        PlayerPanel = GameObject.Find("Character Panel");
        MasterPanel = GameObject.Find("Master Panel");
        CharacterSpawn = GetComponent<CharacterSpawn>();
    }

    [Client]
    private void PrepareSave()
    {
        if (isClient)
        {
            Debug.Log("isclient");
            saveManager.GetComponent<SaveManager>().FindSaveCharcter();
        }
    }

   // [Client]
    private void ChangePlayerObjetcName()
    {
        CmdChangePlayerName("Jogador " + GameNetwork.PlayersList.Count);
    }
   
    //[Client]
    private void CharacterPrepares()
    {
        CharacterSpawn.CmdSpawn();
        SaveManager = GameObject.Find("SaveManager");
        PrepareSave();
    }

    // COMMAND //
    
    [Command]
    public void CmdChangePlayerName(string newplayerName)
    {
        transform.name = newplayerName;
        RpcChangePlayerName(newplayerName);

    }

    // RPCS //

    [ClientRpc]
    private void RpcChangePlayerName(string newplayerName)
    {
        transform.name = newplayerName;
    }
}
