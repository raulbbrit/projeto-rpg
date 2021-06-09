using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class GameNetworkManager : NetworkManager
{
 
      public static event Action OnclientConnected;
      public static event Action OnclientDisconnected;
    [SerializeField] private NetworkPlayer networkPlayerPrefab;
    [SerializeField] private GameObject characterSpawn;
    

    
    public List<NetworkPlayer> PlayersList { get;} = new List<NetworkPlayer>();

    public override void OnStartServer()
    {
        var gameObjects = Resources.LoadAll<GameObject>("SpawnablePrefabs").ToList();
        GameObject characterPrefab = gameObjects.Find(obj => obj.name == "Character");
        spawnPrefabs =  gameObjects;

    }
    public override void OnStartClient()
    {
        var spawnablePrefabs = Resources.LoadAll<GameObject>("SpawnablePrefabs");
        
        foreach (var prefab in spawnablePrefabs)
        {
            //ClientScene.RegisterPrefab(prefab); defasado!
            NetworkClient.RegisterPrefab(prefab);
        }
      
    }
    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        OnclientConnected?.Invoke();
        
    }
    public override void OnClientDisconnect(NetworkConnection conn)
    {
        base.OnClientDisconnect(conn);
        OnclientDisconnected?.Invoke();
    }
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        NetworkPlayer networkPlayerInstance= Instantiate(networkPlayerPrefab);
        bool isHost = PlayersList.Count==0; //verificando se é o host (primeiro a entrar)
      /*  for (int i = 0; i < PlayersList.Count; i++)
        {
            Debug.Log("A lista possuí: " +PlayersList.Count+" ishost= " + isHost.ToString());
        }*/
        networkPlayerInstance.IsHost = isHost;
        NetworkServer.AddPlayerForConnection(conn,networkPlayerInstance.gameObject);
        
    }
    public override void OnServerDisconnect(NetworkConnection conn)
    {
        if (conn.identity != null)
        {
            var OffPlayer = conn.identity.GetComponent<NetworkPlayer>();
            PlayersList.Remove(OffPlayer);
        }
        base.OnServerDisconnect(conn);
    }

    public override void OnStopServer()
    {
        base.OnStopServer();
    }

}
