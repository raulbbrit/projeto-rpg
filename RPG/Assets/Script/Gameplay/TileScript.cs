using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Mirror;

public class TileScript : MonoBehaviour
{
    
 //   public GameObject Pin { get; private set; }


    public Point GridPosition { get; private set; }
    public bool isEmpty { get; private set; }
    private SpriteRenderer spriteRenderer;
    private GameObject prefabTile;
    private Color32 fullColor = new Color32(255, 118, 118, 255);
    private Color32 emptyColor = new Color32(96, 255, 90, 255);

    public Vector2 WordPosition
    {
        get
        {
            return new Vector2(transform.position.x + (GetComponent<SpriteRenderer>().bounds.size.x / 2),
                transform.position.y - (GetComponent<SpriteRenderer>().bounds.size.y / 2));
        }
    }
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    
    public void Setup(Point gridPos, Vector3 worldPos, Transform parent)
    {
        isEmpty = true;
        this.GridPosition = gridPos;
        transform.position = worldPos;
        transform.SetParent(parent);
        MapManager.Instance.Tiles.Add(gridPos, this);
    }


    private void OnMouseOver()
    {
        if(!(EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.SelectedObject != null))
        {
            if (Input.GetMouseButtonDown(1))
                {
                    if (NetworkClient.localPlayer == null)
                    {
                        if (Hover.indexPlayer > 0)
                        {
                            if (!Hover.hoverBool)
                            {

                            if(!isEmpty)
                            {
                                Hover.indexPlayer--;
                                isEmpty = true;
                                Destroy(prefabTile);

                            }
                            }

                        }
                    }
                    else if (NetworkClient.localPlayer.isServer)
                    {
                        if (Hover.indexMaster > 0)
                        {
                            if (!Hover.hoverBool)
                            {
                            if(!isEmpty)
                            {

                                Hover.indexMaster--;
                                Debug.Log("TILESCRIPT: " + Hover.indexMaster);
                                isEmpty = true;
                                Destroy(prefabTile);
                            }


                            }
                        }
                    }
                }
        }

        if (!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.SelectedObject != null)
        {
            if (Hover.hoverBool)
            {

                if (isEmpty && GameManager.Instance.SelectedObject.MapObjectPreFab != null)
                {
                    ColorTile(emptyColor);
                }
                if (!isEmpty && GameManager.Instance.SelectedObject.MapObjectPreFab != null)
                {
                    ColorTile(fullColor);
                }

                else if (Input.GetMouseButtonDown(0) && GameManager.Instance.SelectedObject.MapObjectPreFab != null)
                {

                    PlaceObject();

                }
            }

        }
    }

    private void OnMouseExit()
    {
        ColorTile(Color.white);
    }
    //Posiciona o objeto vindo do GamManager
    private void PlaceObject()
    {
        // Debug.Log("Placing a pin at "+GridPosition.X+","+GridPosition.Y); Pegar posição do click no quadriculado
     
        GameObject _object = (GameObject)Instantiate(GameManager.Instance.SelectedObject.MapObjectPreFab,
            new Vector3(transform.position.x, transform.position.y, 9), Quaternion.identity);

        _object.transform.SetParent(transform);

        isEmpty = false;
        ColorTile(Color.white);
        prefabTile = _object;

        GameManager.Instance.ObjectReleased();
   //     Pin = _object;
    
    }

    private void ColorTile(Color newColor)
    {
        spriteRenderer.color = newColor;
    }

}
