using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float startTimer; 

    public BoxCollider2D spawner;
    public GameObject gObject;
    public float spawnTimer = 1;
    public bool startSpawn = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startTimer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(!startSpawn)
        {
            return;
        }

        if(Time.time - startTimer >= spawnTimer)
        {
            Spawn();
            startTimer = Time.time;
        }    
    }
    private void Spawn()
    {
        Bounds limits = spawner.bounds;
        float xRandom = Random.Range(limits.min.x,limits.max.x);
        float yRandom = Random.Range(limits.min.y, limits.max.y);

        Vector2 objectTransform = new Vector2(xRandom, yRandom);
        var newObject = Instantiate(gObject);
        newObject.transform.position = objectTransform;
    }
}
