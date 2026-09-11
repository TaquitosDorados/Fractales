using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Camera mainCamera;
    private Vector2 mouseWorldPosition;
    public void OnClick()
    {
        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPosition, Vector2.zero);
        if(hit.collider != null)
        {
            DraggableObject draggableObject = hit.collider.GetComponent<DraggableObject>();
            if(draggableObject != null)
            {
                Debug.Log("Clicked: " + draggableObject.pId);
            }
        }
    }

    public void OnMousePosition(InputValue value)
    {
        Vector2 mouseScreenPosition = value.Get<Vector2>();
        mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
    }

}
