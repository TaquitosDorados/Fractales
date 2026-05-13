using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PenecinScript : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Color colorOG;
    public Color changedColor;

    private Rigidbody2D rb;
    private bool muerto = false;

    [Header("Muerte")]
    public GameObject particulasPrefab;
    public AudioClip sonidoMuerte;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        colorOG = sprite.color;

        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(8f, 0f);
    }

    // Update is called once per frame
    void Update()
    {

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
            audio.spatialBlend = 0f;
            audio.Play();
            Destroy(sonidoObj, sonidoMuerte.length);
        }
        Destroy(sprite);
    }
}