using System;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool justJumped = false;
    [SerializeField] Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /*void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2 (horizontal * speed, rb.linearVelocity.y);
    }

    void Jump()
    {
        float x = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        Vector2 move = new Vector2(x, 0);
        Vector2 moveVelocity = move * speed;

        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);


    }*/
}
