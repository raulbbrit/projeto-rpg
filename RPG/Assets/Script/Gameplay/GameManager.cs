using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameManager : Singleton<GameManager>
{

    public PickObjectButton SelectedObject { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //foreach ()
    //{

    //}

    public void SelectObject(PickObjectButton pickObjectButton)
    {
        this.SelectedObject = pickObjectButton;

    }

    // Update is called once per frame
    void Update()
    {
        HandleEscape();
    }
    // Pega o objeto com o click do botão


    public void ObjectReleased()
    {
        SelectedObject = null;
        Hover.Instance.DesactiveHover();
    }

    public void HandleEscape()
    {

        try
        {
            if (Input.GetMouseButtonDown(1))
            {
                Hover.Instance.DesactiveHover();
                SelectedObject = null;
            }
        } catch
        {
            Debug.Log("Hover: Prefab desativado");
        }
         
    }

    public void LocalIncrementRequest(int button)
    {
        NetworkPlayer networkPlayer = NetworkClient.connection.identity.gameObject.GetComponent<NetworkPlayer>();
        networkPlayer.CmdCallForIncrement(button, networkPlayer.netIdentity);
    }
}
