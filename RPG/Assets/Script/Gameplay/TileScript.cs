using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour
{
    public Point GridPosition { get; private set; }
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Setup(Point gridPos, Vector3 worldPos, Transform parent)
    {

        this.GridPosition = gridPos;
        transform.position = worldPos;
        transform.SetParent(parent);
        MapManager.Instance.Tiles.Add(gridPos, this);
    }
    private void OnMouseOver()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.SelectedObject != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlaceObject();
            }

        }
    }
    //Posiciona o objeto vindo do GamManager
    private void PlaceObject()
    {
        // Debug.Log("Placing a pin at "+GridPosition.X+","+GridPosition.Y); Pegar posição do click no quadriculado
     
        GameObject _object = (GameObject)Instantiate(GameManager.Instance.SelectedObject.ObjectPrefab, new Vector3(transform.position.x, transform.position.y, 9), Quaternion.identity);
        _object.transform.SetParent(transform);
        GameManager.Instance.ObjectReleased();

    }
}
