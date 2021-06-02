using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private int indexPlayer = 0;
    private int indexMaster = 0;
    private TileScript[] tiles;
    public PickObjectButton SelectedObject { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        tiles = GameObject.Find("Map").GetComponentsInChildren<TileScript>();

        for(int x = 0; x < tiles.Length; x++)
        {
            tiles[x] = GetComponentInChildren<GameObject>();
        }
    }
    //foreach ()
    //{

    //}

    public void SelectObject(PickObjectButton pickObjectButton)
    {
        int spaceTile = Singleton<Hover>.Instance.QtdTile();

        if (NetworkClient.localPlayer.isClientOnly)
        {
            if(indexPlayer < 1)
            {
            indexPlayer++;
            this.SelectedObject = pickObjectButton;
            } 
        }
        else
        {
            if(indexMaster < spaceTile)
            {
                indexMaster++;
            this.SelectedObject = pickObjectButton;
            }

        }

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

   private void RemovePin()
    {

    }
}
