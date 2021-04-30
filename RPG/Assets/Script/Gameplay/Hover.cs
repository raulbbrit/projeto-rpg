
using UnityEngine;

public class Hover : Singleton<Hover>
{
    // Start is called before the first frame update
    private GameObject icon;
    [SerializeField] private GameObject getGameObject;
    //public GameObject Icon { get => icon; set => icon = value; }
    private int delay;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowMouse();
        
    }

    private Vector3 FollowMouse()
    {
        //Vector3 mousePosition = Input.mousePosition;
        //mousePosition.z = 10;
        //transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        //return mousePosition;
         transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         transform.position = new Vector3(transform.position.x, transform.position.y, 8);

        return transform.position;
        //Hover.Instance.Activate(null) in the PlaceTower() 
    }
    public void ActivateHover()
    {
        this.getGameObject.SetActive(true);
      
    }

    public void DesactiveHover()
    { 
            this.getGameObject.SetActive(false);
    }
}
