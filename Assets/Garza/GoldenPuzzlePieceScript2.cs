using UnityEngine;

public class GoldenPuzzlePieceScript2 : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.AddPuzzlePiece();
            Destroy(gameObject);
        }
    }
}
