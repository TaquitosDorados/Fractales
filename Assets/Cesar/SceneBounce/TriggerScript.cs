using System;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Color ogColor;
    public Color changedColor;
    private Boolean deleting = false;
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
        Debug.Log(collision.tag);
        switch (collision.tag)
        {
            case "Color":
                sprite.color = new Color(123, 456, 789);
                break;

            case "Size":
                sprite.transform.localScale = new Vector3(2,2,2);
                break;

            case "Destroy":
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Color"))
        {
            sprite.color = new Color(0.1f,0.2f,0.3f,1f);
        }
        else if (collision.gameObject.CompareTag("Size"))
        {
            sprite.transform.localScale = new Vector3(2, 2, 2);
        }
        else if (collision.gameObject.CompareTag("Destroy"))
        {

            if (!deleting)
            {
                deleting = true;
                ParticleSystem part = gameObject.GetComponent<ParticleSystem>();
                AudioSource sound = gameObject.GetComponent<AudioSource>();
                if(!sound.isPlaying) sound.Play();
                part.Play();
                Destroy(gameObject, gameObject.GetComponent<ParticleSystem>().main.duration);
                deleting = false;
            }
            
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
