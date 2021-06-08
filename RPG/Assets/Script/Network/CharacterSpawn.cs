using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CharacterSpawn : NetworkBehaviour
{
    [SerializeField] private GameObject characterPreFab;
    private NetworkPlayer networkPlayer;

    
    [Command]
    public void CmdSpawn()
    {
        networkPlayer = gameObject.GetComponent<NetworkPlayer>();
        Debug.Log("Entrou no método spawn");
        var valueIncrement = GameObject.Find("IncrementManager").GetComponent<ValuesIncrement>();
        characterPreFab = valueIncrement.CreateCharacter(characterPreFab).gameObject;
        //  GameObject CharacterInstance = Instantiate(characterPreFab);
        //  CharacterInstance.name = transform.name + " Character's";
        networkPlayer.Character = Instantiate(characterPreFab);
        networkPlayer.ChangePlayerCharacterName();
        NetworkServer.Spawn(networkPlayer.Character, connectionToClient);
    }
}
