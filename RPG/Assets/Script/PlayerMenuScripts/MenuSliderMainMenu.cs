using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuSliderMainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject optionBtn;
    [SerializeField]
    private GameObject exitBtn;
    [SerializeField]
    private GameObject aboutBtn;
    private Vector3 currentPosition;
    public bool menuIsShowing = false;

    private void Start()
    {
        optionBtn.SetActive(false);
        exitBtn.SetActive(false);
        aboutBtn.SetActive(false);
    }

    private void Update()
    {
        currentPosition = transform.localPosition;
        /*if (transform.position.x > -198)
        {
          
        }
        else if(transform.position.x >= -201 && transform.position.x <= -198)
        {
            optionBtn.SetActive(true);
            exitBtn.SetActive(true);
            aboutBtn.SetActive(true);
        }*/
        if (currentPosition.x >= 758 && currentPosition.x <= 761)
        {
            Debug.Log("Entrou no if");
            optionBtn.SetActive(true);
            exitBtn.SetActive(true);
            aboutBtn.SetActive(true);
        }
        else
        {
            optionBtn.SetActive(false);
            exitBtn.SetActive(false);
            aboutBtn.SetActive(false);
        }
        
    }


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

        transform.LeanMoveLocal(new Vector2((float)1167, 1), .8f).setEaseOutQuart();
        menuIsShowing = false;

    }
    private void SlideLeft()
    {
        transform.LeanMoveLocal(new Vector2((float)760, 1), .8f).setEaseOutQuart();
        menuIsShowing = true;
    }
}
