using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float cameraSpeed = 0;
    [SerializeField] private float xMax;
    [SerializeField] private float yMin;
    [SerializeField] private Vector2 gameLimit;
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        GetImput();
    }
    private void GetImput()   
    {
        Vector3 pos = transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up* cameraSpeed * Time.deltaTime);//deltatime: espaço de tempo do ultimo update

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime);//deltatime: espaço de tempo do ultimo update

        }
      
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * cameraSpeed * Time.deltaTime);//deltatime: espaço de tempo do ultimo update

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime);//deltatime: espaço de tempo do ultimo update

        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 1, xMax), Mathf.Clamp(transform.position.x, yMin, 0),0);
       
    }

    public void SetLimits(Vector3 maxTile)
    {
        Vector3 wp = Camera.main.ViewportToWorldPoint(new Vector3(1, 0));
        xMax = maxTile.x - wp.x;
        yMin = maxTile.y - wp.y;
    }
}
