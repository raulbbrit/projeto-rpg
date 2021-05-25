using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    [SerializeField]private GameObject tile;
    [SerializeField]private CameraMovement cameraMovement;
    [SerializeField]private int mapX=15;
    [SerializeField]private int mapY=10;
    [SerializeField]private Transform map;
    
    [SerializeField] public Dictionary<Point,TileScript> Tiles { get; set; }
    public float TileSize
    {
        get
        {
            return tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        }
    }
    private void Awake()
    {
        CreateMap();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateMap()
    {
        Tiles = new Dictionary<Point, TileScript>(); 
        Vector3 maxTile = Vector3.zero;
        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        for (int y= 0; y <mapY; y++)
        {
            for (int x = 0; x < mapX; x++)
            {
                PlaceTile(x, y, worldStart); 
            }
        }
        maxTile = Tiles[new Point(mapX-1,mapY-1)].transform.position;
      //  cameraMovement.SetLimits(new Vector3(maxTile.x + TileSize,maxTile.y- TileSize));
    
    }
    private void PlaceTile(int x,int y, Vector3 worldStartPosition)
    {
        
        TileScript newTile = Instantiate(tile).GetComponent<TileScript>();
        newTile.GetComponent<TileScript>().Setup(new Point(x, y),
            new Vector3(worldStartPosition.x + (TileSize * x), worldStartPosition.y - (TileSize * y), 10),map);
     
    }

}
