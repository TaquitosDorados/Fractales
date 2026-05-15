using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PenecinScript : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Color colorOG;
    public Color changedColor;
    private float movingDirection;
    public float movingSpeed = 5;

    private Rigidbody2D rb;
    private bool muerto = false;
    public GameManager gm;

    [Header("Muerte")]
    public GameObject particulasPrefab;
    public AudioClip sonidoMuerte;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        colorOG = sprite.color;

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
        if (muerto) return;

        if(collision.CompareTag("Simba"))
        {
            sprite.color = changedColor;
        }
        if (collision.CompareTag("Small"))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (collision.CompareTag("Muerte"))
        {
            muerto = true;
            Morir();
        }
        if (collision.CompareTag("Button"))
        {
            gm.startSpawn = !gm.startSpawn;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Simba"))
        {
            sprite.color = colorOG;
        }
    }
    void Morir()
    {
        if (particulasPrefab != null)
            Instantiate(particulasPrefab, transform.position, Quaternion.identity);

        if (sonidoMuerte != null)
        {
            GameObject sonidoObj = new GameObject("SonidoMuerte");
            AudioSource audio = sonidoObj.AddComponent<AudioSource>();
            audio.clip = sonidoMuerte;
            audio.Play();
            Destroy(sonidoObj, sonidoMuerte.length);
        }
        Destroy(sprite);
    }
}