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
}
