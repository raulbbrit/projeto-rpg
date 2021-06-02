using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CharacterSpawn : NetworkBehaviour
{
    [SerializeField] private GameObject characterPreFab;
    
   
    public  void Spawn(NetworkConnection conn,string name)
    {
        //Debug.Log("Conn ID: " + conn.identity);
        var valueIncrement = GameObject.Find("IncrementManager").GetComponent<ValuesIncrement>();
        characterPreFab = valueIncrement.CreateCharacter(characterPreFab).gameObject;
        GameObject playerInstance = Instantiate(characterPreFab);
        playerInstance.name = name + " Character's";
        NetworkServer.Spawn(playerInstance, conn);
     
    }
    /*[Command]
    private void CmdSpawnMessage()
    {
        Debug.Log("Personagem Spawnado");
        RpcSpawnMessagae();
    }
    [ClientRpc]
    public void RpcSpawnMessagae()
    {
        Debug.Log("Personagem spawnado");
    }*/
}
