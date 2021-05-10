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

    // Update is called once per frame
    void Update()
    {
        
    }
    // Pega o objeto com o click do botão
    public void SelectObject(PickObjectButton pickObjectButton) 
    {
        this.SelectedObject = pickObjectButton;
        if(SelectedObject.HoverIcon != null)
        {
            Hover.Instance.ActvateHover(SelectedObject.HoverIcon);
        }
      
    }

    public void ObjectReleased()
    {
        SelectedObject = null;
        Hover.Instance.ActvateHover(null);
    }



}
