using UnityEditor;
using UnityEngine;

public class TileController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    HeavyBlock heavyBlockObject;
    private readonly int[] validepieces = { 1,2,3,4,5};
    void Start()
    {
        heavyBlockObject = GetComponent<HeavyBlock>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (heavyBlockObject == null)
        {
            Debug.Log($"[{gameObject.name}] Trigger detected a null Collider2D.");
        }

        if (collision.CompareTag("Piece"))
        {
            collision.GetComponent<HeavyBlock>().FreezeOnCollision();
        }
        /*if (collision.CompareTag("Piece"))
        {
            Debug.Log("Collision Detected");
            heavyBlockObject.FreezeOnCollision();
        }*/
    }
}
