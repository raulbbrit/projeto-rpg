using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // [SerializeField] private GameObject pinPreFab;
    /*public GameObject PinPreFab
    {
        get
        {
            return pinPreFab;
        }
    }*/
    public PickObjectButton SelectedObject { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Pega o objeto com o click do botão
    public void SelectObject( PickObjectButton pickObjectButton) 
    {
        this.SelectedObject = pickObjectButton;
       
        
    }

    public void ObjectReleased()
    {
        SelectedObject = null;
        Hover.Instance.DesactiveHover();
    }



}
