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
    private GameObject character;
    private GameNetworkManager gameNetwork;
    private GameObject saveManager;
    private string newName;
    public GameObject MasterPanel { get => masterPanel; set => masterPanel = value; }
    public GameObject PlayerPanel { get => playerPanel; set => playerPanel = value; }
    public CharacterSpawn CharacterSpawn { get => characterSpawn; set => characterSpawn = value; }
    public GameObject SaveManager { get => saveManager; set => saveManager = value; }
    public string NewName { get => newName; set => newName = value; }

    public GameObject Character { get => character; set => character = value; }

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
        CharacterPrepares();
    }

  
    public override void OnStartLocalPlayer()
    {
        SaveManager = GameObject.Find("SaveManager");
        PrepareSave();
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
        ChangePlayerCharacterName();
        foreach (var networkPlayer in GameNetwork.PlayersList)
        {

            Debug.Log(networkPlayer.Character.name);
         
        }
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

    private void ChangePlayerObjetcName()
    {
        if (hasAuthority)
        {
            transform.name = "Jogador " + GameNetwork.PlayersList.Count;
            CmdChangePlayerName(transform.name);
        }
      
    }
   
  
    private void CharacterPrepares()
    {
        CharacterSpawn.CmdSpawn();
        
        
    }

    public void ChangePlayerCharacterName()
    {
        if (hasAuthority)
        {
            transform.name = "Jogador " + GameNetwork.PlayersList.Count;
            CmdChangePlayerCharacterName(Character.name = transform.name + " Character's");
        }
       
    }

    // COMMAND //

    [Command]
    public void CmdChangePlayerName(string newplayerName)
    {
        transform.name = newplayerName;
        RpcChangePlayerName(newplayerName);
    }

    [Command]
    private void CmdChangePlayerCharacterName(string newCharacterName)
    {

    }
    // RPCS //

    [ClientRpc]
    private void RpcChangePlayerName(string newplayerName)
    {
        transform.name = newplayerName;
    }
    [ClientRpc]
    private void RpcChangePlayerCharacterName(string newplayerName)
    {
        transform.name = newplayerName;
    }

}
