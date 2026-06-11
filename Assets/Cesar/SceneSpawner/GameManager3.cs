using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GameManager3 : MonoBehaviour
{
    private float startTimer;

    public BoxCollider2D spawner;
    public GameObject objecto;
    public float spawnerTime = 1;
    public bool startSpawn = false;

    public static GameManager3 instance;
    public int goldenPuzzlePieces = 0;
    public TextMeshProUGUI contadorTxt;

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
        if (!startSpawn) return;
        if(Time.time - startTimer >= spawnerTime)
        {
            Spawn();
            startTimer = Time.time;
        }
    }

    public void Spawn()
    {
        Bounds limites = spawner.bounds;
        float xRand = Random.Range(limites.min.x, limites.max.x);
        float yRand = Random.Range(limites.min.y, limites.max.y);

        Vector2 objectTransform = new Vector2(xRand, yRand);

        var newObject = Instantiate(objecto);
        newObject.transform.position = objectTransform;

    }

    public void AddPuzzlePiece()
    {
        goldenPuzzlePieces++;
        contadorTxt.text = "x " + goldenPuzzlePieces.ToString();
    }
}
