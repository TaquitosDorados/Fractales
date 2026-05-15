using UnityEngine;

public class PenesinScript : MonoBehaviour
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
        if (collision.CompareTag("Padrisimo"))
        {
            Debug.Log("Pene entrado");
            sprite.color = changedColor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Padrisimo"))
        {
            Debug.Log("Pene salido");
            sprite.color = ogColor;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Padrisimo"))
        {
            sprite.color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
        }
    }

}
