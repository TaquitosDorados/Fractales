using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragAndDrop : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private bool isDragging = false;

    public bool GetIsDragging
    {
        get { return isDragging; }
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isDragging)
        {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            rb2d.gravityScale = 0;
        }else
        {
            rb2d.gravityScale = 1;
        }
    }

    private void OnMouseDown()
    {
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }
}
