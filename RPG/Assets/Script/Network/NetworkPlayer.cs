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
    [SyncVar(hook= nameof(HookName))] string currentName;
    public GameObject MasterPanel { get => masterPanel; set => masterPanel = value; }
    public GameObject PlayerPanel { get => playerPanel; set => playerPanel = value; }
    public CharacterSpawn CharacterSpawn { get => characterSpawn; set => characterSpawn = value; }
    public GameObject SaveManager { get => saveManager; set => saveManager = value; }
    public string CurrentName{ get => currentName; set => currentName = value; }


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
        CharacterSpawn = GetComponent<CharacterSpawn>();
        GameNetwork.PlayersList.Add(this);
        ChangePlayerObjetcName();
     
    }

    public override void OnStartLocalPlayer()
    {
        SaveManager = GameObject.Find("SaveManager");
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
        CharacterPrepares();
        PrepareSave();

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

    [Client]
    private void ChangePlayerObjetcName()
    {
        if (hasAuthority)
        {
            //transform.name = "Jogador " + GameNetwork.PlayersList.Count;
            CmdChangePlayerName("Jogador " + GameNetwork.PlayersList.Count);
        }
      
    }
   
    [Client]
    private void CharacterPrepares()
    {
        if (hasAuthority)
        {
            CharacterSpawn.CmdSpawn();
        }
      
        
    }

    // COMMAND //
    
    [Command]
    public void CmdChangePlayerName(string newplayerName)
    {
        this.currentName = newplayerName;
        //RpcChangePlayerName(newplayerName);
    }

    // RPCS //

    

    //Hooks
    public void HookName(string currentName, string newName)
    {
        transform.name = newName;
        Debug.Log("NAMEHOOK: "+transform.name);
    }
    
}
