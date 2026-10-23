using System;
using Unity.VisualScripting;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    [SerializeField] private bool isDraggable = true;
    public bool IsDraggable => isDraggable;
    public bool collisionDetected = false;
    public GameObject tileObject;
    public GameObject pieceObject;
    public float tileX;
    public float tileY;
    [SerializeField] private String id;
    public String pId => id;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        pieceObject = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter");
        if (collision.gameObject.CompareTag("White_tile"))
        {
            Debug.Log("Collision Detected");
            collisionDetected = true;
            tileObject = collision.gameObject;
            if (tileObject == null)
            {
                Debug.Log("TileObject is null");
            }
            else
            {
                tileX = tileObject.transform.position.x;
                tileY = tileObject.transform.position.y;
                Debug.Log("Object is not null");
            }

        }

    }

    public void manageCollision()
    {
        if (collisionDetected)
        {
            placePiece();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Outside of collision");
        collisionDetected = false;
        tileObject = null;
        tileX = 0;
        tileY = 0;
    }

    public void placePiece()
    {
        Debug.Log("placePiece");
        transform.position = new Vector2(tileX,tileY);
    }
}
