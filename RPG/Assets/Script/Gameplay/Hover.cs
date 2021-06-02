using UnityEngine;
using Mirror;

public class Hover : Singleton<Hover>
{
    // Start is called before the first frame update
    [SerializeField] GameObject getGameObject;
    public int indexMaster = 0;
    public int indexPlayer = 0;
    private GameObject spaceObject;

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
     
        if (NetworkClient.localPlayer.isClientOnly)
        {
            if (indexPlayer < 1)
            {
                indexPlayer++;
                getGameObject.SetActive(true);
            }
        }
        else
        {
            if (indexMaster < QtdTile())
            {
                indexMaster++;   
                getGameObject.SetActive(true);
            }

        }


    }

    public void DesactiveHover()
    { 

        if(this.getGameObject.activeSelf == true)
        {
            this.GetGameObject.SetActive(false);
        }

    }

    public int QtdTile()
    {
        int result = 0;
        spaceObject = GameObject.Find("Map");

        result = spaceObject.GetComponentsInChildren<TileScript>().Length;


        return result;
    }
}
