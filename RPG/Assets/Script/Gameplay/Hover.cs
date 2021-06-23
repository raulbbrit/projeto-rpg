using UnityEngine;
using Mirror;

public class Hover : Singleton<Hover>
{
    // Start is called before the first frame update
    [SerializeField] GameObject getGameObject;
    public static int indexMaster = 0;
    public static int indexPlayer = 0;
    public static bool hoverBool = false;
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

        if (hoverBool)
        {
            Debug.Log("Hover Ativado");
        }
        else
        {

            if (NetworkClient.localPlayer == null)
            {
                if (indexPlayer < 1)
                {
                    Debug.Log(Hover.indexPlayer);
                    indexPlayer++;
                    getGameObject.SetActive(true);
                    hoverBool = true;
                }
            }
            else
            {
                if (indexMaster < QtdTile()) //QTDTILE()
                {
                    indexMaster++;
                    Debug.Log(Hover.indexMaster);
                    hoverBool = true;
                    getGameObject.SetActive(true);
                }

            }

        }


    }

    public void DesactiveHover()
    {
        hoverBool = false;
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
