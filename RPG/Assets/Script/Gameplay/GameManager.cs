using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void SelectPinObject(PickObjectButton pickObjectButton)
    {
        int spaceTile = Singleton<Hover>.Instance.QtdTile();

        if (NetworkClient.localPlayer == null)
        {
            if (Hover.indexPlayer <= 1)
            {
                Debug.Log(Hover.indexPlayer);
                this.SelectedObject = pickObjectButton;
            }
        }

        else if (NetworkClient.localPlayer.isServer)
        {
            
            if (Hover.indexMaster <= spaceTile)
            {

                this.SelectedObject = pickObjectButton;
            }

        }

         

            
    }

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
                if (NetworkClient.localPlayer.isClientOnly)
                {
                    if(Hover.indexPlayer >= 1)
                    {
                        if(Hover.hoverBool)
                        {
                    Hover.indexPlayer--;
                    Hover.Instance.DesactiveHover();
                    SelectedObject = null;

                        }
                    }
                }
                else if (NetworkClient.localPlayer.isServer)
                {
                    if(Hover.indexMaster >= 1)
                    {
                        if(Hover.hoverBool)
                        {
                    Hover.indexMaster--;
                        Debug.Log("GAMEMANAGER:" + Hover.indexMaster);
                        Hover.Instance.DesactiveHover();
                    SelectedObject = null;

                        }

                    }
                }
            }
        } catch
        {
            Debug.Log("Hover: Prefab desativado");
        }
         
    }

 
}
