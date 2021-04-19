using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float cameraSpeed = 20;
    [SerializeField] private float xMax;
    [SerializeField] private float yMin;
    [SerializeField] private float borderThickness = 10;
    [SerializeField] private Vector2 camLimit;
 

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    private void Update()
    {
        MoveCamera();
    }
    private void MoveCamera()   
    {
        Vector3 pos = transform.position;
        if (Input.GetKey(KeyCode.W)||Input.mousePosition.y >= Screen.height - borderThickness)
        {
         
            transform.Translate( Vector3.up* cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= borderThickness)
        {
            transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime);

        }
      
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= borderThickness)
        {

            transform.Translate(Vector3.down * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width- borderThickness)
        {

            transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime);
        }
      //  pos.x =Mathf.Clamp(transform.position.x, 0, xMax);
       // pos.y = Mathf.Clamp(transform.position.y, yMin,0);
       // transform.position = pos;
         transform.position = new Vector3(Mathf.Clamp(transform.position.x, (float)-3.5, 10), Mathf.Clamp(transform.position.y, -10,(float) 3.5 ), 0);

    }

/**    public void SetLimits()
    {
        Vector3 wp = Camera.main.ViewportToWorldPoint(new Vector3(1, 0));
        xMax = (float) 16.19465 - wp.x;
        yMin = (float) -9.401868 - wp.y;
    }**/
}
