using UnityEngine;
using UnityEngine.InputSystem;

public class PenesinScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Color ogColor;
    private float movingDirection;

    public Color changedColor;
    public float movingSpeed = 5;
    public GameManager gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        ogColor = sprite.color;
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputValue valor)
    {
        movingDirection = valor.Get<float>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movingDirection * movingSpeed, rb.linearVelocityY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Padrisimo"))
        {
            Debug.Log("Pene entrado");
            sprite.color = changedColor;
        }

        if (collision.CompareTag("Button"))
        {
            Debug.Log("yes");
            gm.startSpawn = !gm.startSpawn;
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

}
