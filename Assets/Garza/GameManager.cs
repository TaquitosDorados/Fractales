using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float startTimer;
    public BoxCollider2D spawner;
    public GameObject objetoPadrisimo;
    public float spawnerTime = 1;
    public bool startSpawn = false;

    public static GameManager instance;

    public int goldenPuzzlePieces = 0;
    public TextMeshProUGUI contadorTxt;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
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
        if (!startSpawn) return;

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

        var newObject = Instantiate(objetoPadrisimo);

        newObject.transform.position = objectTransform;
    }

    public void AddPuzzlePiece()
    {
        goldenPuzzlePieces++;
        
        contadorTxt.text = ("x " + goldenPuzzlePieces);
    }
}
