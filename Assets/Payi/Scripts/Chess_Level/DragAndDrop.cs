using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Camera mainCamera;
    private Vector2 mouseWorldPosition;
    public DraggableObject draggableObject;
    public bool holding = false;
    float objectX = 0;
    float objectY = 0;

    private void Update()
    {
        if(holding)
        {
            draggingObject(draggableObject);
        }
       
    }

    
    public void OnClick()
    {
        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPosition, Vector2.zero);
        if(hit.collider != null)
        {
            draggableObject = hit.collider.GetComponent<DraggableObject>();
            if(draggableObject != null)
            {
                objectX = draggableObject.transform.position.x;
                objectY = draggableObject.transform.position.y;
                if(Mouse.current.leftButton.ReadValue() == 1)
                {
                    holding = true;
                } else
                {
                    holding = false;
                    draggableObject.transform.position = draggableObject.transform.position;
                    draggableObject = null; 
                }
            }
        }
    }

    public void OnMousePosition(InputValue value)
    {
        Vector2 mouseScreenPosition = value.Get<Vector2>();
        mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
    }


    public void draggingObject(DraggableObject draggableObject)
    {
        draggableObject.transform.position = mouseWorldPosition;
    }

}
