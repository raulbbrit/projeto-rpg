using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CharacterSpawn : NetworkBehaviour
{
    [SerializeField] private GameObject characterPreFab;
       
    public void Spawn(NetworkConnection conn)
    {
        var valueIncrement = GameObject.Find("IncrementManager").GetComponent<ValuesIncrement>();
        characterPreFab = valueIncrement.CreateCharacter(characterPreFab).gameObject;
        GameObject playerInstance = Instantiate(characterPreFab);
        playerInstance.name = NetworkClient.connection.identity.gameObject.name + " Character's";
        NetworkServer.Spawn(playerInstance, conn);
    }
}
