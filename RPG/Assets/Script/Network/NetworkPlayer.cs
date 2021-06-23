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
    private GameObject saveManager;
    public GameObject MasterPanel { get => masterPanel; set => masterPanel = value; }
    public GameObject PlayerPanel { get => playerPanel; set => playerPanel = value; }
    public CharacterSpawn CharacterSpawn { get => characterSpawn; set => characterSpawn = value; }
    public GameObject SaveManager { get => saveManager; set => saveManager = value; }

    public bool IsHost
    {
        [Client]
        get { return isHost; }
        [Client]
        set
        {
           isHost = value;
           Debug.Log("isHost= " + isHost.ToString());
          
            
       /*       if (isHost == false && PlayerPanel.activeSelf==true)
                {

                    PlayerPanel.SetActive(true);
                    MasterPanel.SetActive(false);

                }
                if (isHost == true && MasterPanel.activeSelf==true)
                {
                    PlayerPanel.SetActive(false);
                    MasterPanel.SetActive(true);
                }
       /=*/
            
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
        SaveManager = GameObject.Find("SaveManager");
        if (isHost)
        {

            PlayerPanel.SetActive(true);
            MasterPanel.SetActive(false);

        }
        if (!isHost)
        {
            PlayerPanel.SetActive(false);
            MasterPanel.SetActive(true);
        }
    }

    /* private void GiveAuthorityInPanel(NetworkConnection conn)
     {
         playerPanel.AssignClientAuthority(conn);
     }*/


    public override void OnStartClient()
    {
        DontDestroyOnLoad(gameObject);
        GameNetwork.PlayersList.Add(this);
        //characterSpawn.Spawn(connectionToClient);
       saveManager.GetComponent<SaveManager>().FindSaveCharcter();
    }

    public override void OnStopClient()
    {
        GameNetwork.PlayersList.Remove(this);
    }

}
