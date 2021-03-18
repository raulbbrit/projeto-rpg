using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuSlider : MonoBehaviour
{
   public bool menuIsShowing = false;
   public void MenuSliderController()
    {
        if(menuIsShowing == false)
        {
            SlideRight();
        }
        else if (menuIsShowing==true)
        {
            SlideLeft();
        }
    }
    public void SlideRight()
    {
      
        transform.LeanMoveLocal(new Vector2((float)-295.1, 1), 1).setEaseOutQuart();
        menuIsShowing = true;

    }
    private void SlideLeft()
    {
        transform.LeanMoveLocal(new Vector2((float)-728.9001, 1), 1).setEaseOutQuart();
        menuIsShowing = false;
    }
}

