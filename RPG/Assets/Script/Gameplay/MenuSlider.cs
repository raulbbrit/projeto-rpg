 using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuSlider : MonoBehaviour
{
    [SerializeField] Image button;
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
        button.transform.SetPositionAndRotation(new Vector3(30, 120, 0), Quaternion.Euler(0,0,0));
        //button.transform.Rotate(new Vector3(0,180,0));
        transform.LeanMoveLocal(new Vector2((float)-300.1, 1), 1).setEaseOutQuart();
        menuIsShowing = true;

    }
    private void SlideLeft()
    {
        button.transform.SetPositionAndRotation(new Vector3(1115, 120, 0), Quaternion.Euler(0, 180, 0));
        //button.transform.Rotate(new Vector3(0, -180, 0));
        transform.LeanMoveLocal(new Vector2((float)-728.9001, 1), 1).setEaseOutQuart();
        menuIsShowing = false;
    }
}

