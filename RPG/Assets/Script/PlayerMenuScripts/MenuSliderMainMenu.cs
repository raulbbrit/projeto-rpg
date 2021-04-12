using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuSliderMainMenu : MonoBehaviour
{
    public bool menuIsShowing = false;
    public void MenuSliderController()
    {
        if (menuIsShowing == false)
        {
            SlideLeft();
        }
        else if (menuIsShowing == true)
        {
            SlideRight();
        }
    }
    public void SlideRight()
    {

        transform.LeanMoveLocal(new Vector2((float)1167, 1), 1).setEaseOutQuart();
        menuIsShowing = false;

    }
    private void SlideLeft()
    {
        transform.LeanMoveLocal(new Vector2((float)760, 1), 1).setEaseOutQuart();
        menuIsShowing = true;
    }
}
