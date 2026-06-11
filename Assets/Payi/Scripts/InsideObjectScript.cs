using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class InsideObjectScript : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Color ogColor;
    private Rigidbody2D rb;
    private float movingDirection;

    public Color changeColor;
    public float movingSpeed;
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
        if (collision.CompareTag("button"))
        {
            gm.startSpawn = true;
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
     {
         if(collision.CompareTag("HalfScreenCollision"))
         {
             Debug.Log("Collided");
         }
         if(collision.CompareTag("second_platform_trigger"))
         {
             changeColor = Color.black;
             sprite.color = changeColor;
         }
         if (collision.CompareTag("third_platform_trigger"))
         {
             changeColor = Color.red;
             sprite.color = changeColor;
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
     }*/
}
