using UnityEngine;
using UnityEngine.UI;


public class DiceMenuOptions : MonoBehaviour
{
    [SerializeField] Image button;
    public bool menuIsShowing = false;
    public void MenuSliderController()
    {
        if (menuIsShowing == false)
        {
            SlideDown();
        }
        else if (menuIsShowing == true)
        {
            SlideUp();
        }
    }
    public void SlideDown()
    {
        button.transform.SetPositionAndRotation(new Vector3(1300, 1435, 0), Quaternion.Euler(0, 0, -90));
        //button.transform.Rotate(new Vector3(0,180,0));
        transform.LeanMoveLocal(new Vector2(0, 290), 1).setEaseOutQuart();
        menuIsShowing = true;

    }
    private void SlideUp()
    {
        button.transform.SetPositionAndRotation(new Vector3(1260, 423, 0), Quaternion.Euler(0, 0, 90));
        //button.transform.Rotate(new Vector3(0, -180, 0));
        transform.LeanMoveLocal(new Vector2(0, 689), 1).setEaseOutQuart();
        menuIsShowing = false;
    }
}
