using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float startTimer; 

    public BoxCollider2D spawner;
    public GameObject gObject;
    public float spawnTimer = 1;
    public bool startSpawn = false;
    public static GameManager instance;
    public int goldenPuzzlePieces = 0;
    public TextMeshProUGUI counterTxt;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
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

    public void AddPuzzlePiece()
    {
        goldenPuzzlePieces++;
        Debug.Log("GoldenPieces: " + goldenPuzzlePieces);
        counterTxt.text = "x"+goldenPuzzlePieces.ToString();
    }
}
