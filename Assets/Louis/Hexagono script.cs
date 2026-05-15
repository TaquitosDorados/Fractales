using UnityEngine;

public class Hexagonoscript : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Color ogcolor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        ogcolor = sprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Queso"))
        {
            Debug.Log("Quesito entra");
            sprite.color = Color.black;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Queso"))
        {
            Debug.Log("Quesito sale");
            sprite.color = ogcolor;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
}
