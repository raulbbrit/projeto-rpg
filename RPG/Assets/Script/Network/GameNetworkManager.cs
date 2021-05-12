using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class GameNetworkManager : NetworkManager
{
    [Scene] [SerializeField] private string gameScene;
    public static event Action OnclientConnected;
    public static event Action OnclientDisconnected;
    [SerializeField] private NetworkPlayer networkPlayer;
    
   
    public override void OnStartServer()
    {
        var gameObjects = Resources.LoadAll<GameObject>("SpawnablePrefabs").ToList();
        spawnPrefabs =  gameObjects;
    }
    public override void OnStartClient()
    {
        var spawnablePrefabs = Resources.LoadAll<GameObject>("SpawnablePrefabs");

        foreach(var prefab in spawnablePrefabs)
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
        NetworkPlayer player= Instantiate(networkPlayer);
        NetworkServer.AddPlayerForConnection(conn,networkPlayer.gameObject);
    }
    
}
