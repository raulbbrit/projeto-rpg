using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CharacterSpawn : NetworkBehaviour
{
    [SerializeField] private GameObject characterPreFab;
    private GameNetworkManager gameNetwork;

    private GameNetworkManager GameNetwork
    {
        get
        {
            if (gameNetwork != null) { return gameNetwork; }
            return gameNetwork = NetworkManager.singleton as GameNetworkManager;
        }
    }
    //CMDS//
    [Command]
    public void CmdSpawn()
    {
        
        NetworkIdentity CallingPlayer = connectionToClient.identity;
        Debug.Log("Entrou no método spawn");
        var valueIncrement = GameObject.Find("IncrementManager").GetComponent<ValuesIncrement>();
        characterPreFab = valueIncrement.CreateCharacter(characterPreFab).gameObject;
        GameObject CharacterInstance = Instantiate(characterPreFab);
        CharacterInstance.name = transform.name + " Character's";
        NetworkServer.Spawn(CharacterInstance, connectionToClient);
        CharacterInstance.GetComponent<Character>().Currentobjectname = transform.name + " Character's";
        RpcAssignCharacterToPlayer(CharacterInstance.gameObject.GetComponent<Character>().netIdentity, CallingPlayer);
    }
    //RPC//
    [ClientRpc]
    public void RpcAssignCharacterToPlayer(NetworkIdentity characterNetworkIdentity,NetworkIdentity playerNetworkIdentity)
    {
        playerNetworkIdentity.gameObject.GetComponent<NetworkPlayer>().AssignCharacterToPlayer(characterNetworkIdentity);

   
    }
}
