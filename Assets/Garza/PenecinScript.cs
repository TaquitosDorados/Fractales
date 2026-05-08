using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PenecinScript : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Color colorOG;

    public Color changedColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        colorOG = sprite.color;
    }

    // Update is called once per frame
    void Update()
    {

}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Simba"))
        {
            Debug.Log("Pene entrado");
            sprite.color = changedColor;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Simba"))
        {
            Debug.Log("Pene salido");
            sprite.color = colorOG;
        }
    }
}
