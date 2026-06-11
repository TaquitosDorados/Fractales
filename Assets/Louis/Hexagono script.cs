using UnityEngine;
using UnityEngine.InputSystem;

public class Hexagonoscript : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private ParticleSystem particle;
    private Color ogcolor;
    private float movingDirection;
    private AudioSource audiomuerte;
    public float movingSpeed = 5;
    public Gamemanager gm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        particle = GetComponent<ParticleSystem>();
        ogcolor = sprite.color;
        audiomuerte = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputValue valor)
    {
        movingDirection = (valor.Get<float>());
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
        if (collision.CompareTag("Queso"))
        {
            Debug.Log("Quesito entra");
            sprite.color = Color.black;
        }
        if (collision.CompareTag("Queso2"))
        {
            transform.localScale = new Vector3(5, 5, 5);
        }
        if (collision.CompareTag("Queso3"))
        {
            Destroy(sprite);
            GetComponent<ParticleSystem>().Play();
            audiomuerte.Play();
        }
        if (collision.CompareTag("Button"))
        { 
            gm.startSpawn = !gm.startSpawn;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
