using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Color ogColor;
    public Color changedColor;
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
        if (collision.CompareTag("Trigger")) {
            Debug.Log("Enter");
            sprite.color = changedColor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Trigger"))
        {
            Debug.Log("Exit");
            sprite.color = ogColor;
        }
    }
}
