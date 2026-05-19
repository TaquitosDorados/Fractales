using System;
using UnityEngine;

using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class SpawnerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Color ogColor;
    private float movingDirection;
    public Color changedColor;
    public float movingSpeed = 5;
    public GameManager gm;
    public float jumpSpeed;
    private bool isJumping = false;
    private bool grounded = false;
    private bool doubleJump = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        ogColor = sprite.color;
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputValue inputValue)
    {
       movingDirection = inputValue.Get<float>();
    }

    public void OnJump(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            if(isJumping) doubleJump = false;
            isJumping = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if ((isJumping && grounded) || (isJumping && doubleJump))
        {
            rb.linearVelocity = new Vector2(movingDirection * 5, jumpSpeed);
            isJumping = false;
            if(!grounded) doubleJump = false;
            grounded = false;
        }
        else
        {
            rb.linearVelocity = new Vector2(movingDirection * 5, rb.linearVelocity.y);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Piso"))
        {
            grounded = true;
            doubleJump = true;
        }
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Padrisimo"))
        {
            sprite.color = new Color(UnityEngine.Random.Range(0, 255), UnityEngine.Random.Range(0, 255), UnityEngine.Random.Range(0, 255));
        }
    }



}
