using UnityEngine;

public class Gamemanager1 : MonoBehaviour
{
    private float startTimer;

    public BoxCollider2D spawner;
    public GameObject Objetopadrisimo;
    public float spawnerTime = 1;
    public bool startSpawn = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spawn();
        startTimer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startSpawn)
        {
            return;
        }
        if (Time.time - startTimer >= spawnerTime)
        {
            Spawn();
            startTimer = Time.time;
        }
    }
    private void Spawn()
    {
        Bounds limites = spawner.bounds;

        float xAleatorio = Random.Range(limites.min.x, limites.max.x);

        float yAleatorio = Random.Range(limites.min.y, limites.max.y);

        Vector2 objectTransform = new Vector2(xAleatorio, yAleatorio);

        var newObject = Instantiate(Objetopadrisimo);

        newObject.transform.position = objectTransform;
    }
}
