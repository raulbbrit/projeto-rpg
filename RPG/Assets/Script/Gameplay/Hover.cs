
using UnityEngine;

public class Hover : Singleton<Hover>
{
    // Start is called before the first frame update
    [SerializeField] GameObject getGameObject;

    public GameObject GetGameObject { get => getGameObject; set => getGameObject = value; }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowMouse();
        
    }

    private void FollowMouse()
    {
        if (this.GetGameObject.activeSelf == true)
        { 
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 8);
        }

    }
    public void ActivateHover()
    {
        this.GetGameObject.SetActive(true);
      
    }

    public void DesactiveHover()
    { 
            this.GetGameObject.SetActive(false);
    }


}
