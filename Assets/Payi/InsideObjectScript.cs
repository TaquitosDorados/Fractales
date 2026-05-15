using UnityEngine;

public class InsideObjectScript : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Color ogColor;

    public Color changeColor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        ogColor = sprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("HalfScreenCollision"))
        {
            Debug.Log("Collided");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("HalfScreenCollision"))
        {
            Debug.Log("Left Collision");
            sprite.color = ogColor;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        sprite.color = changeColor;
    }
}
