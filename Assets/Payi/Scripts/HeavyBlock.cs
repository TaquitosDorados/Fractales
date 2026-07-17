using UnityEngine;

public class HeavyBlock : MonoBehaviour
{
    private int id = 10;
    private Rigidbody2D rb;
    DragAndDrop dragAndDrop;
    private bool isFrozen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dragAndDrop = GetComponent<DragAndDrop>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void FreezeOnCollision()
    {
        isFrozen = true;
        if (isFrozen == true)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.gravityScale = 0;
        }
    }

    public Rigidbody2D getPieceObject()
    {
        return rb;
    }
}
