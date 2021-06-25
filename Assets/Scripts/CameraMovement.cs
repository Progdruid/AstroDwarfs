using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public int Width, Height;
    public float CameraSpeed;
    public float CameraMinSize;
    public float ZoomSpeed;

    private Camera Camera;
    private float CameraWidth => CameraHeight * Camera.aspect; 
    private float CameraHeight => Camera.orthographicSize;

    private void Start()
    {
        Camera = gameObject.GetComponent<Camera>();
    }

    private void Update()
    {
        Vector3 direction = Vector3.zero;
        
        //cos i will rework it into unity actions
        //input is stupid
        if (Input.GetKey(KeyCode.W))
            if (gameObject.transform.position.y + CameraHeight < Height)
                direction = Vector3.up;
        if (Input.GetKey(KeyCode.D))
            if (gameObject.transform.position.x + CameraWidth < Width)
                direction = Vector3.right;
        if (Input.GetKey(KeyCode.S))
            if (gameObject.transform.position.y - CameraHeight > 0)
                direction = Vector3.down;
        if (Input.GetKey(KeyCode.A))
            if (gameObject.transform.position.x - CameraWidth > 0)
                direction = Vector3.left;

        gameObject.transform.position += direction * CameraSpeed;

        if (Input.GetKey(KeyCode.Q))
            if (Camera.orthographicSize - ZoomSpeed >= CameraMinSize)
                Camera.orthographicSize -= ZoomSpeed;

        if (Input.GetKey(KeyCode.E))
        {
            float nextSize = Camera.orthographicSize + ZoomSpeed;
            float nextHeight = nextSize;
            float nextWidth = nextHeight * Camera.aspect;
            float x = gameObject.transform.position.x;
            float y = gameObject.transform.position.y;
            if (x + nextWidth < Width && x - nextWidth > 0 && y + nextHeight < Height && y - nextHeight > 0)
                Camera.orthographicSize = nextSize;
        }
    }
}
