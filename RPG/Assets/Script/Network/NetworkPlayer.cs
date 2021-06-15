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
    [SerializeField] private SaveManager saveManager;
    [SerializeField] private Character playercharacter;
    [SyncVar(hook= nameof(HookName))] string currentName;
    [SerializeField] [SyncVar(hook = nameof(HookCharacter))] string currentCharacterName;
    public GameObject MasterPanel { get => masterPanel; set => masterPanel = value; }
    public GameObject PlayerPanel { get => playerPanel; set => playerPanel = value; }
    public CharacterSpawn CharacterSpawn { get => characterSpawn; set => characterSpawn = value; }
    public SaveManager SaveManager { get => saveManager; set => saveManager = value; }
    public string CurrentName{ get => currentName; set => currentName = value; }

    public Character Playercharacter { get => playercharacter; set => playercharacter = value; }

    public string CurrentCharacterName { get => currentCharacterName; set => currentCharacterName = value; }


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
        CharacterSpawn = GetComponent<CharacterSpawn>();
        CharacterPrepares();
        AssignCharacterToPlayer();
        Debug.Log("StartClient");
    }

  

    public override void OnStartLocalPlayer()
    {
        Debug.Log("LocalPlayer");
        
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
        PrepareSave();
    }

    [Client]
    private void PrepareSave()
    {
        if (isClient && hasAuthority)
        {
          
            SaveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
            if (saveManager != null)
            {
                try
                {

                    saveManager.GetComponent<SaveManager>().saveCharacter = GameObject.Find(gameObject.name+ " Character's");

                }  catch (Exception ex)
                {
                    Debug.LogError(ex.Message);
                }
               
            }
            else
            {
                Debug.Log("Savemanager null");
            }
          
        }
    }

    [Client]
    private void ChangePlayerObjetcName()
    {
        if (hasAuthority)
        {
            transform.name = "Jogador " + GameNetwork.PlayersList.Count;
            Debug.Log("No Player: " + NetworkClient.connection.identity.gameObject.name);
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
    [Client]
    private void AssignCharacterToPlayer()
    {
        if (hasAuthority)
        {
            CmdAssingCharacterToPlayer();
        }
    }

   
    // COMMAND //

    [Command]
    public void CmdChangePlayerName(string newplayerName)
    {
        this.currentName = newplayerName;
        //RpcChangePlayerName(newplayerName);
    }
    [Command]
    private void CmdAssingCharacterToPlayer()
    {
        this.currentCharacterName = transform.name + " Character's";
    }

    // RPCS //



    //Hooks
    public void HookName(string currentName, string newName)
    {
        transform.name = newName;
        Debug.Log("NAMEHOOK: "+transform.name);
    }

    public void HookCharacter(string currentCharacter, string newCharacter)
    {

        this.playercharacter = GameObject.Find(newCharacter).GetComponent<Character>();
        Debug.Log("HookCharacter: " + newCharacter);
    }


}
