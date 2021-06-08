using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CharacterSpawn : NetworkBehaviour
{
    [SerializeField] private GameObject characterPreFab;

    
    [Command]
    public void CmdSpawn()
    {
        
        Debug.Log("Entrou no método spawn");
        var valueIncrement = GameObject.Find("IncrementManager").GetComponent<ValuesIncrement>();
        characterPreFab = valueIncrement.CreateCharacter(characterPreFab).gameObject;
        GameObject CharacterInstance = Instantiate(characterPreFab);
        CharacterInstance.name = transform.name + " Character's";
        NetworkServer.Spawn(CharacterInstance, connectionToClient);
    }
}
